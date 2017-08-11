import { Component, OnInit } from '@angular/core';
import { ToDoItem } from './toDoItem.model';
import { ToDoService } from './toDo.service';

@Component({
    selector: 'list',
    templateUrl: './list.component.html',
    styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
    items = new Array<ToDoItem>();
    text: string;
    currentItem: ToDoItem;

    editId: string;
    editVal: string;
    editing: boolean;

    constructor(private toDoService: ToDoService) { };
    
    ngOnInit() {
        this.toDoService.getItems()
            .then(items => this.items = items);
    }

    onSubmit(text: string) {
        this.toDoService.addItem(new ToDoItem(text))
            .then(item => this.items.push(item));
    }

    onDelete(id: string) {
        this.toDoService.deleteItem(id);
        this.items = this.items.filter(i => i.id !== id);
    }

    onCheck(item: ToDoItem, isChecked: boolean) {
        item.completed = isChecked;
        this.toDoService.updateItem(item);
    }

    onEdit(item: ToDoItem) {
        this.currentItem = item;
        this.editing = true;
    }

    exitEdit(id: string) {
        this.editing = false;
        this.currentItem = null;
    }
}
