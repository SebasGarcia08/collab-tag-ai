<template>
  <div class="container relative">
    <SideBar :buttons="buttonsarr" class="fixed" />
    <main class="ml-20">
      <ProjectInfo class="" />
    </main>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SideBar from "../components/SideBar.vue";
import ProjectInfo from "../components/ProjectInfo.vue";
import Component from "vue-class-component";
import { Item } from "../model/Item";
import { Project } from "../model/Project";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    SideBar,
    ProjectInfo,
  },
})
export default class ProjectFull extends Vue {
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

  //   projectsLoader: ProjectsLoader = new ProjectsLoader();

  //   async fetchProjects() {
  //     await this.projectsLoader
  //       .loadProjects(1)
  //       .then((response) => {
  //         console.log(response);
  //         this.projects = response.data;
  //       })
  //       .catch((Error) => {
  //         alert("Couldn't connect to API");
  //         console.log(Error);
  //       });
  //   }

  //   created() {
  //     this.fetchProjects();
  //   }
}
</script>
