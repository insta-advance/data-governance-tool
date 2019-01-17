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

	varform = 0;

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
	this.stid=this.route.snapshot.paramMap.get('storeId');

        this.getDatastoreData(this.stid);
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();
        this.getStructFileData();
        this.getUnstructFileData();

        this.databaseForm = this.formBuilder.group({
            'Type' : [],
            'Schemas' : [],
            'DatastoreId' : this.stid,
            'Name' : [],
          });

        this.structFileForm = this.formBuilder.group({
            'FilePath' : [],
            'DatastoreId' : this.stid,
          });

        this.unstructFileForm = this.formBuilder.group({
            'FilePath' : [],
            'DatastoreId' : this.stid,
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
		this.getDatastoreData(this.stid);
		this.getDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

	addStructFile() {
	  this.rest.addStructFile(this.structFileForm.value).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

	addUnstructFile() {
	  this.rest.addUnstructFile(this.unstructFileForm.value).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

    	closeDatastore(){
		this.router.navigate(['']);
	}
    
    toDB(store, db) {
        this.router.navigate(['/store/'+ store +'/db/'+ db]);
    }

    toSchema(store, db, schema) {
        this.router.navigate(['/store/'+ store +'/db/'+ db + '/schema/' + schema]);
    }

}
