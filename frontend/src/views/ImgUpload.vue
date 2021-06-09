<template>
  <div class="container relative">
    <SideBar :buttons="buttonsarr" class="fixed" />
    <main class="ml-20 space-y-5">
      <div class="pl-10 flex flex-col">
        <label class="mt-5 text-8xl font-semibold text-blue-900 pb-4"
          >Image uploading</label
        >
        <div class="w-full flex flex-row py-3">
          <!-- Select files -->
          <div
            class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm font-semibold w-40 p-2"
          >
            <label for="upload-image" class="text-white">
              Select Images
              <input
                id="upload-image"
                type="file"
                accept="image/*"
                multiple
                class="hidden"
                @change="selectFile"
              />
              <i class="fas fa-file-image pl-2"></i>
            </label>
          </div>
          <!-- Upload files -->
          <div
            class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm w-40 p-2 text-white"
          >
            <a
              @click="uploadFiles"
              :disabled="!selectedFiles"
              class="font-semibold"
              >Upload Images</a
            >
            <i class="fas fa-upload pl-2"></i>
          </div>
        </div>
        <!-- Message ¿? -->
        <div v-if="message">
          <ul>
            <li v-for="(ms, i) in message.split('\n')" :key="i">
              {{ ms }}
            </li>
          </ul>
        </div>
        <!-- Imgs gallery -->
        <div class="card mx-5">
          <div class="card-header font-bold text-xl">Preview</div>
          <div
            class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4 mt-5"
          >
            <div v-for="(file, index) in previewFiles" :key="index">
              <ImgCard :image="file" @unselect-file="unselectFile" />
            </div>
          </div>
        </div>
        <!-- Imgs uploading percentage -->
        <div class="flex flex-col">
          <div
            class="w-full mt-5"
            v-for="(progressInfo, index) in progressInfos"
            :key="index"
          >
            <span> {{ progressInfo.fileName }}</span>
            <div class="relative pt-1">
              <div
                :aria-valuenow="progressInfo.percentage"
                :style="{ width: progressInfo.percentage + '%' }"
                class="shadow-none flex flex-col text-center whitespace-nowrap text-white justify-center bg-green-500"
              >
                {{ progressInfo.percentage }}%
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SideBar from "../components/SideBar.vue";
import Component from "vue-class-component";
import { Item } from "../model/Item";
import ImgCard from "../components/ImgCard.vue";
import { Project } from "../model/Project";
import { ProjectsAPI } from "../services/ProjectsAPI";
import Button from "../components/Button.vue";
import firebase from "firebase/app";
import store from "../model/Store";
import Utils from "../Utils";

interface ProgressInfo {
  percentage: number;
  fileName: string;
}

interface PreviewImg {
  name: string;
  image: Blob;
  preview: boolean;
}

@Component({
  components: {
    SideBar,
    Button,
    ImgCard,
  },
})
export default class ImgUpload extends Vue {
  // Initial data can be declared as instance properties

  buttonsarr: Array<Item> = [
    {
      text: "Projects",
      route: "/projects",
      icon: "fas fa-stream fa-2x",
    },
    {
      text: "Settings",
      route: "/setting",
      icon: "fas fa-cogs fa-2x",
    },
    {
      text: "Inference",
      route: "/inference",
      icon: "fas fa-chart-bar fa-2x",
    },
  ];

  public project = store.currentProject;

  public progressInfos: Array<ProgressInfo> = [];

  public selectedFiles: Array<File> = [];

  public previewFiles: Array<PreviewImg> = [];

  public message = "";

  async selectFile(event): Promise<void> {
    console.log(event);
    this.selectedFiles = Array.from(event.target.files);
    console.log(this.selectedFiles);
    this.progressInfos = [];
    for (var i = 0; i < this.selectedFiles.length; i++) {
      const route: Blob = await Utils.convert2Base64Array(
        this.selectedFiles[i]
      );
      const img = {
        name: this.selectedFiles[i].name,
        image: route,
        preview: true,
      };
      this.previewFiles.push(img);
    }
    console.log("PREVIEW FILES: ");
    console.log(this.previewFiles);
  }

  public async upload(idx: number, file: File): Promise<void> {
    console.log(file);
    this.previewFiles.splice(0, 1);
    this.progressInfos[idx] = { percentage: 0, fileName: file.name };

    const idUser = store.currentUserId;
    console.log("Curr userId: " + store.currentUserId);
    const idProject = this.project.idProject;
    const img: Blob = await Utils.convert2Base64Array(file);
    const date = new Date().toLocaleString();
    console.log("Img when upload: " + img);

    console.log(file);
    ProjectsAPI.uploadImage(
      img,
      idProject,
      idUser,
      date,
      (event: ProgressEvent) => {
        this.progressInfos[idx].percentage = Math.round(
          (100 * event.loaded) / event.total
        );
      }
    )
      .then((res) => {
        this.selectedFiles = [];
      })
      .catch((err) => {
        this.progressInfos[idx].percentage = 0;
        this.message = "Could not upload the image:" + file.name;
        alert("WE ARE FUCKING NOOBS" + err);
      });
  }

  public uploadFiles(): void {
    this.message = "";
    for (let i = 0; i < this.selectedFiles.length; i++) {
      this.upload(i, this.selectedFiles[i]);
    }
  }

  public unselectFile(image: PreviewImg): void {
    const idx = this.previewFiles.indexOf(image);
    this.previewFiles.splice(idx, 1);
    this.selectedFiles.splice(idx, 1);
  }

  mounted(): void {
    //this.fetchImages();
    ProjectsAPI.checkUserId();
  }
}
</script>
