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
	database:any = [];
	schema:any = [];
	tables:any = [];

	dbid:any = '';
 	schid:any = '';
 	dtsid:any = '';

	tableForm: FormGroup;
	SchemaId:number=null;
	Fields:string='';
	Name:string='';


    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.dbid=this.route.snapshot.paramMap.get('dbId');
        this.schid=this.route.snapshot.paramMap.get('schemaId');
        this.dtsid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData();
        this.getDatabaseData(this.dbid);
        this.getSchemaData(this.schid);
        this.getTablesData();
        this.tableForm = this.formBuilder.group({
            'SchemaId' : this.schid,
            'Fields' : [],
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

	onFormSubmit() {
	  this.rest.addTable(this.tableForm.value).subscribe((data: {}) => {
          console.log(data);});
	}
    
    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    } 
 

    toDB(store, db) {
        this.router.navigate(['/store/'+ this.dtsid +'/db/'+ this.dbid]);
    }

  
}
