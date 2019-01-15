import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Datastore, Database, Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-global-view',
  templateUrl: './global-view.component.html',
  styleUrls: ['./global-view.component.css']
})
export class GlobalViewComponent implements OnInit {

    datastore:any = [];
    databases:any = [];
    schemas:any = [];
    tables:any = [];
	dtsid: any;
	databaseForm: FormGroup;
	Type: string='';    
	Schemas:  string='';
	DatastoreId: number=null;
	Name: string='';
 

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
	this.dstid=this.dbid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData(this.dstid);
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();
	this.databaseForm = this.formBuilder.group({
	    'Type' : [],
	    'Schemas' : [],
	    'DatastoreId' : this.datastore.Id,
	    'Name' : [],
	  });
    }

    getDatastoreData(id) {
        this.datastore = [];
        this.rest.getDatastore(id).subscribe((data: {}) => {
          console.log(data);
          this.datastore = data;
        });
    }    
    
    getDatabasesData() {
        this.databases = [];
        this.rest.getDatabases().subscribe((data: {}) => {
          console.log(data);
          this.databases = data;
        });
    }    
    
    getSchemasData() {
        this.schemas = [];
        this.rest.getSchemas().subscribe((data: {}) => {
          console.log(data);
          this.schemas = data;
        });
    }    
    
    getTablesData() {
        this.tables = [];
        this.rest.getTables().subscribe((data: {}) => {
          console.log(data);
          this.tables = data;
        });
    }    
	onFormSubmit() {
	  this.rest.addDatabase(this.databaseForm.value).subscribe((data: {}) => {
	  console.log(data);});
	}

}
