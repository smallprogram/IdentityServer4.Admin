import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OidcLoginComponent } from './component/oidc-login/oidc-login.component';
import { HomeComponent } from './component/home/home.component';

const routes: Routes = [
  { path: 'login', component: OidcLoginComponent },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
