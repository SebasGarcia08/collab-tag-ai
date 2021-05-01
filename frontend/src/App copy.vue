<template>
  <div id="app">
    <!-- <TaggingPanel /> -->
    <!-- <Projects /> -->
    <!-- <router-view></router-view> -->
    <TestSideBar />
  </div>
</template>

<script lang="ts">
import Vue from "vue"
// import TaggingPanel from "./components/TaggingPanel.vue"
// import ProjectPreview from "./components/ProjectPreview.vue"
import TestSideBar from "./components/TestSideBar.vue"
import Projects from "./views/Projects.vue";
interface Item {
  text: string,
  route: string,
  icon: string
}
export default Vue.extend({
  name: "App",

  components: {
    // TaggingPanel
    // Projects,
    TestSideBar
  },

  // data: () => ({
  //   buttons: Item[]
  // }),
  // created (): void {
  //   this.buttons = [
  //     {
  //       text: 'Projects',
  //       route: '/Projects',
  //       icon: 'fas fa-stream fa-2x'
  //     }
  //   ]
  // }
});
</script>