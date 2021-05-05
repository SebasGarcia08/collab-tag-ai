<template>
  <div class="container relative bg-white dark:bg-gray-800">
    <SideBar :buttons="buttonsarr" class="absolute" />
    <main class="ml-20"></main>
    <WebcamPanel />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SideBar from "../components/SideBar.vue";
import WebcamPanel from "@/components/Webcam.vue";

import Component from "vue-class-component";
import { Item } from "../model/Item";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    WebcamPanel,
    SideBar,
  },
})
export default class App extends Vue {
  // Initial data can be declared as instance properties

  buttonsarr: Array<Item> = [
    {
      text: "Projects",
      route: "/Projects",
      icon: "fas fa-stream fa-2x",
    },
    {
      text: "Settings",
      route: "/Setting",
      icon: "fas fa-cogs fa-2x",
    },
    {
      text: "Inference",
      route: "/Inference",
      icon: "fas fa-chart-bar fa-2x",
    },
  ];
}
</script>
