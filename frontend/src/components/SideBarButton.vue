<template>
  <li class="nav-item w-full group-bar">
    <router-link
      :to="route"
      class="nav-link flex items-center h-20 no-underline duration-200 hover:bg-blue-600"
    >
      <!-- Insert icon/image here -->
      <i
        :class="icon"
        class="w-8 m-6 text-blue-900 group-bar-hover:text-white"
      ></i>
      <span
        class="link-text hidden m-4 group-foo-hover:block font-bold text-blue-900 text-xl group-bar-hover:text-white"
        >{{ text }}</span
      >
    </router-link>
  </li>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  components: {},
  props: {
    text: String,
    route: String,
    icon: String,
    selected: {
      type: Boolean,
      default: false,
    },
  },
});
</script>
