import { Component, OnInit, Input } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-block-add',
  templateUrl: './block-add.component.html',
  styleUrls: ['./block-add.component.css']
})
export class BlockAddComponent implements OnInit {

  @Input() blockData = { block_id:'', block_name: ''};

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }

 /* addBlock() {
    this.rest.addBlock(this.blockData).subscribe((result) => {
      this.router.navigate(['/block-details/'+result.id]);
    }, (err) => {
      console.log(err);
    });
  }*/
  showList() {
    this.router.navigate(['/block']);
  }

}