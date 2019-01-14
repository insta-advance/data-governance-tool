import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {



    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {


    }


    backToHome() {
        this.router.navigate(['/']);
    } 
  
}
