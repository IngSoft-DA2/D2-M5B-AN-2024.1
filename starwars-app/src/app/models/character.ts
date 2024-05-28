export class Character {
    id: number;
    name: string;
    description: string;
    imageurl: string;

    constructor(id: number, name: string, description: string, imageurl: string) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.imageurl = imageurl;
    }
}