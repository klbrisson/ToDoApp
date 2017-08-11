import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { ListComponent } from './components/list/list.component';
import { ItemComponent } from './components/list/item.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        ListComponent,
        ItemComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: ListComponent },
            { path: '**', redirectTo: 'list' }
        ])
    ]
};
