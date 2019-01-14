import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


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
    fields:any = [];


    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.getDatastoreData();
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();
        this.getFieldData();
    }

    getDatastoreData() {
        this.datastore = [];
        this.rest.getDatastore(1).subscribe((data: {}) => {
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
    
    getFieldData() {
        this.fields = [];
        this.rest.getFields().subscribe((data: {}) => {
          console.log(data);
          this.fields = data;
        });
    }

}
