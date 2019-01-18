import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-mongo-database-view',
  templateUrl: './mongo-database-view.component.html',
  styleUrls: ['./mongo-database-view.component.css']
})
export class MongoDatabaseViewComponent implements OnInit {
    
    datastore:any = [];
    mongoDatabase:any = [];
    collections:any = [];
    annotationBases:any = [];
    annotations:any = [];
    
    dbid:any = '';
    dtsid:any = '';
    
    varform = 0;
    
    collectionForm: FormGroup;
	DatabaseId:number=null;
	Fields:string='';
	Name:string='';

	fieldForm: FormGroup;
	Type: string='';
	StructuredId: number=null;
    
    annotationBaseForm: FormGroup;
	BaseId: number=null;
    	AnnotationId: number=null;

    annotationForm: FormGroup;
	Description: string='';
    
  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
        this.dbid=this.route.snapshot.paramMap.get('dbId');
        this.dtsid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData(this.dtsid);
        this.getMongoDatabaseData(this.dbid);
        this.getCollectionData();
        this.getAnnotationBases();
        this.getAnnotations();
      
      this.collectionForm = this.formBuilder.group({
            'DatabaseId' : this.dbid,
            'Fields' : [],
            'Name' : [],
       });  
      
      this.fieldForm = this.formBuilder.group({
            'Type' : [],
            'StructuredId' : [],
            'Fields' : [],
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
    
    getDatastoreData(id) {
        this.datastore = [];
        this.rest.getDatastore(id).subscribe((data: {}) => {
          console.log(data);
          this.datastore = data;
        });
    }
    getMongoDatabaseData(id) {
        this.mongoDatabase = [];
        this.rest.getMongoDatabase(id).subscribe((data: {}) => {
          console.log(data);
          this.mongoDatabase = data;
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
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();
		});
	}
    
    addAnnotation() {
		this.rest.addAnnotation(this.annotationForm.value).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();            
		});
	}    
    
    addCollection() {
		this.rest.addCollection(this.collectionForm.value).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();            
		});
	}
    
    addField() {
		this.rest.addField(this.fieldForm.value).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}
    
    deleteMongoDatabase(id) {
		this.rest.deleteMongoDatabase(id).subscribe((data: {}) => {
			this.router.navigate(['/store/'+ this.dtsid]);     
		});
	}  
    
    deleteCollection(id) {
		this.rest.deleteCollection(id).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}  
    
    deleteField(id) {
		this.rest.deleteField(id).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}  
 
    deleteAnnotation(id) {
		this.rest.deleteAnnotation(id).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}
 
    deleteAnnotationBase(id) {
		this.rest.deleteAnnotationBase(id).subscribe((data: {}) => {
        		this.getMongoDatabaseData(this.dbid);
		        this.getCollectionData();
		        this.getAnnotationBases();
		        this.getAnnotations();      
		});
	}  
    
    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    }     

}
