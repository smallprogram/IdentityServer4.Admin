import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; //动画


import 'hammerjs'; //Angular material 手势支持
import { MaterialModule } from './shared/material.module'; //所有Angular material的组件

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './component/oidc/login/login.component';
import { LogoutComponent } from './component/oidc/logout/logout.component';
import { RedirectNewTokenComponent } from './component/oidc/redirect-new-token/redirect-new-token.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LogoutComponent,
    RedirectNewTokenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
