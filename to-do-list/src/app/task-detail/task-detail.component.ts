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
import { ToastrService } from 'ngx-toastr';

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

  startDueTime: Date = new Date();
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
  }

  @Output() refreshTaskList = new EventEmitter<boolean>();
  @Output() createdTaskId = new EventEmitter<string>();

  constructor(
    private taskService: TaskService,
    private fb: FormBuilder,
    private toast: ToastrService
  ) {
    this.taskForm = this.fb.group({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      visibility: new FormControl('', [Validators.required]),
      dueDate: new FormControl(''),
      isFinished: new FormControl(''),
      finishedOnDate: new FormControl({ value: new Date(), disabled: true }),
    });
  }

  handleChangeTaskId() {
    if (this._taskId == null) {
      this.task = undefined;
      this.taskForm.reset();
      this.taskForm.enable();
      return;
    }

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
          isFinished: this.task?.isFinished,
          finishedOnDate: this.task?.finishedDate,
        });

        this.taskForm.disable();
      },
    });
  }

  finishTask() {
    if (this._taskId == null) return;

    this.blockFinishButton = true;
    this.taskService.finishTask(this._taskId!).subscribe({
      next: (response) => {
        if (response) {
          this.toast.success('Task finished!');
          this.refreshTaskList.emit(false);
          this.handleChangeTaskId();
        }
      },
      error: (error) => {
        this.toast.error('An error ocurred. Try again later!');
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
        if (response) {
          this.toast.success('Task deleted!');
          this.refreshTaskList.emit(true);
        }
      },
      error: (error) => {
        this.toast.error('An error ocurred. Try again later!');
      },
    });
  }

  onSubmit() {
    if (this.taskForm.valid) {
      const { name, description, dueDate, visibility } = this.taskForm.value;
      this.taskService
        .createTask({
          name,
          description,
          dueDate,
          visibility,
        })
        .subscribe({
          next: (response) => {
            this.toast.success('Task created :)');
            this.refreshTaskList.emit(true);
            this.createdTaskId.emit(response);
          },
          error: (error) => {
            this.toast.error('An error ocurred. Try again later!');
          },
        });
    }
  }
}
