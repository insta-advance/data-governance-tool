import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MongoDatabaseViewComponent } from './mongo-database-view.component';

describe('MongoDatabaseViewComponent', () => {
  let component: MongoDatabaseViewComponent;
  let fixture: ComponentFixture<MongoDatabaseViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MongoDatabaseViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MongoDatabaseViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
