import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {

        datastore:any = [];
    databases:any = [];
    schemas:any = [];
    tables:any = [];


	tableForm: FormGroup;
	SchemaId:number=null;
	Fields:string='';
	Name:string='';
	/*Id:number=null;*/


    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.getDatastoreData();
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();
	this.tableForm = this.formBuilder.group({
	    'SchemaId' : [],
	    'Fields' : [],
	    'Name' : [],
	    /*'Id' : []*/
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
	  this.rest.addTable(this.tableForm.value).subscribe((data: {}) => {
          console.log(data);});
	}
    
    backToHome() {
        this.router.navigate(['/']);
    } 
 

    backToDb() {
        this.router.navigate(['/db/1'+ this.route.snapshot.paramMap.get('id')]);
    }

  
}
