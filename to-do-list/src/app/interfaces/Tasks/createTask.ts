import { Visibility } from './EVisibility';

export interface CreateTask {
  name: string;
  description: string;
  dueDate?: Date;
  visibility: Visibility;
}
