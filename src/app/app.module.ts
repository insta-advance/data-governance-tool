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


const appRoutes: Routes = [
  {
    path: '',
    component: GlobalViewComponent,
    data: { title: 'Global View' }
  },
  {
    path: 'db/:id',
    component: DatabaseViewComponent,
    data: { title: 'Database view' }
  },
  {
    path: 'db/:id/schema/:schemaId',
    component: SchemaViewComponent,
    data: { title: 'Schema view' }
  },
  /*{
    path: 'db/:id/schema/:schemaId/table/:tableId',
    component: TableViewComponent,
    data: { title: 'Table view' }
  },*/
];

@NgModule({
  declarations: [
    AppComponent,
    GlobalViewComponent,
    SchemaViewComponent,
    GlobalViewComponent,
    DatabaseViewComponent,
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