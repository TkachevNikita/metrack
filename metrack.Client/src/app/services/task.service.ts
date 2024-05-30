import {Injectable} from "@angular/core";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Observable} from "rxjs";
import {ITaskStage} from "../interfaces/task-stage.interface";
import {environment} from "../../environments/environment";

@Injectable()
export class TaskService {
    constructor(private _http: HttpClient) { }

    public fetchTaskStages(): Observable<ITaskStage[]> {
        return this._http.get<ITaskStage[]>(`http://51.250.13.119/api/IssueStages`);
    }

    public deleteTask(id: string) {
        return this._http.delete(`http://51.250.13.119/api/Issues/${id}`);
    }
}
