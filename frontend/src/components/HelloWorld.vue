<template>
  <div class="container mx-auto p-2">
    <div class="max-w-sm mx-auto bg-white px-5 py10 rounded shadow-xl">
      <div class="text-center mb-9">
        <h1 class="font-bold text-2xl"> Login </h1>
      </div>

      <form action="#">
        <div class="mt-5">
          <label>Username:</label>
          <input type="text" name="" id="">
        </div>
      </form>
    </div>
  </div>
</template>


<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "HelloWorld",
  props: {
    msg: String
  }
});
</script>
