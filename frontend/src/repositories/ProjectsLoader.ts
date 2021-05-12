import axios from 'axios';
import Vue from "vue";

export class ProjectsLoader {

    public loadProjects(id: number, token: string) {

        return axios.get('https://localhost:5001/api/project/1', {
            // headers: {
            //   'Authorization': `token ${access_token}`
            // }
        });
    }
}