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
    
  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
        this.dbid=this.route.snapshot.paramMap.get('dbId');
        this.dtsid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData(this.dtsid);
        this.getMongoDatabaseData(this.dbid);
        this.getCollectionData();
      
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
    
    
    addCollection() {
		this.rest.addCollection(this.collectionForm.value).subscribe((data: {}) => {
                this.getCollectionData();
		});
	}
    
    addField() {
		this.rest.addField(this.fieldForm.value).subscribe((data: {}) => {
                this.getCollectionData();
		});
	}
    
    deleteMongoDatabase(id) {
		this.rest.deleteMongoDatabase(id).subscribe((data: {}) => {
                this.getCollectionData();
		});
	}  
    
    deleteCollection(id) {
		this.rest.deleteCollection(id).subscribe((data: {}) => {
                this.getCollectionData();
		});
	}  
    
    deleteField(id) {
		this.rest.deleteField(id).subscribe((data: {}) => {
                this.getCollectionData();
		});
	}    
    
    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    }     

}
