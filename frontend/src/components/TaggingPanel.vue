<template>
  <div class="container min-h-screen flex flex-col justify-center item-center">
    <div
      class="max-w-nd mx-auto shadow-md bg-gray-50 flex flex-col w-1/3 border border-black rounded-xl"
    >
      <div>
        <p class="text-right mt-5 mr-5">0/0</p>
      </div>
      <!-- Uploaded image -->
      <div
        class="h-96 mb-5 mx-5 flex items-center justify-center border border-blue-900 rounded-md"
      >
        <i class="far fa-image fa-10x text-blue-900"></i>
      </div>
      <div class="flex flex-col items-center mb-5 space-y-5">
        <button
          class="w-1/4 bg-blue-500 hover:bg-blue-600 border rounded font-medium text-white"
        >
          Class 1
        </button>
        <button
          class="w-1/4 bg-blue-500 hover:bg-blue-600 border rounded font-medium text-white"
        >
          Class 2
        </button>
        <button
          class="w-1/4 bg-blue-500 hover:bg-blue-600 border rounded font-medium text-white"
        >
          Class 3
        </button>
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
