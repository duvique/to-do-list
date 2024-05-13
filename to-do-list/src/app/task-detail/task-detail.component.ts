import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
  output,
} from '@angular/core';
import { TaskService } from '../services/task.service';
import { Task } from '../interfaces/Tasks/task';
import { CommonModule, NgIf } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Visibility } from '../interfaces/Tasks/EVisibility';

@Component({
  selector: 'app-task-detail',
  standalone: true,
  imports: [
    NgIf,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatCheckboxModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    CommonModule,
  ],
  templateUrl: './task-detail.component.html',
  styleUrl: './task-detail.component.css',
})
export class TaskDetailComponent {
  private _taskId: string | null = null;
  visibilities: { label: string; value: Visibility }[] = [
    { value: Visibility.Public, label: 'Public' },
    { value: Visibility.Private, label: 'Private' },
  ];

  _createTask: boolean = false;
  task?: Task;
  taskForm: FormGroup;
  blockFinishButton: boolean = false;

  @Input() set taskId(value: string | null) {
    this._taskId = value;
    this.handleChangeTaskId();
  }

  @Input() set createTask(value: boolean) {
    this._createTask = value;
    console.log(this._createTask);
  }

  @Output() refreshTaskList = new EventEmitter<boolean>();

  constructor(private taskService: TaskService, private fb: FormBuilder) {
    this.taskForm = this.fb.group({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      visibility: new FormControl('', [Validators.required]),
      dueDate: new FormControl(new Date()),
      finishedOnDate: new FormControl({ disabled: true }),
    });
  }

  handleChangeTaskId() {
    if (this._taskId == null) return;

    this.taskService.getTaskById(this._taskId!).subscribe({
      next: (response) => {
        this.task = response;
      },
      error: (error) => {
        console.log({ error });
      },
      complete: () => {
        this.taskForm.patchValue({
          name: this.task?.name,
          description: this.task?.description,
          visibility: this.task?.visibility,
          dueDate: this.task?.dueDate,
          finished: this.task?.isFinished,
          finishedOnDate: this.task?.finishedDate,
        });
      },
    });
  }

  finishTask() {
    if (this._taskId == null) return;
    this.blockFinishButton = true;
    this.taskService.finishTask(this._taskId!).subscribe({
      next: (response) => {
        this.taskId == null;
      },
      error: (error) => {
        console.log({ error });
        this.blockFinishButton = false;
      },
      complete: () => {
        this.blockFinishButton = false;
      },
    });
  }

  deleteTask() {
    if (this._taskId == null) return;

    this.taskService.deleteTask(this._taskId!).subscribe({
      next: (response) => {
        if (response) this.refreshTaskList.emit(true);
      },
      error: (error) => {
        console.log({ error });
      },
      complete: () => {
        this.blockFinishButton = false;
      },
    });
  }

  onSubmit() {
    if (this.taskForm.valid) {
    }
  }
}
