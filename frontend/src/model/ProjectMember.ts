export class ProjectMember {
    idUser: string;
    idProject: number;
    date: string;

    constructor(idUser: string, idProject: number, date: string) {
        this.idUser = idUser;
        this.idProject = idProject;
        this.date = date
    }
}