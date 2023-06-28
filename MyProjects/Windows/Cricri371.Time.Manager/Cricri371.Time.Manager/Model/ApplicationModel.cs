using System.Collections.Generic;
using System.Linq;

using Cricri371.Framework.Databases.EntityFramework.Program;
using Cricri371.Time.Manager.Dto;

namespace Cricri371.Time.Manager.Model
{
    /// <summary>
    /// Class ApplicationModel.
    /// </summary>
    public class ApplicationModel
    {
        #region CheckApplicationIsUsed

        /// <summary>
        /// Checks the application is used.
        /// </summary>
        /// <param name="applicationID"> The application identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckApplicationIsUsed(int applicationID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Project.Where(p => p.ID_Application == applicationID).Any();
        }

        #endregion CheckApplicationIsUsed

        #region CheckApplicationExists

        /// <summary>
        /// Checks the application exists.
        /// </summary>
        /// <param name="applicationName"> Name of the application. </param>
        /// <param name="companyID">       The company identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckApplicationExists(string applicationName, int companyID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Application.Where(a => a.Name == applicationName && a.Company.ID_Company == companyID).Any();
        }

        /// <summary>
        /// Checks the application exists.
        /// </summary>
        /// <param name="applicationID">   The application identifier. </param>
        /// <param name="applicationName"> Name of the application. </param>
        /// <param name="companyID">       The company identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckApplicationExists(int applicationID, string applicationName, int companyID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Application.Where(a => a.Name == applicationName && a.Company.ID_Company == companyID && a.ID_Application != applicationID).Any();
        }

        #endregion CheckApplicationExists

        #region GetApplicationByID

        /// <summary>
        /// Gets the application by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> The application. </returns>
        private Applications GetApplicationByID(int id)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Application.FirstOrDefault(a => a.ID_Application == id);
        }

        #endregion GetApplicationByID

        #region GetApplications

        /// <summary>
        /// Gets the applications.
        /// </summary>
        /// <returns> Ordered list of ApplicationDto. </returns>
        public IOrderedEnumerable<ApplicationDto> GetApplications()
        {
            var applications = new List<ApplicationDto>();

            foreach (var app in EntityContext<Cricri371TimeManagerEntities>.GetContext.Application)
            {
                applications.Add(new ApplicationDto()
                {
                    ID = app.ID_Application,
                    Name = app.Name,
                    Company = new CompanyDto()
                    {
                        ID = app.Company.ID_Company,
                        Name = app.Company.Name
                    }
                });
            }

            return applications.OrderBy(a => a.Name);
        }

        #endregion GetApplications

        #region AddApplication

        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <param name="applicationToAdd"> The application to add. </param>
        public void AddApplication(ApplicationDto applicationToAdd)
        {
            var application = new Applications
            {
                Name = applicationToAdd.Name,
                ID_Company = applicationToAdd.Company.ID
            };

            EntityContext<Cricri371TimeManagerEntities>.GetContext.Application.AddObject(application);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion AddApplication

        #region UpdateApplication

        /// <summary>
        /// Updates the application.
        /// </summary>
        /// <param name="applicationToModify"> The application to modify. </param>
        public void UpdateApplication(ApplicationDto applicationToModify)
        {
            var application = GetApplicationByID(applicationToModify.ID);
            application.Name = applicationToModify.Name;
            application.ID_Company = applicationToModify.Company.ID;

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion UpdateApplication

        #region DeleteApplication

        /// <summary>
        /// Deletes the application.
        /// </summary>
        /// <param name="applicationToDelete"> The application to delete. </param>
        public void DeleteApplication(ApplicationDto applicationToDelete)
        {
            var application = GetApplicationByID(applicationToDelete.ID);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.DeleteObject(application);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion DeleteApplication
    }
}