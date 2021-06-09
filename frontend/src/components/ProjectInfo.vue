<template>
  <div class="container">
    <!-- Project -->
    <div class="flex flex-row">
      <div class="pl-10 flex flex-col">
        <!-- Project name -->
        <p class="mt-5 mb-5 text-8xl font-semibold text-blue-900">
          {{ project.name }}
        </p>
      </div>
      <!-- Preview image -->
      <div class="p-8 flex flex-col justify-center ml-auto">
        <i class="fas fa-project-diagram fa-5x text-blue-900"></i>
      </div>
    </div>
    <div class="w-full flex flex-row">
      <!-- Upload images btt -->
      <div
        class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm w-40 p-2 text-white"
      >
        <a @click="openImgUpload" class="font-semibold">Upload Images</a>
        <i class="fas fa-cloud-upload-alt pl-2"></i>
      </div>
      <!-- Classify images btt -->
      <div
        class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm w-40 p-2 text-white"
      >
        <a class="font-semibold">Classify Images</a>
        <i class="fas fa-object-group pl-2"></i>
      </div>
      <!-- Inference btt -->
      <div
        class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm w-40 p-2 text-white"
      >
        <a @click="openInference" class="font-semibold">Inference</a>
        <i class="fas fa-chart-bar pl-2"></i>
      </div>
    </div>
    <!-- Collaborators -->
    <div class="mt-5 w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold"> Collaborators </label>
      </div>
      <div class="w-full">
        <div class="px-5" v-for="(member, idx) in members" :key="idx">
          <p>- {{ member.name }}<br /></p>
        </div>
      </div>
    </div>
    <!-- Description -->
    <div class="w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold"> Description </label>
      </div>
      <div class="w-full">
        <p class="px-5 text-justify">
          {{ project.description }}
        </p>
      </div>
    </div>
    <!-- Classes -->
    <div class="w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold"> Classes </label>
        <!-- Add class field and btt -->
        <input
          type="text"
          v-model="newClass"
          name="newClass"
          placeholder="Add class"
          class="mx-5 block w-28 rounded border-2 border-solid border-gray-500"
        />
        <button
          @click="addClass"
          class="mx-5 border rounded bg-gray-300 hover:bg-gray-400 px-2"
        >
          Add
        </button>
      </div>
      <div class="w-full">
        <div
          class="px-5 text-justify"
          v-for="(pjClass, idx) in classes"
          :key="idx"
        >
          <p>- {{ pjClass.name }}<br /></p>
        </div>
      </div>
    </div>
    <!-- Tasks -->
    <div class="w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold"> Tasks </label>
      </div>
      <div class="w-full">
        <p class="px-5 text-justify">
          - Upload and classify 1000 pictures<br />
          - Train model<br />
          - Hire more collaborators
        </p>
      </div>
    </div>
    <div
      class="m-5 flex flex-row items-center border rounded bg-red-500 hover:bg-red-600 w-40 font-semibold text-white p-2"
    >
      <button @click="deleteProject" class="focus:outline-none">
        Delete project
      </button>
      <i class="fas fa-trash-alt pl-4"></i>
    </div>
    <!-- Imgs gallery -->
    <div class="card mx-5">
      <div class="card-header font-bold text-xl">Images gallery</div>
      <div
        class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4 mt-5"
      >
        <div v-for="(file, index) in fileInfos" :key="index">
          <ImgCard :image="file" />
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import store from "../model/Store";
import firebase from "firebase/app";
import { ProjectsAPI } from "../services/ProjectsAPI";
import { ImageClass } from "../model/ImageClass";
import { ProjectMember } from "../model/ProjectMember";
import ImgCard from "../components/ImgCard.vue";
import Utils from "../Utils";

interface ProgressInfo {
  percentage: number;
  fileName: string;
}

@Component({
  components: {
    ImgCard,
  },
})
export default class ProjectInfo extends Vue {
  // Initial data can be declared as instance properties

  @Prop({ default: "Project name" }) name!: string;
  @Prop({
    default:
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
  })
  public description!: string;

  public project = store.currentProject;

  public newClass = "";

  public members: Array<ProjectMember> = [];

  public classes: Array<ImageClass> = [];

  public fileInfos: any = [];

  async addClass(): Promise<void> {
    const user = await firebase.auth().currentUser;

    if (user != null) {
      if (this.newClass != "") {
        await ProjectsAPI.createClass(
          this.newClass,
          store.currentProject.idProject
        )
          .then((response) => {
            console.log(response.status);
            console.log(response.data);
            this.classes.push(response.data);
          })
          .catch((Error) => {
            alert("Couldn't connect to API");
            console.log(Error);
          });

        this.newClass = "";
      }
    }

    store.currentProject.classes = this.classes;
  }

  openInference(): void {
    this.$router.push("/inference");
  }

  openImgUpload(): void {
    this.$router.push("/imgUpload");
  }

  async fetchMembers(): Promise<void> {
    const user = firebase.auth().currentUser;
    console.log(user);

    if (user != null) {
      this.members = await ProjectsAPI.loadMembers(
        store.currentProject.idProject
      );
    }
  }

  async fetchClasses(): Promise<void> {
    const user = await firebase.auth().currentUser;
    console.log(user);

    if (user != null) {
      await ProjectsAPI.loadClasses(store.currentProject.idProject)
        .then((response) => {
          // console.log(response);
          this.classes = response.data;
        })
        .catch((Error) => {
          alert("Couldn't connect to API");
          console.log(Error);
        });
    }

    store.currentProject.classes = this.classes;
  }

  public deleteProject(): void {
    const sure = confirm("Are you sure?");
    if (sure) {
      ProjectsAPI.deleteProject(store.currentProject.idProject)
        .then((res) => {
          if (res.status == 200) {
            alert("Project deleted successfully");
            this.$router.push("/projects");
          } else {
            alert("Server error. Status: " + res.status);
          }
        })
        .catch((err) => {
          alert(err);
          console.log(err);
          this.$router.push("/projects");
        });
    }
  }

  public async fetchImages(): Promise<void> {
    await ProjectsAPI.getAllImages(store.currentProject.idProject)
      .then((res) => {
        console.log("IMAGES: ");
        this.fileInfos = res.data;
        for (var i = 0; i < this.fileInfos.length; i++) {
          this.fileInfos[i].image = window.atob(this.fileInfos[i].image);
        }
        console.log("FILES INFOS");
        console.log(this.fileInfos);
        // for (let i = 0; i < res.data.length; i++) {
        //   console.log(Utils.base64ToUint8Array(res.data[i].image));
        // }
        console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }

  mounted(): void {
    this.fetchImages();
    ProjectsAPI.checkUserId();
    console.log("FUCKING  MOUNTEEEEEEEEEEEEEEEEEED");
  }

  created(): void {
    this.fetchMembers();
    this.fetchClasses();
  }
}
</script>
