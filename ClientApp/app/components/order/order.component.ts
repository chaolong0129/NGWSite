import { Component, OnInit, ValueProvider } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { OrderService } from './../services/order.service';
import { ProductService } from './../services/product.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

    orderItemList: any[] = [];
    orderForm: any;
    orders : any;
    products : any[] = [];
    finalOrder : FinalOrder = new FinalOrder();
    addedProducts : any[] = [];

    constructor(private fb: FormBuilder, private productService : ProductService, private orderService : OrderService) {
        this.createForm();
    }

    ngOnInit() {
        this.productService.getProducts().subscribe(p => {
                this.products = p.result;
                console.log(this.products);
            });
        this.orderService.getOrders().subscribe(p=>{
            this.orders = p.result;
            console.log(this.orders)
        });
    }

    createForm() {
        this.orderForm = this.fb.group({
            product: '',
            quantity: ''
        });
    }

    add() {
        var selectedOrderItem = new SelectedOrderItem();
        selectedOrderItem.productId = this.orderForm.value.product;
        selectedOrderItem.quantity = this.orderForm.value.quantity;

        this.populateOrderItem(selectedOrderItem);
        this.addOrderItemToFinalOrder(selectedOrderItem);
    }

    save() {

    }

    private populateOrderItem(selectedOrderItem : SelectedOrderItem) {
        var a = new PopulateItem();
        a.name = this.getProductNameById(selectedOrderItem.productId);
        a.quantity = selectedOrderItem.quantity;
        this.addedProducts.push(a);
    }

    private addOrderItemToFinalOrder(selectedOrderItem : SelectedOrderItem)
    {
        this.finalOrder.selectedOrderItems.push(selectedOrderItem);
        this.finalOrder.totalPrice += this.getProductPriceById(selectedOrderItem.productId) * selectedOrderItem.quantity;
    }

    private getProductNameById(id : number){
        for (var i = 0; i < this.products.length; i++){
            if (this.products[i].productId == id)
               return this.products[i].name;
        }
    }

    private getProductPriceById(id : number){
        for (var i = 0; i < this.products.length; i++) {
            if (this.products[i].productId == id)
                return this.products[i].price;
        }
    }
}

class FinalOrder {
    selectedOrderItems : SelectedOrderItem[] = [];
    time : any;
    totalPrice : number = 0;
}

class SelectedOrderItem {
    productId : number = 0;
    quantity : number = 0;
}

class PopulateItem {
    name : string = '';
    quantity : number = 0;
}

