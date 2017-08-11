import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ToDoItem } from './toDoItem.model';
import { ToDoService } from './toDo.service';

@Component({
    selector: 'item',
    templateUrl: './item.component.html',
    styleUrls: ['./item.component.css']
})
export class ItemComponent {
    @Input() item: ToDoItem;
    @Output() deleteItem = new EventEmitter<ToDoItem>();
    editing: boolean;

    constructor(private toDoService: ToDoService) { }

    onDelete() {
        this.toDoService.deleteItem(this.item.id);
        this.deleteItem.emit(this.item);
    }

    onCheck(isChecked: boolean) {
        this.item.completed = isChecked;
        this.toDoService.updateItem(this.item);
    }

    beginEdit() {
        this.editing = true;
    }

    endEdit(text: string) {
        this.editing = false;
        this.item.text = text;
        this.toDoService.updateItem(this.item);
    }
}
