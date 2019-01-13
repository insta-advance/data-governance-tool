import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {

    singleSchemaData:any = [];
    datastoreData:any = [];

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
	this.getDatastoreData();
        this.getSchemaData();
    }

    getDatastoreData() {
        this.datastoreData = [];
        this.rest.getDatastore().subscribe((ddata: {}) => {
          console.log(ddata);
          this.datastoreData = ddata;
    });
  }
    getSchemaData() {
        this.singleSchemaData = [];
        this.rest.getSingleSchema(2) => {
          console.log(data);
          this.singleSchemaData = data;
    });
  }
    backToHome() {
        this.router.navigate(['/']);
    } 
  
}
