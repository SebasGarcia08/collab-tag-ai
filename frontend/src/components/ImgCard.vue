<template>
  <div class="rounded-md overflow-hidden shadow-lg">
    <!-- Unselect file btt -->
    <div
      v-show="image.preview"
      class="absolute mt-1 ml-1 text-red-500 bg-white rounded-full z-10"
    >
      <a @click="unselectFile">
        <i class="fas fa-times-circle fa-2x"></i>
      </a>
    </div>

    <img :src="image.image" alt="random" class="w-full" />
    <div class="px-6 py-4">
      <!-- <div class="font-bold text-purple-500 text-xl mb-2">
        Photo by {{ imageFormatted.user }}
      </div> -->
      <ul>
        <li v-if="!image.preview"><strong>Date:</strong> {{ image.date }}</li>
        <li v-if="!image.preview"><strong>User:</strong> {{ image.idUser }}</li>
        <li v-if="image.preview">{{ image.name }}</li>
      </ul>
    </div>
    <div v-show="!image.preview" class="px-6 py-4 border">
      <span
        v-if="!image.idClass"
        class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2"
        >#Untagged
      </span>
      <span
        v-else
        class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2"
        >#{{ image.idClass }}</span
      >
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SideBar from "../components/SideBar.vue";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { Item } from "../model/Item";
import { Project } from "../model/Project";
import { ProjectsAPI } from "../services/ProjectsAPI";
import Button from "../components/Button.vue";
import firebase from "firebase/app";
import store from "../model/Store";
import Utils from "../Utils";

@Component({
  components: {
    SideBar,
    Button,
  },
})
export default class ImgCard extends Vue {
  @Prop() image!: any;

  mounted() {
    //console.log(this.image);
  }
  public imgClass!: string;

  unselectFile(): void {
    this.$emit("unselect-file", this.image);
  }
  //   setup(props) {
  //     const imageFormatted = computed(() => ({
  //       ...props.image,
  //       tags: props.image.tags.split(",").map((i) => i.trim()),
  //       views: props.image.views.toLocaleString(),
  //       downloads: props.image.downloads.toLocaleString(),
  //       likes: props.image.likes.toLocaleString(),
  //     }));
  //     return {
  //       imageFormatted,
  //     };
  //   },
}
</script>
