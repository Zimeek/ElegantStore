import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeaturedProductListComponent } from './featured-product-list.component';

describe('FeaturedProductListComponent', () => {
  let component: FeaturedProductListComponent;
  let fixture: ComponentFixture<FeaturedProductListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeaturedProductListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeaturedProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
