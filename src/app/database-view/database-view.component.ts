import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Database, Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-relational-view',
  templateUrl: './database-view.component.html',
  styleUrls: ['./database-view.component.css']
})
export class DatabaseViewComponent implements OnInit {

        datastore:any = [];
    databases:any = [];
    schemas:any = [];
    tables:any = [];
 
	schemaForm: FormGroup;
	DatabaseId: number=null;    
	Tables:  string='';
	Name: string='';


    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.getDatastoreData();
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();
	this.schemaForm = this.formBuilder.group({
	    'DatabaseId' : [],
	    'Tables' : [],
	    'Name' : [],
	  });
    }

    getDatastoreData() {
        this.datastore = [];
        this.rest.getDatastore(1).subscribe((data: {}) => {
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
	  this.rest.addSchema(this.schemaForm.value).subscribe((data: {}) => {
	  console.log(data);});
	}
    
    backToHome() {
        this.router.navigate(['/']);
    } 

}
