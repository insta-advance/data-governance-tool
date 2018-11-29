import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { BlockComponent } from './block/block.component';
import { BlockAddComponent } from './block-add/block-add.component';
import { BlockDetailsComponent } from './block-details/block-details.component';
import { BlockEditComponent } from './block-edit/block-edit.component';

import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

const appRoutes: Routes = [
  {
    path: '',
    component: BlockComponent,
    data: { title: 'Block List' }
  },
  {
    path: 'block-details/:id',
    component: BlockDetailsComponent,
    data: { title: 'Block Details' }
  },
  /*{
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
    BlockComponent,
    BlockAddComponent,
    BlockDetailsComponent,
    BlockEditComponent
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
