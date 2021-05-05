import axios from 'axios';
export class ProjectsLoader {

    public loadProjects(id: number) {
        return axios.get('https://localhost:5001/api/project/1');
    }
}