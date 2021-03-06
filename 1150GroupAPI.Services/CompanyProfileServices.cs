using _1150GroupAPI.Data;
using _1150GroupAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class CompanyProfileServices
    {
        private Guid _userID;
        public CompanyProfileServices(Guid userid)
        {
            _userID = userid;
        }
        public bool CreateCompany(CompanyProfileCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var companyentity = new CompanyProfile();

                
                               

                companyentity.CompanyName = model.CompanyName;
                if(model.CategoryID != 0)
                    companyentity.CategoryID = model.CategoryID;



                ctx.Companies.Add(companyentity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CompanyProfileListItem> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Companies
                    .Select(
                        e =>
                        new CompanyProfileListItem
                        {
                            CompanyID = e.CompanyID,
                            CompanyName = e.CompanyName,
                            CategoryID = e.CategoryID,

                            

                        });
                return query.ToArray();
            }
        }
        public CompanyProfileDetail GetCompanyByCompanyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var company = 
                    ctx
                    .Companies
                    .Single(p => p.CompanyID == id);
                   return new CompanyProfileDetail
                    {
                      CompanyName = company.CompanyName,
                      CategoryID = company.CategoryID
                    };
               
            }
        }
        public bool DeleteCompanyProfile(int companyid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Companies
                    .Single(e => e.CompanyID == companyid);

                ctx.Companies.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateCompany(CompanyProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Companies
                    .Single(e => e.CompanyID == model.CompanyID);

                entity.CompanyID = model.CompanyID;
                entity.CompanyName = model.CompanyName;
                entity.CategoryID = model.CategoryID;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
