import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import "./index.css";
import firebase from "firebase/app";
// import store from "@/store/index";

Vue.config.productionTip = false;

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyD8n15ZPcJ5yxuoj3v-JbNg44p_x8rYL_M",
  authDomain: "collabtag-91f03.firebaseapp.com",
  projectId: "collabtag-91f03",
  storageBucket: "collabtag-91f03.appspot.com",
  messagingSenderId: "334028380568",
  appId: "1:334028380568:web:a38a210663ae4da051b3ed",
  measurementId: "G-GPPVQ5327B",
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

firebase.auth().onAuthStateChanged(function (user) {
  new Vue({
    router,
    render: (h) => h(App),

    data() {
      return {
        //
      };
    },
  }).$mount("#app");
});
