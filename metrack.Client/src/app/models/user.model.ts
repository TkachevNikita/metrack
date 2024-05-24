import {ITask} from "../interfaces/task.interface";
import {IUser} from "../interfaces/user.interface";
import {TaskModel} from "./task.model";

export class UserModel {
    public readonly id: string;
    public readonly name: string;
    public readonly photo: string;

    constructor(user: IUser) {
        this.id = user.id;
        this.name = user.name;
        this.photo = user.photo;
    }
}
