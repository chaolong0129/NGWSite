import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { ProductService } from './../services/product.service';
@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent
{
    name: string = "Hello Product";
    productForm: any;
    products : any;

    constructor(private fb: FormBuilder, private productService : ProductService) {
        this.createForm();
    }

    ngOnInit() {
        this.productService.getProducts().subscribe(products=>{
            this.products = products.result;
            console.log(this.products);
        });
    }

    createForm() {
        this.productForm = this.fb.group({
            name: '',
            category: '',
            price: 0
        });
    }

    add(){
       this.productService.saveProducts(this.productForm.value).subscribe(x => console.log(x));
    }
}