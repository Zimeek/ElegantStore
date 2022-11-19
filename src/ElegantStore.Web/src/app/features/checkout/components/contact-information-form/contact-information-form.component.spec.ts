import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactInformationFormComponent } from './contact-information-form.component';

describe('ContactInformationFormComponent', () => {
  let component: ContactInformationFormComponent;
  let fixture: ComponentFixture<ContactInformationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactInformationFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContactInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
