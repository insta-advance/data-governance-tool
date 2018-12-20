import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { SchemaViewComponent } from './schema-view/schema-view.component';
import { DatabaseViewComponent } from './database-view/database-view.component';
import { GlobalViewComponent } from './global-view/global-view.component';

import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { RelationalViewComponent } from './relational-view/relational-view.component';
import { NonrelationalViewComponent } from './nonrelational-view/nonrelational-view.component';
import { TableAddComponent } from './table-add/table-add.component';


const appRoutes: Routes = [
  {
    path: '',
    component: GlobalViewComponent,
    data: { title: 'Global View' }
  },
  {
    path: 'schemas',
    component: RelationalViewComponent,
    data: { title: 'All schemas View' }
  },
  {
    path: 'databases',
    component: NonrelationalViewComponent,
    data: { title: 'All databases View' }
  },
  {
    path: 'schemas/:id',
    component: SchemaViewComponent,
    data: { title: 'Schema view' }
  },
  {
    path: 'databases/:id',
    component: DatabaseViewComponent,
    data: { title: 'Database view' }
  },
  /*{
    path: 'block-edit/:id',
    component: BlockEditComponent,
    data: { title: 'Block Edit' }
  },
  { path: '',
    redirectTo: '/view',
    pathMatch: 'full'
  }*/
];

@NgModule({
  declarations: [
    AppComponent,
    GlobalViewComponent,
    SchemaViewComponent,
    DatabaseViewComponent,
    GlobalViewComponent,
    RelationalViewComponent,
    NonrelationalViewComponent,
    TableAddComponent,

  ],
  imports: [
      RouterModule.forRoot(appRoutes),
      FormsModule,
      BrowserModule,
      HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
