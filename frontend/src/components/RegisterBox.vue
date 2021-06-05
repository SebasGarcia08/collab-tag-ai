<template>
  <div class="min-h-screen flex flex-col justify-center">
    <div class="max-w-nd mx-auto w-1/4">
      <div class="absolute">
        <p
          class="ml-8 px-3 border rounded-xl p-2 bg-blue-500 text-white font-bold"
        >
          Create account
        </p>
      </div>

      <form
        @submit.prevent="createAccount"
        class="space-y-5 p-8 mt-5 border rounded-xl border-gray-300 shadow-md"
      >
        <!-- Email field -->
        <div class="pt-3">
          <label class="text-m font-bold text-gray-600 block"> Email: </label>
          <input
            type="text"
            v-model="email"
            name="email"
            placeholder="Add email"
            class="block w-full p-2 rounded border-2 border-solid border-gray-500"
          />
        </div>
        <!-- Username field -->
        <div class="">
          <label class="text-m font-bold text-gray-600 block">
            Username:
          </label>
          <input
            type="text"
            name="username"
            placeholder="Add username"
            class="block w-full p-2 rounded border-2 border-solid border-gray-500"
          />
        </div>
        <!-- Password field -->
        <div class="">
          <label class="text-m font-bold text-gray-600 block">
            Password:
          </label>
          <input
            type="password"
            v-model="password"
            name="password"
            placeholder="Add password"
            class="block w-full p-2 rounded border-2 border-solid border-gray-500"
          />
        </div>
        <div class="flex justify-center pt-3">
          <button
            class="py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center"
          >
            Register
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import firebase from "firebase/app";
import "firebase/auth";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {},
})
export default class RegisterBox extends Vue {
  // Initial data can be declared as instance properties

  email = "";
  password = "";

  createAccount() {
    firebase
      .auth()
      .createUserWithEmailAndPassword(this.email, this.password)
      .then((userCredential) => {
        // Signed in
        var user = userCredential.user;
        this.$router.replace("Projects");
        // ...
        (error) => console.error(error);
      });
  }
}
</script>
