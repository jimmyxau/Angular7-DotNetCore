using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPaymentDetailService
    {
        //Task<IEnumerable<PaymentDetail>> GetPaymentDetailsAsync();
        //Task<PaymentDetail> GetPaymentDetail(int id);
        //Task Update(int id, PaymentDetail paymentDetail);
        //Task Create(PaymentDetail paymentDetail);
        //Task<PaymentDetail> Delete(PaymentDetail paymentDetail);
        //bool PaymentDetailExists(int id);

        IEnumerable<PaymentDetail> GetPaymentDetails();
        PaymentDetail GetPaymentDetail(int id);
        void Update(int id, PaymentDetail paymentDetail);
        void Create(PaymentDetail paymentDetail);
        PaymentDetail Delete(PaymentDetail paymentDetail);
        bool PaymentDetailExists(int id);
    }
}
