export interface Task{
  Id: string,
  Name: string,
  Description : string,
  Visibility : Visibility,
  DueDate : Date | undefined,
  IsFinished: boolean,
  FinishedDate : Date | undefined
}

enum Visibility{
  Public = 0,
  Private = 1
}