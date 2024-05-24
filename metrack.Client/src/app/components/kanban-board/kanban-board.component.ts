import {ChangeDetectionStrategy, Component} from "@angular/core";
import {
    CdkDrag,
    CdkDragDrop,
    CdkDropList,
    CdkDropListGroup,
    moveItemInArray,
    transferArrayItem
} from "@angular/cdk/drag-drop";
import {MatCard} from "@angular/material/card";
import {KanbanTaskComponent} from "../kanban-task/kanban-task.component";
import {TaskModel} from "../../models/task.model";
import {TaskStatusEnum} from "../../enums/task-status.enum";
import {UserModel} from "../../models/user.model";

@Component({
    selector: 'app-kanban-stage',
    templateUrl: './kanban-stage.component.html',
    styleUrls: ['./kanban-stage.component.scss'],
    standalone: true,
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [
        CdkDropList,
        CdkDrag,
        MatCard,
        KanbanTaskComponent,
        CdkDropListGroup,
    ]
})
export class KanbanStageComponent {
    open: TaskModel[] = [
        new TaskModel({
            id: "2",
            title: "Карточка 1",
            period: "1234",
            status: 0,
            owner: new UserModel({
                id: '1',
                name: 'Nikita Tkachev'
            })
        }),
        new TaskModel({
            id: "3",
            title: "Карточка 2",
            period: "1234",
            status: 0,
            owner: new UserModel({
                id: '1',
                name: 'Dmitriy Klimov'
            })
        })
  ];

  process: TaskModel[] = [
      new TaskModel({
          id: "2",
          title: "Карточка 1",
          period: "1234",
          status: 0,
          owner: new UserModel({
              id: '1',
              name: 'Nikita Tkachev'
          })
      }),
  ];

  review: TaskModel[] = [];

  done: TaskModel[] = [];

  public drop(event: CdkDragDrop<TaskModel[]>): void {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }
  }
}
