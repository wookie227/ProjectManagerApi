namespace ProjectManagerApi.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<object>> GetAllCompaniesAsync();
    }
}
