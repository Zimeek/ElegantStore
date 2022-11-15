import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";

@Component({
  selector: 'app-landing-banner',
  imports: [CommonModule, RouterModule],
  standalone: true,
  templateUrl: './landing-banner.component.html',
  styleUrls: ['./landing-banner.component.css']
})
export class LandingBannerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
