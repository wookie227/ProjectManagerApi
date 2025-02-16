using ProjectManagerApi.Database;
using Microsoft.EntityFrameworkCore;


namespace ProjectManagerApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetAllCompaniesAsync()
        {
            var companies = await _context.Companies.ToListAsync();

            return companies;
        }
    }
}
