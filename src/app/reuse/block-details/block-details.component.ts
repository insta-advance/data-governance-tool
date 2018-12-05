import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-block-detail',
  templateUrl: './block-details.component.html',
  styleUrls: ['./block-details.component.css']
})
export class BlockDetailsComponent implements OnInit {

    block:any;

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.rest.getBlock(this.route.snapshot.params['id']).subscribe((data: {}) => {
          console.log(data);
          this.block = data[this.route.snapshot.params['id']];
        });
      }
    
    
    showList() {
        this.router.navigate(['/']);
      }    
    
    editTable() {
        this.router.navigate(['/block-edit/'+ this.route.snapshot.params['id']]);
      }

    }