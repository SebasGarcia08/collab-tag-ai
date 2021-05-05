<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
    <Test greeting="Greetings! :D" />
    <Button />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src
import Test from "@/components/Test.vue";

@Component({
  components: {
    HelloWorld,
    Test,
  },
})
export default class Home extends Vue {}
</script>
