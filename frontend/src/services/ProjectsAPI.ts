import { ProjectMember } from "@/model/ProjectMember";
import axios, { AxiosResponse } from "axios";
import { Project } from "../model/Project";

export class ProjectsAPI {
  public static readonly HOST = "https://localhost:5001";

  public static loadProjects(id: string): Promise<AxiosResponse> {
    // const access_token = token;

    return axios.get(ProjectsAPI.HOST + "/api/project/" + id);
  }

  public static loadClasses(id: number): Promise<AxiosResponse> {
    // Load classes of a project

    return axios.get(ProjectsAPI.HOST + "/api/classes/" + id);
  }

  public static deleteProject(id: number): Promise<AxiosResponse> {
    // Delete project

    return axios.delete(ProjectsAPI.HOST + "/api/projects/" + id);
  }

  public static createProject(project: Project): Promise<AxiosResponse> {
    return axios.post(ProjectsAPI.HOST + "/api/projects", {
      name: project.name,
      date: project.date,
      description: project.description,
      idUser: project.idUser,
      classes: [],
      models: [],
    });
  }

  public static createClass(
    className: string,
    projectId: number
  ): Promise<AxiosResponse> {
    return axios.post(ProjectsAPI.HOST + "/api/classes", {
      name: className,
      idProject: projectId,
    });
  }

  private static async getMembers(idProject: number): Promise<ProjectMember[]> {
    let members: Array<ProjectMember> = [];
    await axios
      .get(`${ProjectsAPI.HOST}/api/members/${idProject}`)
      .then((response) => {
        members = response.data;
      })
      .catch((err) => {
        alert("Couldn't connect to API");
        console.log(err);
      });
    return members;
  }

  public static async loadMembers(idProject: number): Promise<ProjectMember[]> {
    const users: Array<ProjectMember> = [];
    const members: Array<ProjectMember> = await ProjectsAPI.getMembers(
      idProject
    );

    for (let i = 0; i < members.length; i++) {
      //   console.log("idUser: " + members[i].idUser);
      await axios
        .get(this.HOST + "/api/users/" + members[i].idUser)
        .then((response) => {
          if (response.status < 400) {
            const user: ProjectMember = response.data;
            users.push(user);
            // console.log(user);
          } else {
            console.log("USERS ERROR");
          }
        });
    }

    console.log("Users:" + users);

    return users;
  }

  public static uploadImage(
    img: Blob,
    idProject: number,
    idUser: string,
    date: string,
    onUploadProgress: (event: ProgressEvent) => void
  ): Promise<AxiosResponse> {
    const req = {
      image: img,
      date: date,
      idProject: idProject,
      idUser: idUser,
    };

    console.log(req);

    return axios.post(`${ProjectsAPI.HOST}/api/data/`, req, {
      onUploadProgress,
    });
  }

  public static getImages(idProject: number): Promise<AxiosResponse> {
    return axios.get(`${ProjectsAPI.HOST}/api/data/${idProject}`);
  }
}
