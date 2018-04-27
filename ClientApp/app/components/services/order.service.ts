import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class OrderService {

  order : any;
  constructor(private http : Http) { }

  getOrders()
  {
    return this.http.get('/api/orders').map(res => res.json());
  }
  saveOrders(order:any)
  {
    return this.http.post('/api/orders', order).map(res => res.json());
  }
}
