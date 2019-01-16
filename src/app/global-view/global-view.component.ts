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
	structFiles:any = [];
	unstructFiles: any = [];

	stid: any='';

	structFileForm: FormGroup;
	FilePath:  string='';

	unstructFileForm: FormGroup;

	databaseForm: FormGroup;
	Type: string='';    
	Schemas:  string='';
	DatastoreId: number=null;
	Name: string='';
 

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
	//this.stid=this.route.snapshot.paramMap.get('storeId');
	//console.log(this.stid);

        this.getDatastoreData(1);
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();
	this.getStructFileData();
	this.getUnstructFileData();

	this.databaseForm = this.formBuilder.group({
	    'Type' : [],
	    'Schemas' : [],
	    'DatastoreId' : 1,
	    'Name' : [],
	  });

	this.structFileForm = this.formBuilder.group({
	    'FilePath' : [],
	    'DatastoreId' : 1,
	  });

	this.unstructFileForm = this.formBuilder.group({
	    'FilePath' : [],
	    'DatastoreId' : 1,
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
    getStructFileData() {
        this.structFiles = [];
        this.rest.getStructFiles().subscribe((data: {}) => {
          console.log(data);
          this.structFiles = data;
        });
    }
    getUnstructFileData() {
        this.unstructFiles = [];
        this.rest.getUnstructFiles().subscribe((data: {}) => {
          console.log(data);
          this.unstructFiles = data;
        });
    }


    
	addDatabase() {
	  this.rest.addDatabase(this.databaseForm.value).subscribe((data: {}) => {
	  console.log(data);});
	}

	addStructFile() {
	  this.rest.addStructFile(this.structFileForm.value).subscribe((data: {}) => {
	  console.log(data);});
	}

	addUnstructFile() {
	  this.rest.addUnstructFile(this.unstructFileForm.value).subscribe((data: {}) => {
	  console.log(data);});
	}

    toDB(db) {
        this.router.navigate(['/db/'+ db]);
    }

   toSchema(db, schema) {
        this.router.navigate(['/db/'+ db + '/schema/'schema);
    }

}
