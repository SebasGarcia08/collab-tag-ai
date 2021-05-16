import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Login from "../views/Login.vue";
import Projects from "../views/Projects.vue";
import Inference from "../views/Inference.vue";
import Test from "../views/Test.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
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
  },
  {
    path: "/Inference",
    name: "Inference",
    component: Inference,
  },
  {
    path:"/test",
    name: "Test",
    component: Test,
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
