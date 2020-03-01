import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';
import { ConfirmService } from 'src/app/shared/confirm-modal-and-service';

@Component({
  selector: 'app-payment-detail-list',
  templateUrl: './payment-detail-list.component.html',
  styles: []
})
export class PaymentDetailListComponent implements OnInit {

  constructor(private service:PaymentDetailService,
              private toastr:ToastrService,
              private confirmService:ConfirmService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(item:PaymentDetail) {
    this.service.formData = Object.assign({}, item); // to avoid changing value to datatable when changing value in form
  }

  onDelete(id:number){        
    this.confirmService.confirm({title: "Confirm Deletion", message: "Are you sure to delete this record?"})
      .then(
        yes => {
          console.log("Deleting!");
          this.service.deletePaymentDetail(id)
          .subscribe(
            res => {
              this.service.refreshList();
              this.toastr.success("Payment detail deleted successully.", "Payment Detail Deletion");
            },
            err => {
              console.log(err);
            }
          )
        },
        no => {
          console.log("Not Deleting!");
        }
      )
  }

}
