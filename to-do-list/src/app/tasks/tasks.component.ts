import { Component, OnInit } from '@angular/core';
import { TaskService } from '../services/task.service';
import { Task } from '../interfaces/Tasks/task';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { TaskDetailComponent } from '../task-detail/task-detail.component';
import { NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [
    MatCheckboxModule,
    MatIconModule,
    TaskDetailComponent,
    NgIf,
    MatButtonModule,
    CommonModule,
  ],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css',
})
export class TasksComponent implements OnInit {
  createTask: boolean = false;
  tasks: Task[] = [];
  idTaskDetail: string | null = 'ad5d181e-4e37-4f37-af0c-b18014c18654';
  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.getAllTasks();
  }

  refreshTaskList() {
    this.createTask = false;
    this.idTaskDetail = null;
    this.getAllTasks();
  }
  getAllTasks() {
    this.taskService.getTasks().subscribe({
      next: (response) => {
        this.tasks = response;
        console.log({ response });
      },
    });
  }

  showTaskDetail(id: string) {
    this.idTaskDetail =
      this.idTaskDetail == null ? id : id == this.idTaskDetail ? null : id;
  }

  showCreateTask() {
    this.createTask = true;
  }
}
