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


const appRoutes: Routes = [
  {
    path: '',
    component: GlobalViewComponent,
    data: { title: 'Global View' }
  },
  /*{
    path: 'block-details/:id',
    component: BlockDetailsComponent,
    data: { title: 'Block Details' }
  },
  {
    path: 'block-add',
    component: BlockAddComponent,
    data: { title: 'Block Add' }
  },
  {
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
    /*BlockAddComponent,
    BlockDetailsComponent,
    BlockEditComponent,*/
    SchemaViewComponent,
    DatabaseViewComponent,
    GlobalViewComponent
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
