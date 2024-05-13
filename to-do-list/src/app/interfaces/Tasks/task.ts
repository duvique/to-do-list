import { Visibility } from './EVisibility';

export interface Task {
  id: string;
  name: string;
  description: string;
  visibility: Visibility;
  dueDate: Date | undefined;
  isFinished: boolean;
  finishedDate: Date | undefined;
}
