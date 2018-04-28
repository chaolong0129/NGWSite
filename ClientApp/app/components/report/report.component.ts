import { Component, OnInit } from '@angular/core';
import { OrderService } from './../services/order.service';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})

export class ReportComponent implements OnInit {
  orders : any;

  constructor(private OrderService : OrderService) { }

  ngOnInit() {
    this.OrderService.getOrders().subscribe( o => {
      this.orders = o.result;
      console.log(this.orders);
    });
  }

}
