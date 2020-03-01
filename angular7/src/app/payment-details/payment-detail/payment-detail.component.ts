import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private service:PaymentDetailService,
              private toastr:ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form != null){
      form.resetForm();
    }
      
    this.service.formData = {
      Id: 0,
      CardName: '',
      CardNumber: '',
      ExpirationDate: '',
      CVV: ''
    }
  }

  onSubmit(form:NgForm){
    console.log("Id: ", this.service.formData.Id);
    // if Id is 0, meaning new item
    if(this.service.formData.Id == 0){      
      this.insertRecord(form);
    }
    else{
      // update record
      this.updateRecord(form);      
    }    
  }

  insertRecord(form:NgForm){
    this.service.postPaymentDetail()
    .subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success("Submitted successfully.", "Payment Detail Registration");        
      },
      err => {
        console.log(err);
      }
    )
  }

  updateRecord(form:NgForm){
    this.service.putPaymentDetail()
    .subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success("Updated successfully.", "Payment Detail Modification");
      },
      err => {
        console.log(err);
      }
    )
  }
}
