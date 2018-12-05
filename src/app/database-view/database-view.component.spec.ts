import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatabaseViewComponent } from './database-view.component';

describe('DatabaseViewComponent', () => {
  let component: DatabaseViewComponent;
  let fixture: ComponentFixture<DatabaseViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatabaseViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatabaseViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
