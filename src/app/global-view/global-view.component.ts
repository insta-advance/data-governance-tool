import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-global-view',
  templateUrl: './global-view.component.html',
  styleUrls: ['./global-view.component.css']
})
export class GlobalViewComponent implements OnInit {

    metadata:any = [];

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.getData();
    }

    getData() {
        this.metadata = [];
        this.rest.getMeta().subscribe((data: {}) => {
          console.log(data);
          this.metadata = data;
    });
  }
}
