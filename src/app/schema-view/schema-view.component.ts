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

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.getData();
    }

    getData() {
        this.singleSchemaData = [];
        this.rest.getSchemas().subscribe((data: {}) => {
          console.log(data);
          this.singleSchemaData = data;
    });
  }
    
    backToHome() {
        this.router.navigate(['/']);
    }    
    
    backToSchemas() {
        this.router.navigate(['/schemas']);
    } 

}
