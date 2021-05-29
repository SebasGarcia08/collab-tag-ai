<template>
  <div id="app">
    <router-view></router-view>
    <!-- <ProjectFull /> -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";

import Component from "vue-class-component";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    //
  },
})

export default class App extends Vue {
  // Initial data can be declared as instance properties


}
</script>
