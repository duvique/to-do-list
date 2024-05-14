import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TasksComponent } from './tasks/tasks.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'tasks', component: TasksComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];

interface NavRoute {
  title: string;
  redirectTo: string;
  icon: string;
}
export const navRoutes: NavRoute[] = [
  { title: 'Home', redirectTo: '/home', icon: 'home' },
  { title: 'Tasks', redirectTo: '/tasks', icon: 'task' },
];
