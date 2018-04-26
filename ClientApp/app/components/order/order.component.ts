import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

    orderItemList: any[] = [];
    orderForm: any;

    constructor(private fb: FormBuilder) {
        this.createForm();
    }

    ngOnInit() {
        
    }

    createForm() {
        this.orderForm = this.fb.group({
            product: '',
            quantity: ''
        });
    }

    add() {
        this.orderItemList.push(new orderItem(this.orderForm.value.product,this.orderForm.value.quantity));
        console.log(this.orderItemList);
    }

}

class orderItem {
    constructor(p: any, q: any){
        this.product = p;
        this.quantity = q;
    }
    product: any;
    quantity: any;
}
