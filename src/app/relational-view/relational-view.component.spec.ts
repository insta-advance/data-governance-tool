import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RelationalViewComponent } from './relational-view.component';

describe('RelationalViewComponent', () => {
  let component: RelationalViewComponent;
  let fixture: ComponentFixture<RelationalViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RelationalViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RelationalViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
