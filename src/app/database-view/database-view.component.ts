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
    fields:any = [];
    
    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {

    }


    
    backToHome() {
        this.router.navigate(['/']);
    } 

}
