import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TasksComponent } from './tasks/tasks.component';

export const routes: Routes = [
  { path: "home", component: HomeComponent},
  { path: "tasks", component: TasksComponent},
  { path: "", redirectTo: "/home", pathMatch: "full"}

];
