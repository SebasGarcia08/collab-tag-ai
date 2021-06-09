<template>
  <div class="about">
    <h1>This is an about page</h1>
    <Test greeting="Work" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Test from "@/components/Test.vue";

@Component({
  components: {
    Test,
  },
})
export default class About extends Vue {}
</script>
