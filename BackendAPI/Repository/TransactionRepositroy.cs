using BackendAPI.Context;
using BackendAPI.Data;

namespace BackendAPI.Repository
{
    public class TransactionRepositroy : ITransactionRepositroy
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepositroy(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CreateBpkb(Bpkb bpkb)
        {
            try
            {
                _context.Bpkbs.Add(bpkb);
                _context.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "failed";
            }
        }

        public bool DeleteBpkb(string agreementNumber)
        {
            try
            {
                var bpkb = _context.Bpkbs.FirstOrDefault(b => b.agreement_number == agreementNumber);
                if (bpkb == null)
                {
                    return false;
                }

                _context.Bpkbs.Remove(bpkb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<Bpkb>? GetBpkb()
        {
            try
            {
                return _context.Bpkbs.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Bpkb? GetBpkbByAgreementNumber(string agreementNumber)
        {
            try
            {
                return _context.Bpkbs.FirstOrDefault(b => b.agreement_number == agreementNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public string UpdateBpkb(Bpkb bpkb)
        {
            try
            {
                var existingBpkb = _context.Bpkbs.FirstOrDefault(b => b.agreement_number == bpkb.agreement_number);
                if (existingBpkb == null)
                {
                    return "failed";
                }

                existingBpkb.bpkb_no = bpkb.bpkb_no;
                existingBpkb.branch_id = bpkb.branch_id;
                existingBpkb.bpkb_date = bpkb.bpkb_date;
                existingBpkb.faktur_no = bpkb.faktur_no;
                existingBpkb.faktur_date = bpkb.faktur_date;
                existingBpkb.location_id = bpkb.location_id;
                existingBpkb.police_no = bpkb.police_no;
                existingBpkb.bpkb_date_in = bpkb.bpkb_date_in;
                existingBpkb.created_by = bpkb.created_by;
                existingBpkb.created_on = bpkb.created_on;
                existingBpkb.last_updated_by = bpkb.last_updated_by;
                existingBpkb.last_updated_on = bpkb.last_updated_on;

                _context.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "failed";
            }
        }

    }
}
