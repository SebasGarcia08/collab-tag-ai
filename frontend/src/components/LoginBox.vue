<template>
  <div class="mx-auto w-1/4">
    <form
      @submit.prevent="login"
      class="mt-4 p-8 border rounded-xl border-gray-300 shadow-md"
    >
      <!-- Username field -->
      <div>
        <label class="text-m font-bold text-gray-600 block"> Username: </label>
        <input
          type="text"
          name="username"
          v-model="email"
          class="block w-full p-2 rounded border-2 border-solid border-gray-500"
        />
      </div>
      <!-- Password field -->
      <div class="mt-5">
        <label class="text-m font-bold text-gray-600 block"> Password: </label>
        <input
          type="password"
          name="password"
          v-model="password"
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
        <router-link to="/register" class="font-medium text-blue-500"
          >create one</router-link
        >
      </div>
    </form>
    <!-- <pre>
      {{ $data }}
    </pre> -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import firebase from "firebase/app";
import "firebase/auth";
import store from "../model/Store";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {},
})
export default class LoginBox extends Vue {
  // Initial data can be declared as instance properties

  email = "";
  password = "";

  login() {
    firebase
      .auth()
      .signInWithEmailAndPassword(this.email, this.password)
      .then((userCredential) => {
        // Signed in
        if (userCredential.user != null) {
          store.currentUserId = userCredential.user.uid;
          console.log(store.currentUserId);
          // this.$root.$data.store.currentUserId = userCredential.user.uid;
          // console.log(this.$root.$data);
        }

        this.$router.replace("projects");
        // ...
        (error) => console.error(error);
      });
  }
}
</script>
