<template>
  <form @submit="onSubmit" action="" class="w-1/3 space-y-5">
    <!-- Project name field -->
    <div>
      <label class="text-m font-bold text-gray-600 block">
        Project name:
      </label>
      <input
        type="text"
        v-model="project_name"
        name="project_name"
        placeholder="Add project name"
        class="block w-full p-2 rounded border-2 border-solid border-gray-500"
      />
    </div>
    <!-- Description field -->
    <div>
      <label class="text-m font-bold text-gray-600 block"> Description: </label>
      <textarea
        cols="30"
        rows="4"
        v-model="description"
        name="description"
        placeholder="Add description"
        class="block w-full p-2 rounded border-2 border-solid border-gray-500"
      />
    </div>
    <!-- Submit Button -->
    <div class="flex justify-center">
      <button
        class="w-full py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center"
      >
        Create Project
      </button>
    </div>
  </form>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Project } from "../model/Project";
import { ProjectsLoader } from "@/repositories/ProjectsLoader";
import firebase from "firebase/app";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {},
})
export default class AddProject extends Vue {
  // Initial data can be declared as instance properties

  project_name = "";
  description = "";

  projectsLoader: ProjectsLoader = new ProjectsLoader();

  async onSubmit(e) {
    e.preventDefault();

    if (!this.project_name) {
      alert("Please fill all the fields");
      return;
    }

    const today = new Date();
    const date =
      today.getFullYear() +
      "/" +
      (today.getMonth() + 1) +
      "/" +
      today.getDate();

    const user = await firebase.auth().currentUser;

    if (user != null) {
      let new_project: Project = new Project(
        this.project_name,
        date,
        this.description,
        user.uid
      );

      this.projectsLoader.createProject(new_project).then((response) => {
        //console.log(response);
        //new_project = response;
        new_project.idProject = response.data.idProject;
      });

      this.$emit("add-project", new_project);

      console.log(new_project);
    }

    // this.project_name = "";
    // this.description = "";
  }
}
</script>
