<template>
  <nav
    class="navbar group-foo fized w-20 h-screen bg-blue-400 hover:w-56 duration-200 ease-in"
  >
    <ul class="navbar-nav p-0 m-0 h-screen flex flex-col items-center">
      <div class="w-full" v-for="(button, idx) in buttons" :key="idx">
        <SideBarButton
          :text="button.text"
          :route="button.route"
          :icon="button.icon"
        />
      </div>

      <!-- Log out button -->
      <li class="nav-item w-full mt-auto group-bar">
        <a
          @click="logout"
          class="nav-link w-full flex items-center h-20 no-underline duration-200 hover:bg-blue-600"
        >
          <!-- Insert icon/image here -->
          <i
            class="fas fa-sign-out-alt fa-2x min-w-8 m-6 text-blue-900 group-bar-hover:text-white"
          ></i>
          <span
            class="link-text hidden m-4 group-foo-hover:block font-bold text-blue-900 text-xl group-bar-hover:text-white"
          >
            Logout
          </span>
        </a>
      </li>
    </ul>
  </nav>
</template>

<script lang="ts">
import Vue from "vue";
import SideBarButton from "./SideBarButton.vue";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { Item } from "../model/Item";
import firebase from "firebase/app";

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {
    SideBarButton,
  },
})
export default class SideBar extends Vue {
  // Initial data can be declared as instance properties

  @Prop() buttons!: Array<Item>;

  logout() {
    firebase
      .auth()
      .signOut()
      .then(() => this.$router.replace("Login"));
  }
}
</script>
