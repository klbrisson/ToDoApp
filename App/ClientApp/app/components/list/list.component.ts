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

    constructor(private toDoService: ToDoService) { }
    
    ngOnInit() {
        this.toDoService.getItems()
            .then(items => this.items = items);
    }

    onSubmit(text: string) {
        this.toDoService.addItem(new ToDoItem(text))
            .then(item => this.items.push(item));
    }

    onDelete(item: ToDoItem) {
        this.items = this.items.filter(i => i.id !== item.id);
    }

}
