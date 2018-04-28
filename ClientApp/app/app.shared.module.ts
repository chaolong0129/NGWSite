import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ProductComponent } from './components/product/product.component';
import { OrderComponent } from './components/order/order.component';
import { OrderService } from './components/services/order.service';
import { ProductService } from './components/services/product.service';
import { ReportComponent } from './components/report/report.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ProductComponent,
        OrderComponent,
        ReportComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'order', pathMatch: 'full' },
            { path: 'order', component: OrderComponent },
            { path: 'product', component: ProductComponent },
            { path: 'report', component: ReportComponent },
            { path: '**', redirectTo: 'order' }
        ])
    ],
    providers: [OrderService, ProductService]
})
export class AppModuleShared {
}
