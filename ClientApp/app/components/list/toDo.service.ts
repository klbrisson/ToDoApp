import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { ToDoItem } from './toDoItem.model';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'; 
import 'rxjs/add/operator/toPromise';



@Injectable()
export class ToDoService {
    URL: string;

    constructor(private http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.URL = originUrl + '/api/todo';
    }

    getItems(): Promise<ToDoItem[]> {
        return this.http.get(this.URL)
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem[]);
    }

    getItem(id: string): Promise<ToDoItem> {
        const url = `${this.URL}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem);
    }

    addItem(item: ToDoItem): Promise<ToDoItem> {
        return this.http.post(this.URL, JSON.stringify(item))
            .toPromise()
            .then(resp => resp.json() as ToDoItem);
    }

    updateItem(item: ToDoItem): void {
        const url = `${this.URL}/${item.id}`;
        this.http.put(url, JSON.stringify(item))
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem);
    }

    deleteItem(id: string): void {
        const url = `${this.URL}/${id}`;
        this.http.delete(url, id)
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem);
    }

}