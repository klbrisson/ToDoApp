import { Component } from '@angular/core';
import { ToDoService } from '../list/toDo.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [ToDoService]
})
export class AppComponent {
}
