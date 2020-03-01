using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class PaymentDetailService : IPaymentDetailService
    {
        public ApplicationDbContext _context;
        public PaymentDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            _context.SaveChanges();
        }

        public PaymentDetail Delete(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Remove(paymentDetail);
            _context.SaveChanges();

            return paymentDetail;
        }

        public PaymentDetail GetPaymentDetail(int id)
        {
            return _context.PaymentDetails.Find(id);
        }

        public IEnumerable<PaymentDetail> GetPaymentDetails()
        {
            return _context.PaymentDetails;
        }

        /*
public async Task<PaymentDetail> Delete(PaymentDetail paymentDetail)
{
   _context.PaymentDetails.Remove(paymentDetail);
   await _context.SaveChangesAsync();

   return paymentDetail;
}

public async Task<PaymentDetail> GetPaymentDetail(int id)
{
   return await _context.PaymentDetails.FindAsync(id);
}

public async Task<IEnumerable<PaymentDetail>> GetPaymentDetailsAsync()
{
   var list = await _context.PaymentDetails.ToListAsync();

   return list;
}

public async Task Create(PaymentDetail paymentDetail)
{
   _context.PaymentDetails.Add(paymentDetail);
   await _context.SaveChangesAsync();
}

public async Task Update(int id, PaymentDetail paymentDetail)
{
   _context.Entry(paymentDetail).State = EntityState.Modified;

   try
   {
       await _context.SaveChangesAsync();
   }
   catch (DbUpdateConcurrencyException exception)
   {
       if (!PaymentDetailExists(id))
       {
           throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
       }
       else
       {
           throw;
       }
   }
}
*/

        public bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(m => m.Id == id);
        }

        public void Update(int id, PaymentDetail paymentDetail)
        {
            _context.Entry(paymentDetail).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                if (!PaymentDetailExists(id))
                {
                    throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
                }
                else { throw; }
            }
        }

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }

            _context.SaveChanges();
            return exception.ToString();
        }
    }
}
