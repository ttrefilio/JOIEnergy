namespace JOIEnergy.Application.Services
{
    public interface IAccountService
    {
        string GetPricePlanIdForSmartMeterId(string smartMeterId);
    }
}