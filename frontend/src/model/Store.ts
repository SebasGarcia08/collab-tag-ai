import Vue from "vue";
import { Project } from "../model/Project";
const store = {};

export default Vue.observable({
  // CURRENT VARIABLES
  currentUserId: "",
  currentProject: new Project("", "", "", ""),

  // GLOBAL STATE
  projects: new Array<Project>(),
  reload: false,
});

// export class Store {

//   public currentProjectId: number;
//   public currentUserId: string;

//   constructor() {
//     this.currentUserId = "";
//     this.currentProjectId = -1;
//   }
// }
