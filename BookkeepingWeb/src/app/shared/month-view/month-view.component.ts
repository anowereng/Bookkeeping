import { Component, Input, OnInit } from '@angular/core';
import { MonthValueViewModel } from '../../common-model/reconcilition-model';

@Component({
  selector: '[app-month-view]',
  templateUrl: './month-view.component.html',
  styleUrls: ['./month-view.component.css']
})
export class MonthViewComponent implements OnInit {

  @Input() month?: any;
  @Input() title?: string;

  constructor() {

   }

  ngOnInit() {
  }

}
