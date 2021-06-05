import axios from "axios";
import Vue from "vue";
import { Project } from "../model/Project";

export class ProjectsAPI {
  public static readonly HOST = "https://localhost:5001";

  public static loadProjects(id: string) {
    // const access_token = token;

    return axios.get(ProjectsAPI.HOST + "/api/project/" + id);
  }

  public static loadMembers(id: number) {
    // Load members of a project

    return axios.get(ProjectsAPI.HOST + "/api/members/" + id);
  }

  public static loadClasses(id: number) {
    // Load classes of a project

    return axios.get(ProjectsAPI.HOST + "/api/classes/" + id);
  }

  public static deleteProject(id: number) {
    // Delete project

    return axios.delete(ProjectsAPI.HOST + "/api/projects/" + id);
  }

  // public loadMembers(id: number) {

  //     // Load members of a project

  //     axios.get(this.HOST+'/api/members/'+id).then(response => {
  //         // return response.data;
  //         console.log("memberssss: " + response);
  //         this.members = response.data;
  //     });

  //     console.log("response members: "+this.members);

  //     // Load the users given the members of the project

  //     this.members.forEach(member => {
  //         const u = axios.get(this.HOST+'api/users/'+member.idUser).then(response => {
  //             // return response.data;
  //             const new_user = response.data;
  //             console.log("new user: " + new_user);
  //             this.users.push(new_user);
  //             // return new_user;
  //         })

  //         // this.users.push(u);

  //     });

  //     console.log("Users:" + this.users);

  //     return this.users;
  // }

  public static createProject(project: Project) {
    return axios.post(ProjectsAPI.HOST + "/api/projects", {
      name: project.name,
      date: project.date,
      description: project.description,
      idUser: project.idUser,
      classes: [],
      models: [],
    });
  }

  public static createClass(className: string, projectId: number) {
    return axios.post(ProjectsAPI.HOST + "/api/classes", {
      name: className,
      idProject: projectId,
    });
  }

  // return axios.get('https://localhost:5001/api/project/1', {
  //         headers: {
  //           'Authorization': `token ${access_token}`
  //         }
  //     });
}
