export class User {
    idUser: string;
    username: string;
    email: string;
    name: string;
    lastName: string;

    constructor(idUser: string, username: string, email: string, name: string, lastName: string) {
        this.idUser = idUser;
        this.username = username;
        this.email = email;
        this.name = name;
        this.lastName = lastName;
    }
}