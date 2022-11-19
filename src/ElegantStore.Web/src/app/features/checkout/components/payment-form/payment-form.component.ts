import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-payment-form',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './payment-form.component.html',
  styleUrls: ['./payment-form.component.css']
})
export class PaymentFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
