import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NonrelationalViewComponent } from './nonrelational-view.component';

describe('NonrelationalViewComponent', () => {
  let component: NonrelationalViewComponent;
  let fixture: ComponentFixture<NonrelationalViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NonrelationalViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NonrelationalViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
