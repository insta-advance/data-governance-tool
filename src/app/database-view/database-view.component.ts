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
	database:any = [];
	schemas:any = [];
	tables:any = [];

	dbid:any = '';
 	schid:any = '';
    	dtsid:any = '';
    
	varform = 0;

	schemaForm: FormGroup;
	DatabaseId: number=null;    
	Tables:  string='';
	Name: string='';


    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.dbid=this.route.snapshot.paramMap.get('dbId');
        this.schid=this.route.snapshot.paramMap.get('schemaId');
        this.dtsid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData();
        this.getDatabaseData(this.dbid);
        this.getSchemasData();
        this.getTablesData();
        this.schemaForm = this.formBuilder.group({
	    'DatabaseId' : this.dbid,
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
    
    getDatabaseData(id) {
        this.database = [];
        this.rest.getDatabase(id).subscribe((data: {}) => {
          console.log(data);
          this.database = data;
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
        		this.getDatabaseData(this.dbid);
			this.getSchemasData();
			this.getTablesData();
		});
	}
     	
	deleteDatabase(){
  		this.rest.deleteDatabase(this.database.Id).subscribe((data: {}) => {
  			this.router.navigate(['/store/'+ this.dtsid]);
		});
	}
    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    } 

    toSchema(store, db, schema) {
        this.router.navigate(['/store/'+ store +'/db/'+ db + '/schema/' + schema]);
    }

}