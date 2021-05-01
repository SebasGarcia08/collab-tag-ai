<template>
  <div id="app">
    <!-- <TaggingPanel /> -->
    <!-- <Projects /> -->
    <!-- <router-view></router-view> -->
    <TestSideBar :buttons="buttonsarr"/>
  </div>
</template>

<script lang="ts">
import Vue from "vue"
// import TaggingPanel from "./components/TaggingPanel.vue"
// import ProjectPreview from "./components/ProjectPreview.vue"
import TestSideBar from "./components/TestSideBar.vue"
import Projects from "./views/Projects.vue";

import Component from 'vue-class-component'
class Item {
  public text: string
  public route: string
  public icon: string

  constructor(text: string, route: string, icon: string) {
    this.text = text;
    this.route = route;
    this.icon = icon;
  }
}
// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    TestSideBar
  },
})
export default class App extends Vue {
  // Initial data can be declared as instance properties

  buttonsarr: Array<Item> = [
    {
      text: 'Projects',
      route: '/Projects',
      icon: 'fas fa-stream fa-2x'
    },
    {
      text: 'Account',
      route: '/Projects',
      icon: 'fas fa-cogs fa-2x'
    }
  ]
}
</script>