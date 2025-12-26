import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './ui/components/home/home.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { OrderComponent } from './admin/components/order/order.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';

const routes: Routes = [
  {path: 'admin',component:LayoutComponent,children:
    [
      {path :"",component:DashboardComponent},
      {path:"customer", loadChildren:()=>import("./admin/components/customer/customer.module").then(m=>m.CustomerModule)},
      {path:"products", loadChildren:()=>import("./admin/components/products/products.module").then(m=>m.ProductsModule)},
      {path:"orders", loadChildren:()=>import("./admin/components/order/order.module").then(m=>m.OrderModule)}
      ,


      {path: 'order',component:OrderComponent}
    ]
  },
  {path:"",component:HomeComponent},
  {path:"basket", loadChildren:()=>import("./ui/components/baskets/baskets.module").then(m=>m.BasketsModule)},
  {path:"products", loadChildren:()=>import("./ui/components/products/products.module").then(m=>m.ProductsModule)}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
