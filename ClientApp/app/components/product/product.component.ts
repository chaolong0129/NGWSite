import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent
{
  name : string = "Hello Product";
  productForm : any;

  constructor(private fb : FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.productForm = this.fb.group({
      name : '',
      category : '',
      price : 0
    });
  }

  add() {
    console.log(this.productForm.value);
  }
}