import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {

  product : any;
  constructor(private http : Http) { }

  getProducts(){
    return this.http.get('/api/products').map(res=>res.json());
  }

  saveProducts(product:any){
    return this.http.post('/api/products', product).map(res=>res.json())
  }
}
