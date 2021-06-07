<template>
  <div class="container relative">
    <SideBar :buttons="buttonsarr" class="fixed" />
    <main class="ml-20 space-y-5">
      <div class="pl-10 flex flex-row">
        <label class="mt-5 text-8xl">Projects</label>
        <!-- Add project -->
        <Button
          :text="showAddProject ? 'Cancel' : 'Add Project'"
          :class="
            showAddProject
              ? 'bg-red-500 hover:bg-red-600'
              : 'bg-blue-500 hover:bg-blue-600'
          "
          @toggle-add-project="toggleAddProject"
          class="ml-auto mt-8 mr-8 w-48"
        />
      </div>

      <div v-show="showAddProject">
        <AddProject @add-project="addProject" class="ml-auto mr-8" />
      </div>

      <!-- Projects -->
      <div class="w-full" v-for="(project, idx) in projects" :key="idx">
        <ProjectPreview
          :name="project.name"
          :date="project.date"
          :description="project.description"
          :projectId="project.idProject"
          :project="project"
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
import { ProjectsAPI } from "../services/ProjectsAPI";
import AddProject from "../components/AddProject.vue";
import Button from "../components/Button.vue";
import firebase from "firebase/app";
import store from "../model/Store";
// import state from "../model/CStore";
// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    SideBar,
    ProjectPreview,
    AddProject,
    Button,
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

  public projects = store.projects;

  showAddProject = false;

  toggleAddProject() {
    // console.log(this.$root.$data);
    this.showAddProject = !this.showAddProject;
  }

  async fetchProjects() {
    const user = await firebase.auth().currentUser;
    // console.log(user);
    // console.log("FETCHED DATAAAAA FOK");

    if (user != null) {
      await ProjectsAPI.loadProjects(user.uid)
        .then((response) => {
          //console.log(response);
          store.projects = response.data;
          // state.projects = response.data;
          //this.$store.state.projects = response.data;
          this.projects = response.data;
        })
        .catch((Error) => {
          alert("Couldn't connect to API");
          console.log(Error);
        });
    }
  }

  created() {
    this.fetchProjects();
    this.projects = store.projects;

    // Reload page after project deletion
    if (store.reload) {
      store.reload = false;
      this.$router.go(0);
    }
  }

  addProject(new_project: Project) {
    store.projects.push(new_project);
  }
}
</script>
