namespace ProjectManagerApi.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<object>> GetAllCompaniesAsync();
    }
}
