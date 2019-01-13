import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Schema } from '../model/metadata.model';

@Component({
  selector: 'app-relational-view',
  templateUrl: './relational-view.component.html',
  styleUrls: ['./relational-view.component.css']
})
export class RelationalViewComponent implements OnInit {

    schemasData:any = [];
    datastoreData:any = [];

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
	this.getDatastoreData();
        this.getSchemasData();
    }

    getDatastoreData() {
        this.datastoreData = [];
        this.rest.getDatastore().subscribe((ddata: {}) => {
          console.log(ddata);
          this.datastoreData = ddata;
    });
  }
    getSchemasData() {
        this.schemasData = [];
        this.rest.getSchemas().subscribe((sdata: {}) => {
          console.log(sdata);
          this.schemasData = sdata;
    });
  }
    
    backToHome() {
        this.router.navigate(['/']);
    } 

}
