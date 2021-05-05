<template>
  <div class="container relative">
    <SideBar :buttons="buttonsarr" class="absolute" />
    <main class="mx-20">
      <h1 class="text-8xl p-10">Projects</h1>
      <!-- <div class="w-full" v-for="project in projects" :key="project">
        <ProjectPreview
          :text="button.text"
          :route="button.route"
          :icon="button.icon"
        />
      </div> -->
      <ProjectPreview projectName="Project Name" class="pl-10 h-full"/>
    </main>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SideBar from "../components/SideBar.vue";
import ProjectPreview from "../components/ProjectPreview.vue";
import Component from "vue-class-component";
import { Item } from "../model/Item";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    SideBar,
    ProjectPreview,
  },
})
export default class Projects extends Vue {
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
