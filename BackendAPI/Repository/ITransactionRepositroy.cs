using BackendAPI.Data;

namespace BackendAPI.Repository
{
    public interface ITransactionRepositroy
    {
        string CreateBpkb(Bpkb bpkb);
        Bpkb? GetBpkbByAgreementNumber(string agreementNumber);
        List<Bpkb>? GetBpkb();
        string UpdateBpkb(Bpkb bpkb);
        bool DeleteBpkb(string agreementNumber);
    }
}
