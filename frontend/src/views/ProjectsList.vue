<template>
  <div class="container relative">
    <SideBar :buttons="buttonsarr" class="fixed" />
    <main class="ml-20 space-y-5">
      <div class="pl-10 flex flex-row">
        <label class="mt-5 text-8xl">Projects</label>
        <!-- Add project -->
        <Button :text="showAddProject ? 'Cancel' : 'Add Project'"
        :class="showAddProject ? 'bg-red-500 hover:bg-red-600' : 'bg-blue-500 hover:bg-blue-600'"
        @toggle-add-project="toggleAddProject" class="ml-auto mt-8 mr-8 w-48" />
      </div>

      <div v-show="showAddProject">
        <AddProject @add-project="addProject" class="ml-auto mr-8"/> 
      </div>

      <!-- Projects -->
      <div class="w-full" v-for="(project, idx) in projects" :key="idx">
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
import AddProject from "../components/AddProject.vue";
import Button from "../components/Button.vue";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    SideBar,
    ProjectPreview,
    AddProject,
    Button
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

  showAddProject = false;

  toggleAddProject () {
    this.showAddProject = !this.showAddProject;
  }

  addProject (new_project) {
    // Send it to the DB
  }

  projects: Array<Project> = [];

  projectsLoader: ProjectsLoader = new ProjectsLoader();

  async fetchProjects() {
    // this.$data.user.getIdToken(true).then((token) => {
      this.projectsLoader.loadProjects(1).then((response) => {
        console.log(response);
        this.projects = response.data;
      })
      .catch((Error) => {
        alert("Couldn't connect to API");
        console.log(Error);
      });
    //})
  }

  created() {
    this.fetchProjects();
  }
}
</script>
