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
	postgresDatabase:any = [];
	schema:any = [];
	tables:any = [];
	keyRelationships: any = [];
    	annotationBases:any = [];
    	annotations:any = [];

	dbid:any = '';
 	schid:any = '';
 	dtsid:any = '';

	varform = 0;

	tableForm: FormGroup;
	SchemaId:number=null;
	Fields:string='';
	Name:string='';

	fieldForm: FormGroup;
	Type: string='';
	StructuredId: number=null;

	keyForm: FormGroup;
	FromId: number=null;
	ToId: number=null;

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
        this.getSchemaData(this.schid);
        this.getTablesData();
        this.getAnnotationBases();
        this.getAnnotations();

        this.tableForm = this.formBuilder.group({
            'SchemaId' : this.schid,
            'Fields' : [],
            'Name' : ['',[Validators.required,Validators.minLength(3)]],
	   });
        this.fieldForm = this.formBuilder.group({
            'Type' : ['',[Validators.required]],
            'StructuredId' : [],
            'Fields' : [],
            'Name' : ['',[Validators.required,Validators.minLength(3)]],
	   });
        this.keyForm = this.formBuilder.group({
            'FromId' : ['',[Validators.required]],
            'ToId' : ['',[Validators.required]],
            'Type' : ['',[Validators.required]],
	   });
      this.annotationBaseForm = this.formBuilder.group({
            'BaseId' :  this.schid,
           'AnnotationId' : ['',[Validators.required]],
       });  
      
      this.annotationForm = this.formBuilder.group({
            'Description' : ['',[Validators.required,Validators.minLength(3)]],
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
    
    getSchemaData(id) {
        this.schema = [];
        this.rest.getSchema(id).subscribe((data: {}) => {
          console.log(data);
          this.schema = data;
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
 	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();
		});
	}
    
    addAnnotation() {
		this.rest.addAnnotation(this.annotationForm.value).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();            
		});
	}      

	addPostgresTable() {
		this.rest.addTable(this.tableForm.value).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations(); 
		});
	}
	addPostgresField() {
		this.rest.addField(this.fieldForm.value).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations(); 
		});
	}

	addKeyRelationship() {
		this.rest.addKeyRelationship(this.keyForm.value).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations(); 
		});
	}

    	deleteSchema(){
  		this.rest.deleteSchema(this.schema.Id).subscribe((data: {}) => {
  			this.router.navigate(['/store/'+ this.dtsid +'/postgres/'+ this.dbid]);
		});
	}
    	deleteTable(id){
  		this.rest.deleteTable(id).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations(); 
		});
	}
    	deleteField(id){
  		this.rest.deleteField(id).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations(); 
		});
	}
    	deleteKeyRelationship(id){
  		this.rest.deleteKeyRelationship(id).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations(); 
		});
	}
    	deleteAnnotation(id) {
		this.rest.deleteAnnotation(id).subscribe((data: {}) => {

	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();    
		});
	}
 
    	deleteAnnotationBase(id) {
		this.rest.deleteAnnotationBase(id).subscribe((data: {}) => {
 
	  	        this.getSchemaData(this.schid);
			this.getKeyRelationshipData();
			this.getTablesData();
		        this.getAnnotationBases();
		        this.getAnnotations();     
		});
	}  
    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    } 
 

    backToPostgresDatabase() {
        this.router.navigate(['/store/'+ this.dtsid +'/postgres/'+ this.dbid]);
    }

  
}
