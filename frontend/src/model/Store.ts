import Vue from 'vue';
import { Project } from "../model/Project";

const store = {};

export default Vue.observable({
    currentUserId: "",
    currentProject: new Project("", "", "", ""),
});

// export class Store {

//   public currentProjectId: number;
//   public currentUserId: string;

//   constructor() {
//     this.currentUserId = "";
//     this.currentProjectId = -1;
//   }
// }