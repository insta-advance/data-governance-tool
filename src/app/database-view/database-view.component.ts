import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-relational-view',
  templateUrl: './database-view.component.html',
  styleUrls: ['./database-view.component.css']
})
export class DatabaseViewComponent implements OnInit {

        datastore:any = [];
    databases:any = [];
    schemas:any = [];
    tables:any = [];
 


    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.getDatastoreData();
        this.getDatabasesData();
        this.getSchemasData();
        this.getTablesData();

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


    
    backToHome() {
        this.router.navigate(['/']);
    } 

}
