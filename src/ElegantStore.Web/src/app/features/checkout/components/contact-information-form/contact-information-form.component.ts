import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {ControlContainer, FormGroup, FormGroupDirective, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-contact-information-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './contact-information-form.component.html',
  styleUrls: ['./contact-information-form.component.css'],
  viewProviders: [{provide: ControlContainer, useExisting: FormGroupDirective}]
})
export class ContactInformationFormComponent implements OnInit {
  contactForm!: FormGroup;

  constructor(private parentFormGroup: FormGroupDirective) { }

  ngOnInit(): void {
    this.contactForm = this.parentFormGroup.control.get('contactForm') as FormGroup;
  }
}
