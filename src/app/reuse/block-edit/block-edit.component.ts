import { Component, OnInit, Input } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-block-edit',
  templateUrl: './block-edit.component.html',
  styleUrls: ['./block-edit.component.css']
})
export class BlockEditComponent implements OnInit {

  @Input() blockData:any = { block_id: '', block_name: '', block_field1:'',block_field2:'',block_field3:'',};

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.rest.getBlock(this.route.snapshot.params['id']).subscribe((data: {}) => {
      console.log(data);
      this.blockData =  data[this.route.snapshot.params['id']];
    });
  }

  /*updateBlock() {
    this.rest.updateBlock(this.route.snapshot.params['id'], this.blockData).subscribe((result) => {
      this.router.navigate(['/block-details/'+result._id]);
    }, (err) => {
      console.log(err);
    });
  }*/
    showList() {
    this.router.navigate(['/block']);
  }
    backToDetails() {
    this.router.navigate(['/block-details/'+this.route.snapshot.params['id']]);
  }

}