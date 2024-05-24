import {TaskTypeEnum} from "../enums/task-type.enum";
import {ITask} from "../interfaces/task.interface";
import {UserModel} from "./user.model";
import {TaskStatusEnum} from "../enums/task-status.enum";

export class TaskModel {
    public readonly id: string;
    public readonly title: string;
    public readonly period: string;
    public readonly type: TaskTypeEnum;
    public readonly owner?: UserModel;

    constructor(task: ITask) {
        this.id = task.id;
        this.title = task.title;
        this.period = task.period;
        this.type = this.getType(task.type);
        this.owner = task.owner;
    }

    private getType(status: number): TaskTypeEnum {
        switch (status) {
            case 0:
                return TaskTypeEnum.slight;
            case 1:
                return TaskTypeEnum.simple;
            case 2:
                return TaskTypeEnum.serious;
            default:
                return TaskTypeEnum.slight;
        }
    }

    private getStatus(status: number): TaskStatusEnum {
        switch (status) {
            case 0:
                return TaskStatusEnum.open;
            case 1:
                return TaskStatusEnum.progress;
            case 2:
                return TaskStatusEnum.review;
            case 3:
                return TaskStatusEnum.done;
            default:
                return TaskStatusEnum.open;
        }
    }
}
