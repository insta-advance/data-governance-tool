import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Datastore, MongoDatabase, PostgresDatabase, Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-global-view',
  templateUrl: './global-view.component.html',
  styleUrls: ['./global-view.component.css']
})
export class GlobalViewComponent implements OnInit {

	datastore:any = [];
	postgresDatabases:any = [];
	mongoDatabases:any = [];
	schemas:any = [];
	tables:any = [];
	structFiles:any = [];
	unstructFiles: any = [];
	keyRelationships: any = [];

	stid: any='';

	varform = 0;

	structFileForm: FormGroup;
	FilePath:  string='';

	unstructFileForm: FormGroup;

	postgresDatabaseForm: FormGroup;
	Type: string='';    
	Schemas:  string='';
	DatastoreId: number=null;
	Name: string='';

	mongoDatabaseForm: FormGroup;
	Collections:  string='';
 

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
	this.stid=this.route.snapshot.paramMap.get('storeId');

        this.getDatastoreData(this.stid);
        this.getPostgresDatabasesData();
        this.getMongoDatabasesData();
	this.getKeyRelationshipData();
        this.getSchemasData();
        this.getTablesData();
        this.getStructFileData();
        this.getUnstructFileData();




        this.postgresDatabaseForm = this.formBuilder.group({
            'Type' : 'PostgreSQL',
            'Schemas' : [],
            'DatastoreId' : this.stid,
            'Name' : [],
          });

        this.mongoDatabaseForm = this.formBuilder.group({
            'Type' : 'MongoDB',
            'Collections' : [],
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

	getKeyRelationshipData() {
		this.keyRelationships = [];
		this.rest.getKeyRelationships().subscribe((data: {}) => {
		  console.log(data);
		  this.keyRelationships = data;
		});
	}
    getDatastoreData(id) {
        this.datastore = [];
        this.rest.getDatastore(id).subscribe((data: {}) => {
          console.log(data);
          this.datastore = data;
        });
    }    
    
    getPostgresDatabasesData() {
        this.postgresDatabases = [];
        this.rest.getPostgresDatabases().subscribe((data: {}) => {
          console.log(data);
          this.postgresDatabases = data;
        });
    }    
    
    getMongoDatabasesData() {
        this.mongoDatabases = [];
        this.rest.getMongoDatabases().subscribe((data: {}) => {
          console.log(data);
          this.mongoDatabases = data;
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


    
	addPostgresDatabase() {
	  this.rest.addPostgresDatabase(this.postgresDatabaseForm.value).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getPostgresDatabasesData();
        	this.getMongoDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

	addMongoDatabase() {
	  this.rest.addMongoDatabase(this.mongoDatabaseForm.value).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getPostgresDatabasesData();
        	this.getMongoDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

	addStructFile() {
	  this.rest.addStructFile(this.structFileForm.value).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getPostgresDatabasesData();
        	this.getMongoDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

	addUnstructFile() {
	  this.rest.addUnstructFile(this.unstructFileForm.value).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getPostgresDatabasesData();
        	this.getMongoDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}

	deleteStructFile(id) {
	  this.rest.deleteStructFile(id).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getPostgresDatabasesData();
        	this.getMongoDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}


	deleteUnstructFile(id) {
	  this.rest.deleteUnstructFile(id).subscribe((data: {}) => {
		this.getDatastoreData(this.stid);
		this.getPostgresDatabasesData();
        	this.getMongoDatabasesData();
		this.getSchemasData();
		this.getTablesData();
		this.getStructFileData();
		this.getUnstructFileData();
	});
	}
    	closeDatastore(){
		this.router.navigate(['']);
	}
    
    toPostgresDatabase(storeId, postgresDatabaseId) {
        this.router.navigate(['/store/'+ storeId +'/postgres/'+ postgresDatabaseId]);
    }

    toPostgresSchema(store, postgresDatabaseId, schemaId) {
        this.router.navigate(['/store/'+ store +'/postgres/'+ postgresDatabaseId + '/schema/' + schemaId]);
    }

    toMongoDatabase(storeId, mongoDatabaseId) {
        this.router.navigate(['/store/'+ storeId +'/mongo/'+ mongoDatabaseId + '/collections']);
    }

}
