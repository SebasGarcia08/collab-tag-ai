import axios from 'axios';

export class ProjectLoaderJS{

    HOST = "https://localhost:5001";

    constructor(){
        //
    }

    async getMembers(idProject) {
        let member = null;
        await axios.get(this.HOST+'/api/members/'+idProject).then((response) => {
            if(response.status < 400){
                console.log("RESPONSE");
                console.log(response);
                console.log(response.data);
                member = response.data;
            }else{
                console.log("MEMBERS ERROR");
            }
        });
        return member;
    }


    async loadMembers(idProject) {
        
        // Load members of a project
                
        let members = await this.getMembers(idProject);

        console.log("response members: " + members);

        
        let users = [];
        for (var i=0; i<members.length; i++) {
            let user = null;
            console.log("idUser: "+members[i].idUser);
            await axios.get(this.HOST+'/api/users/'+members[i].idUser).then((response) => {
                if(response.status < 400){
                    user = response.data;
                    console.log(user);
                }else{
                    console.log("USERS ERROR");
                }
            })
            users.push(user);
        }

        console.log("Users:" + users);
        
        return users;
    }
}

//export default new ProjectLoaderJS();