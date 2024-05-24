import {TaskModel} from "../models/task.model";

export interface ITaskStage {
    id: string;
    title: string;
    issues: TaskModel[]
}
