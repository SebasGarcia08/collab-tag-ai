import axios from 'axios';
import Vue from "vue";

export class ProjectsLoader {

    public loadProjects(id: number) {
        // const access_token = token;

        return axios.get('https://localhost:5001/api/project/1');
    }

    // return axios.get('https://localhost:5001/api/project/1', {
    //         headers: {
    //           'Authorization': `token ${access_token}`
    //         }
    //     });
}