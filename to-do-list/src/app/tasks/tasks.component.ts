import { Component, OnInit } from '@angular/core';
import { TaskService } from '../services/task.service';
import { Task } from '../interfaces/Tasks/task';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { TaskDetailComponent } from '../task-detail/task-detail.component';
import { NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';

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
    MatProgressSpinnerModule,
    MatTooltipModule,
  ],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css',
})
export class TasksComponent implements OnInit {
  createTask: boolean = false;
  tasks?: Task[];
  idTaskDetail: string | null = null;

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.getAllTasks();
  }

  getNowDate(): Date {
    return new Date();
  }

  refreshTaskList(hideTaskForm: boolean) {
    this.createTask = false;
    if (hideTaskForm) this.idTaskDetail = null;
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
    this.createTask = false;
    this.idTaskDetail =
      this.idTaskDetail == null ? id : id == this.idTaskDetail ? null : id;
  }

  handleAddTask() {
    this.createTask = !this.createTask;
    if (this.createTask) this.idTaskDetail = null;
  }

  handleCreatedTask(id: string) {
    this.createTask = false;
    this.idTaskDetail = id;
  }

  getIconToolTip(task: Task): { tooltip: string; iconColor: string } {
    if (task.isFinished)
      return { tooltip: 'Task finished', iconColor: 'green' };

    if (task.dueDate) {
      const convertedDueDate = new Date(task.dueDate);

      if (task.dueDate < this.getNowDate())
        return { tooltip: 'Overdue task', iconColor: 'red' };

      if (convertedDueDate.getDate() == this.getNowDate().getDate())
        return { tooltip: 'The task is due today', iconColor: 'yellow' };

      const daysToExpire =
        convertedDueDate.getDate() - this.getNowDate().getDate();

      return {
        tooltip: `The task must be finished in ${daysToExpire} day(s)`,
        iconColor: 'green',
      };
    }

    return { tooltip: 'The task isn`t finished yet', iconColor: 'gray' };
  }
}
