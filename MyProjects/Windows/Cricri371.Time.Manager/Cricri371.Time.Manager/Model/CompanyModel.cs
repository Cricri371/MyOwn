using System.Collections.Generic;
using System.Linq;

using Cricri371.Framework.Databases.EntityFramework.Program;
using Cricri371.Time.Manager.Dto;

namespace Cricri371.Time.Manager.Model
{
    /// <summary>
    /// Class CompanyModel.
    /// </summary>
    public class CompanyModel
    {
        #region CheckCompanyIsUsed

        /// <summary>
        /// Checks the company is used.
        /// </summary>
        /// <param name="companyID"> The company identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckCompanyIsUsed(int companyID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Application.Where(p => p.ID_Company == companyID).Any();
        }

        #endregion CheckCompanyIsUsed

        #region CheckCompanyExists

        /// <summary>
        /// Checks the company exists.
        /// </summary>
        /// <param name="companyName"> Name of the company. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckCompanyExists(string companyName)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Company.Where(t => t.Name == companyName).Any();
        }

        /// <summary>
        /// Checks the company exists.
        /// </summary>
        /// <param name="companyID">   The company identifier. </param>
        /// <param name="companyName"> Name of the company. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckCompanyExists(int companyID, string companyName)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Company.Where(t => t.ID_Company != companyID && t.Name == companyName).Any();
        }

        #endregion CheckCompanyExists

        #region GetCompanyByID

        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> The company. </returns>
        private Companies GetCompanyByID(int id)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Company.FirstOrDefault(c => c.ID_Company == id);
        }

        #endregion GetCompanyByID

        #region GetCompanies

        /// <summary>
        /// Gets the companies.
        /// </summary>
        /// <returns> The ordered list of CompanyDto. </returns>
        public IOrderedEnumerable<CompanyDto> GetCompanies()
        {
            var companies = new List<CompanyDto>();

            foreach (var company in EntityContext<Cricri371TimeManagerEntities>.GetContext.Company)
            {
                companies.Add(new CompanyDto()
                {
                    ID = company.ID_Company,
                    Name = company.Name
                });
            }

            return companies.OrderBy(t => t.Name);
        }

        #endregion GetCompanies

        #region AddCompany

        /// <summary>
        /// Adds the company.
        /// </summary>
        /// <param name="companyToAdd"> The company to add. </param>
        public void AddCompany(CompanyDto companyToAdd)
        {
            var company = new Companies
            {
                Name = companyToAdd.Name
            };

            EntityContext<Cricri371TimeManagerEntities>.GetContext.Company.AddObject(company);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion AddCompany

        #region UpdateCompany

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="companyToModify"> The company to modify. </param>
        public void UpdateCompany(CompanyDto companyToModify)
        {
            var company = GetCompanyByID(companyToModify.ID);
            company.Name = companyToModify.Name;

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion UpdateCompany

        #region DeleteCompany

        /// <summary>
        /// Deletes the company.
        /// </summary>
        /// <param name="companyToDelete"> The company to delete. </param>
        public void DeleteCompany(CompanyDto companyToDelete)
        {
            var company = GetCompanyByID(companyToDelete.ID);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.DeleteObject(company);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion DeleteCompany
    }
}