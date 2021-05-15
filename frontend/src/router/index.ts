import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Login from "../views/Login.vue";
import Projects from "../views/ProjectsList.vue";
import Inference from "../views/Inference.vue";
import Register from "../views/Register.vue";
import firebase from "firebase/app";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "*",
    redirect: "/",
  },
  {
    path: "/",
    name: "Login",
    component: Login,
  },
  {
    path: "/Projects",
    name: "Projects",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: Projects,
    meta: {
      authenticated: true,
    }
  },
  {
    path: "/Inference",
    name: "Inference",
    component: Inference,
    meta: {
      authenticated: true,
    }
  },
  {
    path: "/Register",
    name: "Register",
    component: Register,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;

router.beforeEach((to, from, next) => {
  const user = firebase.auth().currentUser;
  console.log(user);
  const authorization = to.matched.some(record => record.meta.authenticated);

  if (authorization && !user) {
    next('Login');
  } else if (!authorization && user) {
    next('Projects');
  } else {
    next();
  }
})
