import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingInformationFormComponent } from './shipping-information-form.component';

describe('ShippingInformationFormComponent', () => {
  let component: ShippingInformationFormComponent;
  let fixture: ComponentFixture<ShippingInformationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShippingInformationFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippingInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
