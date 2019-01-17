import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Datastore } from '../model/metadata.model';

@Component({
  selector: 'app-datastore-list',
  templateUrl: './datastore-list.component.html',
  styleUrls: ['./datastore-list.component.css']
})
export class DatastoreListComponent implements OnInit {
    datastores:any = [];

    datastoreForm: FormGroup;
    Databases: string='';    
    StructuredFiles: string='';    
    UnstructuredFiles: string='';    
    Name: string='';
    
    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.getDatastoresData();
        this.datastoreForm = this.formBuilder.group({
        'Databases' : [],
        'StructuredFiles' : [],
        'UnstructuredFiles' : [],
        'Name' : [],
    });
    }
    
    getDatastoresData() {
        this.datastores = [];
        this.rest.getDatastores().subscribe((data: {}) => {
          console.log(data);
          this.datastores = data;
        });
    }  
    
	addDatastore() {
	  this.rest.addDatastore(this.datastoreForm.value).subscribe((data: {}) => {
        	this.getDatastoresData();	
	});
	}

	deleteDatastore(id){
		this.rest.deleteDatastore(id).subscribe((data: {}) => {
		        this.getDatastoresData();
		});
	}
    toDatastore(dst) {
        this.router.navigate(['/store/'+ dst]);
    }

}
