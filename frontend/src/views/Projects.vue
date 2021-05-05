<template>
  <div class="container relative">
    <SideBar :buttons="buttonsarr" class="fixed" />
    <main class="mx-20 space-y-5">
      <h1 class="text-8xl p-10">Projects</h1>
      <!-- Projects -->
      <div class="w-full" v-for="project in projects" :key="project">
        <ProjectPreview
          :name="project.name"
          :date="project.date"
          :description="project.description"
        />
      </div>
      <!-- <ProjectPreview name="Project Name" class="pl-10 h-full" /> -->
    </main>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SideBar from "../components/SideBar.vue";
import ProjectPreview from "../components/ProjectPreview.vue";
import Component from "vue-class-component";
import { Item } from "../model/Item";
import { Project } from "../model/Project";
import { ProjectsLoader } from "../repositories/ProjectsLoader";

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

  projects: Array<Project> = [];

  projectsLoader: ProjectsLoader = new ProjectsLoader();

  async fetchProjects() {
    await this.projectsLoader
      .loadProjects(1)
      .then((response) => {
        console.log(response);
        this.projects = response.data;
      })
      .catch((Error) => {
        alert("Couldn't connect to API");
        console.log(Error);
      });
  }

  created() {
    this.fetchProjects();
  }
}
</script>
