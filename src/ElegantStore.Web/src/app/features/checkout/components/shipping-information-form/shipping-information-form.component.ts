import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {ControlContainer, FormGroup, FormGroupDirective, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-shipping-information-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './shipping-information-form.component.html',
  styleUrls: ['./shipping-information-form.component.css'],
  viewProviders: [{provide: ControlContainer, useExisting: FormGroupDirective}]
})
export class ShippingInformationFormComponent implements OnInit {
  shippingForm!: FormGroup;

  constructor(private parentFormGroup: FormGroupDirective) { }

  ngOnInit(): void {
    this.shippingForm = this.parentFormGroup.control.get('shippingForm') as FormGroup;

  }

}
