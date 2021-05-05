<template>
  <div class="container">
    <!-- Project -->
    <div
      class="max-w-nd shadow-md bg-gray-50 flex flex-row border border-black rounded-xl"
    >
      <div class="flex flex-col">
        <!-- Project name -->
        <p class="ml-5 mt-5 mb-5 text-xl font-bold text-blue-900">
          {{ projectName }}
        </p>
        <!-- Description -->
        <p class="ml-5 mb-5 text-justify">{{ description }}</p>
      </div>
      <!-- Preview image -->
      <div class="m-5 p-8 w-1/4 flex flex-col justify-center">
        <i class="fas fa-project-diagram fa-5x text-blue-900"></i>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "ProjectPreview",

  props: {
    projectName: String,
    description: {
      type: String,
      default:
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
    },
  },

  data: () => ({
    //
  }),
});
</script>
