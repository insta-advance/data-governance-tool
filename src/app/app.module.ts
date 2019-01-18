import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

//import { TableViewComponent } from './table-view/table-view.component';
import { SchemaViewComponent } from './schema-view/schema-view.component';
import { DatabaseViewComponent } from './database-view/database-view.component';
import { GlobalViewComponent } from './global-view/global-view.component';


import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatastoreListComponent } from './datastore-list/datastore-list.component';


const appRoutes: Routes = [
  {
    path: '',
    component: DatastoreListComponent,
    data: { title: 'List of datastores' }
  },
  {
    path: 'store/:storeId',
    component: GlobalViewComponent,
    data: { title: 'Global view' }
  },

  {
    path: 'store/:storeId/postgres/:dbId',
    component: DatabaseViewComponent,
    data: { title: 'Postgres database view' }
  },
  {
    path: 'store/:storeId/postgres/:dbId/schema/:schemaId',
    component: SchemaViewComponent,
    data: { title: 'Postgres schema view' }
  },

];

@NgModule({
  declarations: [
    AppComponent,
    GlobalViewComponent,
    SchemaViewComponent,
    GlobalViewComponent,
    DatabaseViewComponent,
    DatastoreListComponent,
  ],
  imports: [
      RouterModule.forRoot(appRoutes),
      FormsModule,
      ReactiveFormsModule,
      BrowserModule,
      HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
