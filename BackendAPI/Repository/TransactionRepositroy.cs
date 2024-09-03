using BackendAPI.Context;
using BackendAPI.Data;
using BackendAPI.ViewModel;

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

        public List<BpkbVM>? GetBpkb()
        {
            try
            {
                return (from a in _context.Bpkbs
                        join b in _context.StorageLocations on a.location_id equals b.location_id
                        select new BpkbVM
                        {
                            agreement_number = a.agreement_number,
                            bpkb_no = a.bpkb_no,
                            branch_id = a.branch_id,
                            bpkb_date = a.bpkb_date,
                            faktur_no = a.faktur_no,
                            faktur_date = a.faktur_date,
                            location_id = b.location_id,
                            location_name = b.location_name,
                            police_no = a.police_no,
                            bpkb_date_in = a.bpkb_date_in,
                            created_by = a.created_by,
                            created_on = a.created_on,
                            last_updated_by = a.last_updated_by,
                            last_updated_on = a.last_updated_on
                        }).ToList();

            }
            catch (Exception ex)
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
