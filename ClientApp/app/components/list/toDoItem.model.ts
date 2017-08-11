export class ToDoItem {
    id: string;

    constructor(public text: string, public completed: boolean = false) { }
}