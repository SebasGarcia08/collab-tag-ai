

export class Item {
    public text: string
    public route: string
    public icon: string
  
    constructor(text: string, route: string, icon: string) {
      this.text = text;
      this.route = route;
      this.icon = icon;
    }
  }