import axios from 'axios';
import Vue from "vue";
import { Project } from "../model/Project";

export class ProjectsLoader {

    public loadProjects(id: string) {
        // const access_token = token;

        return axios.get('https://localhost:5001/api/project/'+id);
    }

    public createProject(project: Project){

        return axios.post("https://localhost:5001/api/projects", {
            "name": project.name,
            "date": project.date,
            "description": project.description,
            "idUser": project.idUser,
            "classes": [],
            "models": []
          }
        );

    }

    // return axios.get('https://localhost:5001/api/project/1', {
    //         headers: {
    //           'Authorization': `token ${access_token}`
    //         }
    //     });
}