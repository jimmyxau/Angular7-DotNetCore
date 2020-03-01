import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'

import { HttpClientModule } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {ConfirmService, ConfirmState, ConfirmModalComponent, ConfirmTemplateDirective} from './shared/confirm-modal-and-service';

import { AppComponent } from './app.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PaymentDetailComponent } from './payment-details/payment-detail/payment-detail.component';
import { PaymentDetailListComponent } from './payment-details/payment-detail-list/payment-detail-list.component';
import { PaymentDetailService } from './shared/payment-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    PaymentDetailsComponent,
    PaymentDetailComponent,
    PaymentDetailListComponent,
    ConfirmModalComponent,
    ConfirmTemplateDirective
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    NgxMaskModule.forRoot()    
  ],
  providers: [
    PaymentDetailService,
    ConfirmService,
    ConfirmState
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
