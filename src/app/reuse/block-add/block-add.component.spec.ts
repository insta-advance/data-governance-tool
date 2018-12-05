import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlockAddComponent } from './block-add.component';

describe('BlockAddComponent', () => {
  let component: BlockAddComponent;
  let fixture: ComponentFixture<BlockAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlockAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlockAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
