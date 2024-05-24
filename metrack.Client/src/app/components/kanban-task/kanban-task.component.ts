import {ChangeDetectionStrategy, Component, Input, OnInit} from "@angular/core";
import {
    MatCard,
    MatCardActions,
    MatCardContent,
    MatCardHeader,
    MatCardSubtitle,
    MatCardTitle
} from "@angular/material/card";
import {MatButton} from "@angular/material/button";
import {TaskModel} from "../../models/task.model";
import {CommonModule} from "@angular/common";
import {TaskTypeEnum} from "../../enums/task-type.enum";
import {TaskService} from "../../services/task.service";

@Component({
    selector: 'app-kanban-task',
    templateUrl: './kanban-task.component.html',
    styleUrls: ['./kanban-task.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        MatCard,
        MatCardHeader,
        MatCardContent,
        MatButton,
        MatCardActions,
        MatCardSubtitle,
        MatCardTitle,
        CommonModule
    ]
})
export class KanbanTaskComponent {
    @Input({
        required: true
    })
    public task!: TaskModel;

    constructor(private _taskService: TaskService) { }

    public deleteTask(id: string): void {
        this._taskService.deleteTask(id);
        this._taskService.fetchTaskStages();
    }

    public getPeriodColor(): string {
        switch(this.task.type) {
            case TaskTypeEnum.slight:
                return '#D9D9D9';
            case TaskTypeEnum.simple:
                return 'lightgreen';
            case TaskTypeEnum.serious:
                return 'red';
        }
    }
}
