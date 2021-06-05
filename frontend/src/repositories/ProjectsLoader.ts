import axios from 'axios';
import Vue from "vue";
import { Project } from "../model/Project";
import { ProjectMember } from "../model/ProjectMember";
import { User } from "../model/User";

export class ProjectsLoader {

    HOST = "https://localhost:5001";

    public loadProjects(id: string) {
        // const access_token = token;

        return axios.get(this.HOST+'/api/project/'+id);
    }

    members: Array<ProjectMember> = [];
    users: Array<User> = [];

    public loadMembers(id: number) {
        //Load members of a project
            
        return axios.get(this.HOST+'/api/members/'+id);
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

    public createProject(project: Project){

        return axios.post(this.HOST+'/api/projects', {
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