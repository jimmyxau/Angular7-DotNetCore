import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PaymentDetail } from './payment-detail.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
  formData: PaymentDetail;
  list: PaymentDetail[];

  constructor(private http:HttpClient) { }

  refreshList()
  {
    this.http.get(environment.apiURL + "/PaymentDetails")
    .toPromise()
    .then(res => this.list = res as PaymentDetail[]);
  }

  getPaymentDetail(id:number)
  {
    this.http.get(environment.apiURL + "/PaymentDetails/" + id)
    .toPromise()
    .then(res => this.formData = res as PaymentDetail);
  }

  postPaymentDetail(){
    return this.http.post(environment.apiURL + "/PaymentDetails", this.formData);
  }

  putPaymentDetail(){
    return this.http.put(environment.apiURL + "/PaymentDetails/" + this.formData.Id, this.formData);
  }  

  deletePaymentDetail(id:number){
    return this.http.delete(environment.apiURL + "/PaymentDetails/" + id);
  }
}
