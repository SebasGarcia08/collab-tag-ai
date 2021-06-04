<template>
  <div class="container">
    <!-- Project -->
    <div
      class="flex flex-row"
    >
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
      <div class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm font-semibold w-40 p-2">
        <label for="upload-image" class="text-white">
        Upload Images
        <input id="upload-image" type="file" class="hidden"/>
        <i class="fas fa-upload pl-2"></i>
      </label>
      </div>
      <!-- Classify images btt -->
      <div class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm w-40 p-2 text-white">
        <a class="font-semibold">Classify Images</a>
        <i class="fas fa-object-group pl-2"></i>
      </div>
      <!-- Inference btt -->
      <div class="flex items-center justify-center mx-auto border rounded bg-blue-500 hover:bg-blue-600 shadow-sm w-40 p-2 text-white">
        <a @click="openInference" class="font-semibold">Inference</a>
        <i class="fas fa-chart-bar pl-2"></i>
      </div>
    </div>
    <!-- Collaborators -->
    <div class="mt-5 w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold">
          Collaborators
        </label>
      </div>
      <div class="w-full">
        <p class="px-5">
          - Juan Fernando Angulo Salvador<br>
          - Christian Gallo<br>
          - Sebastián García Acosta
        </p>
      </div>
    </div>
    <!-- Description -->
    <div class="w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold">
          Description
        </label>
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
        <label class="px-5 font-bold">
          Classes
        </label>
        <!-- Add class field and btt -->
        <input
            type="text"
            v-model="newClass"
            name="newClass"
            placeholder="Add class"
            class="mx-5 block w-28 rounded border-2 border-solid border-gray-500"
          />
        <button @click="addClass" class="mx-5 border rounded bg-gray-300 hover:bg-gray-400 px-2">Add</button>
      </div>
      <div class="w-full">
        <div class="px-5 text-justify" v-for="(pjClass, idx) in classes" :key="idx">
          <p>
          - {{ pjClass }}<br>
          </p>
        </div>
      </div>
      
    </div>
    <!-- Tasks -->
    <div class="w-full border flex flex-row">
      <div class="w-44 bg-gray-100">
        <label class="px-5 font-bold">
          Tasks
        </label>
      </div>
      <div class="w-full">
        <p class="px-5 text-justify">
          - Upload and classify 1000 pictures<br>
          - Train model<br>
          - Hire more collaborators
        </p>
      </div>
    </div>
    <div class="m-5 flex flex-row items-center border rounded bg-red-500 hover:bg-red-600 w-40 font-semibold text-white p-2">
      <a>Delete project</a>
      <i class="fas fa-trash-alt pl-4"></i>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Prop } from 'vue-property-decorator';
import store from "../model/Store";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    
  },
})
export default class ProjectInfo extends Vue {
  // Initial data can be declared as instance properties

  @Prop({default: 'Project name'}) name!: string;
  @Prop({default: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'}) description!: string;

  project = store.currentProject;

  newClass = "";

  classes: Array<string> = ["Cats", "Dogs"];

  addClass() {
    if (this.newClass != "") {
      this.classes.push(this.newClass);
      this.newClass = "";
    }
  }

  openInference() {
    this.$router.push("/Inference");
  }
}
</script>