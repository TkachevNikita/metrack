import {TaskTypeEnum} from "../enums/task-type.enum";
import {IUser} from "./user.interface";
import {UserModel} from "../models/user.model";

export interface ITask {
    id: string;
    title: string;
    period: string;
    type: number;
    status: number;
    owner?: UserModel;
}


