import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Table } from '../table.model';

@Component({
  selector: 'app-block',
  templateUrl: './block.component.html',
  styleUrls: ['./block.component.css']
})
export class BlockComponent implements OnInit {

  blocks:any = [];

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getBlocks();
  }

  getBlocks() {
    this.blocks = [];
    this.rest.getBlocks().subscribe((data: {}) => {
      console.log(data);
      this.blocks = data;
    });
  }

  add() {
    this.router.navigate(['/block-add']);
  }

  /*delete(id) {
    this.rest.deleteBlock(id)
      .subscribe(res => {
          this.getBlocks();
        }, (err) => {
          console.log(err);
        }
      );
  }*/

}