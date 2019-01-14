import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.css']
})
export class TableViewComponent implements OnInit {



    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {

    }

    backToHome() {
        this.router.navigate(['/']);
    } 
  
}
