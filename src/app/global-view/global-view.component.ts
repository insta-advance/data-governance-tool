import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-global-view',
  templateUrl: './global-view.component.html',
  styleUrls: ['./global-view.component.css']
})
export class GlobalViewComponent implements OnInit {

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
