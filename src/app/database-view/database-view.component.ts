import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { PostgresDatabase, Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-relational-view',
  templateUrl: './database-view.component.html',
  styleUrls: ['./database-view.component.css']
})
export class DatabaseViewComponent implements OnInit {

        datastore:any = [];
	postgresDatabase:any = [];
	schemas:any = [];
	tables:any = [];
	keyRelationships: any = [];
    annotationBases:any = [];
    annotations:any = [];

	dbid:any = '';
 	schid:any = '';
    	dtsid:any = '';
    
	varform = 0;

	schemaForm: FormGroup;
	DatabaseId: number=null;    
	Tables:  string='';
	Name: string='';

    annotationBaseForm: FormGroup;
	BaseId: number=null;
    	AnnotationId: number=null;

    annotationForm: FormGroup;
	Description: string='';

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.dbid=this.route.snapshot.paramMap.get('dbId');
        this.schid=this.route.snapshot.paramMap.get('schemaId');
        this.dtsid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData(this.dtsid);
        this.getPostgresDatabaseData(this.dbid);
	this.getKeyRelationshipData();
        this.getSchemasData();
        this.getTablesData();
        this.getAnnotationBases();
        this.getAnnotations();
        this.schemaForm = this.formBuilder.group({
	    'DatabaseId' : this.dbid,
	    'Tables' : [],
	    'Name' : [],
	  });
      this.annotationBaseForm = this.formBuilder.group({
            'BaseId' :  this.dbid,
           'AnnotationId' : [],
       });  
      
      this.annotationForm = this.formBuilder.group({
            'Description' : [],
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
    
    getPostgresDatabaseData(id) {
        this.postgresDatabase = [];
        this.rest.getPostgresDatabase(id).subscribe((data: {}) => {
          console.log(data);
          this.postgresDatabase = data;
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
        		this.getPostgresDatabaseData(this.dbid);
			this.getSchemasData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();
		});
	}
    
    addAnnotation() {
		this.rest.addAnnotation(this.annotationForm.value).subscribe((data: {}) => {
        		this.getPostgresDatabaseData(this.dbid);
			this.getSchemasData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();            
		});
	}   

	onFormSubmit() {
  		this.rest.addSchema(this.schemaForm.value).subscribe((data: {}) => {
        		this.getPostgresDatabaseData(this.dbid);
			this.getSchemasData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();   
		});
	}
     	
	deletePostgresDatabase(){
  		this.rest.deletePostgresDatabase(this.postgresDatabase.Id).subscribe((data: {}) => {
  			this.router.navigate(['/store/'+ this.dtsid]);
		});
	}

    	deleteAnnotation(id) {
		this.rest.deleteAnnotation(id).subscribe((data: {}) => {
        		this.getPostgresDatabaseData(this.dbid);
			this.getSchemasData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}
 
    	deleteAnnotationBase(id) {
		this.rest.deleteAnnotationBase(id).subscribe((data: {}) => {
        		this.getPostgresDatabaseData(this.dbid);
			this.getSchemasData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}  

    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    } 

    toSchema(store, postgresDatabaseId, schemaId) {
        this.router.navigate(['/store/'+ store +'/postgres/'+ postgresDatabaseId + '/schema/' + schemaId]);
    }

}
