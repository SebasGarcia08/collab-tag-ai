<template>
  <div class="container pl-10 pr-8">
    <!-- Project -->
    <a @click="setCurrProject"
      class="max-w-nd shadow-md bg-gray-50 flex flex-row border border-black rounded-xl hover:bg-gray-100"
    >
      <div class="flex flex-col">
        <!-- Project name -->
        <p class="ml-5 mt-5 mb-5 text-xl font-bold text-blue-900">
          {{ name }}
        </p>
        <!-- Description -->
        <p class="ml-5 mb-5 text-justify">{{ description }}</p>
        <!-- Id -->
        <p class="ml-5 mb-5 text-justify">Id: {{ projectId }}</p>
      </div>
      <!-- Preview image -->
      <div class="m-5 p-8 flex flex-col justify-center ml-auto">
        <i class="fas fa-project-diagram fa-5x text-blue-900"></i>
      </div>
    </a>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Prop } from 'vue-property-decorator';
import { Project } from "../model/Project";
import store from "../model/Store";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    
  },
})
export default class ProjectPreview extends Vue {
  // Initial data can be declared as instance properties

  @Prop({default: 'Project name'}) name!: string;
  @Prop() project!: Project;
  @Prop() projectId!: number;
  @Prop({default: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'}) description!: string;

  setCurrProject() {
    store.currentProject = this.project;
    
    console.log(store.currentProject);

    this.$router.push("/ProjectFull");
  }

}
</script>
