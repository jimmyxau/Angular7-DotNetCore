using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Infrastructure;
using Core.Models;
using Core.Services;

namespace CardPaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private IPaymentDetailService _paymentDetailService;

        public PaymentDetailsController(IPaymentDetailService paymentDetailService)
        {
            _paymentDetailService = paymentDetailService;
        }

        [HttpGet]
        public IEnumerable<PaymentDetail> GetPaymentDetails()
        {
            return _paymentDetailService.GetPaymentDetails();
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentDetail> GetPaymentDetail(int id)
        {
            var paymentDetail = _paymentDetailService.GetPaymentDetail(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }
        
        // PUT: api/PaymentDetails/5
        [HttpPut("{id}")]
        public IActionResult PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (paymentDetail == null)
            {
                return BadRequest();
            }

            if (id != paymentDetail.Id)
            {
                return BadRequest();
            }

            _paymentDetailService.Update(id, paymentDetail);

            return NoContent();
        }

        // POST: api/PaymentDetails
        [HttpPost]
        public IActionResult PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _paymentDetailService.Create(paymentDetail);

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.Id }, paymentDetail);
        }

        [HttpDelete("{id}")]
        public ActionResult<PaymentDetail> DeletePaymentDetail(int id)
        {
            var paymentDetail = _paymentDetailService.GetPaymentDetail(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _paymentDetailService.Delete(paymentDetail);

            return paymentDetail;
        }

        /*
        private readonly ApplicationDbContext _context;

        public PaymentDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetails
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.Id }, paymentDetail);
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.Id == id);
        }
        */
    }
}
