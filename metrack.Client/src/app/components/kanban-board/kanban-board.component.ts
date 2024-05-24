import {ChangeDetectionStrategy, ChangeDetectorRef, Component, DestroyRef, inject, OnInit} from "@angular/core";
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
import {TaskTypeEnum} from "../../enums/task-type.enum";
import {UserModel} from "../../models/user.model";
import {TaskService} from "../../services/task.service";
import {ITaskStage} from "../../interfaces/task-stage.interface";
import {map, Observable} from "rxjs";
import {AsyncPipe} from "@angular/common";
import {takeUntilDestroyed} from "@angular/core/rxjs-interop";

@Component({
    selector: 'app-kanban-board',
    templateUrl: './kanban-board.component.html',
    styleUrls: ['./kanban-board.component.scss'],
    standalone: true,
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [
        CdkDropList,
        CdkDrag,
        MatCard,
        KanbanTaskComponent,
        CdkDropListGroup,
        AsyncPipe,
    ],
})
export class KanbanBoardComponent implements OnInit {
    // public stages$: Observable<ITaskStage[]>;

    private _destroyRef: DestroyRef = inject(DestroyRef);

    constructor(private _taskService: TaskService, private _cdr: ChangeDetectorRef) { }

    public ngOnInit(): void {
        this._taskService.fetchTaskStages()
            .pipe(
                takeUntilDestroyed(this._destroyRef)
            )
            .subscribe({
                next: (stages) => {
                    for (let stage of stages) {
                        switch (stage.title) {
                            case 'Открыто':
                                this.open = [...stage.issues];
                                this._cdr.markForCheck();
                                break;
                            case 'В разработке':
                                this.process = [...stage.issues];
                                break;
                            case 'Подлежит проверке':
                                this.review = [...stage.issues];
                                break;
                            case 'Готово':
                                this.done = [...stage.issues];
                                break;
                        }
                    }
                }
            })
    }

    open: TaskModel[] = [];
    process: TaskModel[] = [];
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
