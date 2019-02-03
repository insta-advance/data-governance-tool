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
	    collections:any = [];
	    annotationBases:any = [];
	    annotations:any = [];

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

     	annotationBaseForm: FormGroup;
	BaseId: number=null;
    	AnnotationId: number=null;

    	annotationForm: FormGroup;
	Description: string='';
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
        this.getCollectionData();
        this.getAnnotationBases();
        this.getAnnotations();



        this.postgresDatabaseForm = this.formBuilder.group({
            'Type' : 'PostgreSQL',
            'Schemas' : [],
            'DatastoreId' : this.stid,
            'Name' : ['',[Validators.required,Validators.minLength(1)]],
          });

        this.mongoDatabaseForm = this.formBuilder.group({
            'Type' : 'MongoDB',
            'Collections' : [],
            'DatastoreId' : this.stid,
            'Name' : ['',[Validators.required,Validators.minLength(1)]],
          });

        this.structFileForm = this.formBuilder.group({
            'FilePath' : ['',[Validators.required,Validators.minLength(1)]],
            'DatastoreId' : this.stid,
          });

        this.unstructFileForm = this.formBuilder.group({
            'FilePath' : ['',[Validators.required,Validators.minLength(1)]],
            'DatastoreId' : this.stid,
          });
      this.annotationBaseForm = this.formBuilder.group({
            'BaseId' :  ['',[Validators.required]],
           'AnnotationId' : ['',[Validators.required]],
       });
      this.annotationForm = this.formBuilder.group({
            'Description' : ['',[Validators.required,Validators.minLength(1)]],
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
    getCollectionData() {
        this.collections = [];
        this.rest.getCollections().subscribe((data: {}) => {
          console.log(data);
          this.collections = data;
        });
    }  
    
    getAnnotationBases() {
        this.annotationBases = [];
        this.rest.getAnnotationBases().subscribe((data: {}) => {
          console.log(data);
          this.annotationBases = data;
        });
    } 
    
    getAnnotations() {
        this.annotations = [];
        this.rest.getAnnotations().subscribe((data: {}) => {
          console.log(data);
          this.annotations = data;
        });
    }

	addAnnotationBase() {
		this.rest.addAnnotationBase(this.annotationBaseForm.value).subscribe((data: {}) => {
			this.getDatastoreData(this.stid);
			this.getPostgresDatabasesData();
			this.getMongoDatabasesData();
			this.getSchemasData();
			this.getTablesData();
			this.getStructFileData();
			this.getUnstructFileData();
			this.getAnnotationBases();
			this.getAnnotations();
		});
	}
    
    addAnnotation() {
		this.rest.addAnnotation(this.annotationForm.value).subscribe((data: {}) => {
			this.getDatastoreData(this.stid);
			this.getPostgresDatabasesData();
			this.getMongoDatabasesData();
			this.getSchemasData();
			this.getTablesData();
			this.getStructFileData();
			this.getUnstructFileData();
			this.getAnnotationBases();
			this.getAnnotations();          
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
	        this.getAnnotationBases();
	        this.getAnnotations(); 
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
	        this.getAnnotationBases();
	        this.getAnnotations(); 
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
	        this.getAnnotationBases();
	        this.getAnnotations(); 
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
	        this.getAnnotationBases();
	        this.getAnnotations();  
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
	        this.getAnnotationBases();
	        this.getAnnotations();  
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
	        this.getAnnotationBases();
	        this.getAnnotations();  
	});
	}

    	deleteAnnotation(id) {
		this.rest.deleteAnnotation(id).subscribe((data: {}) => {
			this.getDatastoreData(this.stid);
			this.getPostgresDatabasesData();
			this.getMongoDatabasesData();
			this.getSchemasData();
			this.getTablesData();
			this.getStructFileData();
			this.getUnstructFileData();   
		        this.getAnnotationBases();
		        this.getAnnotations();  
		});
	}
 
    	deleteAnnotationBase(id) {
		this.rest.deleteAnnotationBase(id).subscribe((data: {}) => {
			this.getDatastoreData(this.stid);
			this.getPostgresDatabasesData();
			this.getMongoDatabasesData();
			this.getSchemasData();
			this.getTablesData();
			this.getStructFileData();
			this.getUnstructFileData();  
		        this.getAnnotationBases();
		        this.getAnnotations();    
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
