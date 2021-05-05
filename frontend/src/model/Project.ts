export class Project {
    public name: string;
    public date: string;
    public description: string;
  
    constructor(name: string, date: string, description: string) {
      this.name = name;
      this.date = date;
      this.description = description;
    }
  }