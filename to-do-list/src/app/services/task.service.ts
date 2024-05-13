import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Task } from '../interfaces/Tasks/task';
import { Observable } from 'rxjs';
import { CreateTask } from '../interfaces/Tasks/createTask';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  apiUrl = `${environment.baseApiUrl}/task`;

  constructor(private httpClient: HttpClient) {}

  getTasks(): Observable<Task[]> {
    return this.httpClient.get<Task[]>(this.apiUrl);
  }

  getTaskById(id: string): Observable<Task> {
    return this.httpClient.get<Task>(`${this.apiUrl}/${id}`);
  }

  createTask(task: CreateTask): Observable<string> {
    return this.httpClient.post<string>(`${this.apiUrl}`, task);
  }

  finishTask(id: string): Observable<string> {
    return this.httpClient.put<string>(`${this.apiUrl}/finish`, { taskId: id });
  }

  deleteTask(id: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
