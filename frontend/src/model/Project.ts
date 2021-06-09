import { ImageClass } from "./ImageClass";
import { Models } from "./Models";

export class Project {
  public idProject: number;
  public name: string;
  public date: string;
  public description: string;
  public idUser: string;
  public classes: Array<ImageClass>;
  public models: Array<Models>;

  constructor(name: string, date: string, description: string, idUser: string) {
    this.idProject = -1;
    this.name = name;
    this.date = date;
    this.description = description;
    this.idUser = idUser;
    this.classes = [];
    this.models = [];
  }

  getIdProject() {
    return this.idProject;
  }
}
