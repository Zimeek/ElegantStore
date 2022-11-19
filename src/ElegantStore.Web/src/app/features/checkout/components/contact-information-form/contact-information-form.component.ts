import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-contact-information-form',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-information-form.component.html',
  styleUrls: ['./contact-information-form.component.css']
})
export class ContactInformationFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
