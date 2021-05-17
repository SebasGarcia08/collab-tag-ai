<template>
  <div class="container pl-10 pr-8">
    <!-- Project -->
    <router-link to="/ProjectFull"
      class="max-w-nd shadow-md bg-gray-50 flex flex-row border border-black rounded-xl hover:bg-gray-100"
    >
      <div class="flex flex-col">
        <!-- Project name -->
        <p class="ml-5 mt-5 mb-5 text-xl font-bold text-blue-900">
          {{ name }}
        </p>
        <!-- Description -->
        <p class="ml-5 mb-5 text-justify">{{ description }}</p>
      </div>
      <!-- Preview image -->
      <div class="m-5 p-8 flex flex-col justify-center ml-auto">
        <i class="fas fa-project-diagram fa-5x text-blue-900"></i>
      </div>
    </router-link>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "ProjectPreview",

  props: {
    name: String,
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
