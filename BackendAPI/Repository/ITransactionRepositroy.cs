using BackendAPI.Data;
using BackendAPI.ViewModel;

namespace BackendAPI.Repository
{
    public interface ITransactionRepositroy
    {
        string CreateBpkb(Bpkb bpkb);
        Bpkb? GetBpkbByAgreementNumber(string agreementNumber);
        List<BpkbVM>? GetBpkb();
        string UpdateBpkb(Bpkb bpkb);
        bool DeleteBpkb(string agreementNumber);
    }
}
