import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemComponentComponent } from './item-component.component';

describe('ItemComponentComponent', () => {
  let component: ItemComponentComponent;
  let fixture: ComponentFixture<ItemComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
