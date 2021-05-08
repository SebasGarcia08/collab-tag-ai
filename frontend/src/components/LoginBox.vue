<template>
    <div
      class="mx-auto w-1/4 mt-4 p-8 border rounded-xl border-gray-300 shadow-md"
    >
      <form action="">
        <div>
          <label class="text-m font-bold text-gray-600 block">
            Username:
          </label>
          <input
            type="text"
            class="block w-full p-2 rounded border-2 border-solid border-gray-500"
          />
        </div>
        <div class="mt-5">
          <label class="text-m font-bold text-gray-600 block">
            Password:
          </label>
          <input
            type="password"
            class="block w-full p-2 rounded border-2 border-solid border-gray-500"
          />
        </div>
        <div class="mt-10 flex justify-center">
          <button
            class="py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center"
          >
            Login
          </button>
        </div>
        <div class="mt-5 flex justify-center">
          <p class="pr-1">Don't have an account?</p>
          <router-link to="/Register" class="font-medium text-blue-500">create one</router-link>
        </div>
      </form>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "LoginBox",

  data: () => ({}),
});
</script>
