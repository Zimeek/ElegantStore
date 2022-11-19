import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-shipping-information-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './shipping-information-form.component.html',
  styleUrls: ['./shipping-information-form.component.css']
})
export class ShippingInformationFormComponent implements OnInit {
  shippingForm = this.formBuilder.group(
    {
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      address: ['', Validators.required],
      apartment: ['', Validators.required],
      city: ['', Validators.required],
      province: ['', Validators.required]
    },
    {
      updateOn: 'blur'
    }
  )

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

  }

}
