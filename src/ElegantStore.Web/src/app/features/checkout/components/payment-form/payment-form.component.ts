import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {ControlContainer, FormGroup, FormGroupDirective, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-payment-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './payment-form.component.html',
  styleUrls: ['./payment-form.component.css'],
  viewProviders: [{provide: ControlContainer, useExisting: FormGroupDirective}]
})
export class PaymentFormComponent implements OnInit {
  paymentForm!: FormGroup;

  constructor(private parentFormGroup: FormGroupDirective) { }

  ngOnInit(): void {
    this.paymentForm = this.parentFormGroup.control.get('paymentForm') as FormGroup;
  }

}
