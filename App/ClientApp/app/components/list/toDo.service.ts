import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { ToDoItem } from './toDoItem.model';
import 'rxjs/add/operator/map'; 
import 'rxjs/add/operator/toPromise';



@Injectable()
export class ToDoService {
    url: string;

    constructor(private http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.url = originUrl + '/api/todo';
    }

    getItems(): Promise<ToDoItem[]> {
        return this.http.get(this.url)
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem[]);
    }

    getItem(id: string): Promise<ToDoItem> {
        const url = `${this.url}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem);
    }

    addItem(item: ToDoItem): Promise<ToDoItem> {
        return this.http.post(this.url, JSON.stringify(item))
            .toPromise()
            .then(resp => resp.json() as ToDoItem);
    }

    updateItem(item: ToDoItem): void {
        this.http.put(this.url, JSON.stringify(item))
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem);
    }

    deleteItem(id: string): void {
        const url = `${this.url}/${id}`;
        this.http.delete(url, id)
            .toPromise()
            .then((resp: Response) => resp.json() as ToDoItem);
    }

}