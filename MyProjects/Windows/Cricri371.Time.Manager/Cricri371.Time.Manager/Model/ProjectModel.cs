using System.Collections.Generic;
using System.Linq;

using Cricri371.Framework.Databases.EntityFramework.Program;
using Cricri371.Time.Manager.Dto;

namespace Cricri371.Time.Manager.Model
{
    /// <summary>
    /// Class ProjectModel.
    /// </summary>
    public class ProjectModel
    {
        #region CheckProjectIsUsed

        /// <summary>
        /// Checks the project is used.
        /// </summary>
        /// <param name="projectID"> The project identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckProjectIsUsed(int projectID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.TaskLinkedToProject.Where(p => p.ID_Project == projectID).Any();
        }

        #endregion CheckProjectIsUsed

        #region CheckProjectExists

        /// <summary>
        /// Checks the project exists.
        /// </summary>
        /// <param name="projectName">   Name of the project. </param>
        /// <param name="shortName">     The short name. </param>
        /// <param name="applicationID"> The application identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckProjectExists(string projectName, string shortName, int applicationID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Project.Where(p => p.Name == projectName && p.ShortName == shortName && p.ID_Application == applicationID).Any();
        }

        /// <summary>
        /// Checks the project exists.
        /// </summary>
        /// <param name="projectID">     The project identifier. </param>
        /// <param name="projectName">   Name of the project. </param>
        /// <param name="shortName">     The short name. </param>
        /// <param name="applicationID"> The application identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckProjectExists(int projectID, string projectName, string shortName, int applicationID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Project.Where(p => p.ID_Project != projectID && p.Name == projectName && p.ShortName == shortName && p.ID_Application == applicationID).Any();
        }

        #endregion CheckProjectExists

        #region GetProjectByID

        /// <summary>
        /// Gets the project by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> The selected project. </returns>
        private Projects GetProjectByID(int id)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Project.FirstOrDefault(p => p.ID_Project == id);
        }

        #endregion GetProjectByID

        #region GetProjects

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns> List of ProjectDto. </returns>
        public IOrderedEnumerable<ProjectDto> GetProjects()
        {
            var projects = new List<ProjectDto>();

            foreach (var proj in EntityContext<Cricri371TimeManagerEntities>.GetContext.Project)
            {
                var project = new ProjectDto()
                {
                    ID = proj.ID_Project,
                    Name = proj.Name,
                    ShortName = proj.ShortName,
                    Application = new ApplicationDto()
                    {
                        ID = proj.Application.ID_Application,
                        Name = proj.Application.Name,
                        Company = new CompanyDto()
                        {
                            ID = proj.Application.Company.ID_Company,
                            Name = proj.Application.Company.Name
                        }
                    }
                };

                var result = proj.TaskLinkedToProject.Count;
                foreach (var task in proj.TaskLinkedToProject.OrderBy(t => t.Task.Name))
                {
                    project.Tasks.Add(new TaskDto() { ID = task.Task.ID_Task, Name = task.Task.Name });
                }

                projects.Add(project);
            }

            return projects.OrderBy(a => a.ApplicationProjectShortName);
        }

        #endregion GetProjects

        #region AddProject

        /// <summary>
        /// Adds the project.
        /// </summary>
        /// <param name="projectToAdd"> The project to add. </param>
        public void AddProject(ProjectDto projectToAdd)
        {
            var project = new Projects
            {
                Name = projectToAdd.Name,
                ID_Application = projectToAdd.Application.ID,
                ShortName = projectToAdd.ShortName
            };

            EntityContext<Cricri371TimeManagerEntities>.GetContext.Project.AddObject(project);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion AddProject

        #region UpdateProject

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="projectToModify"> The project to modify. </param>
        public void UpdateProject(ProjectDto projectToModify)
        {
            var project = GetProjectByID(projectToModify.ID);
            project.Name = projectToModify.Name;
            project.ShortName = projectToModify.ShortName;
            project.ID_Application = projectToModify.Application.ID;

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion UpdateProject

        #region DeleteProject

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="projectToDelete"> The project to delete. </param>
        public void DeleteProject(ProjectDto projectToDelete)
        {
            var project = GetProjectByID(projectToDelete.ID);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.DeleteObject(project);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion DeleteProject

        #region AddTaskToProject

        /// <summary>
        /// Adds the task to project.
        /// </summary>
        /// <param name="project">   The project. </param>
        /// <param name="taskToAdd"> The task to add. </param>
        public void AddTaskToProject(ProjectDto project, TaskDto taskToAdd)
        {
            var existingProject = GetProjectByID(project.ID);

            existingProject.TaskLinkedToProject.Add(new TaskLinkedToProject
            {
                ID_Project = existingProject.ID_Project,
                ID_Task = taskToAdd.ID
            });

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion AddTaskToProject

        #region RemoveTaskFromProject

        /// <summary>
        /// Removes the task from project.
        /// </summary>
        /// <param name="project">   The project. </param>
        /// <param name="taskToRemove"> The task to remove. </param>
        public void RemoveTaskFromProject(ProjectDto project, TaskDto taskToRemove)
        {
            var existingProject = GetProjectByID(project.ID);

            var taskLinkedToProject = EntityContext<Cricri371TimeManagerEntities>.GetContext.TaskLinkedToProject.First(t => t.ID_Task == taskToRemove.ID && t.ID_Project == project.ID);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.DeleteObject(taskLinkedToProject);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion RemoveTaskFromProject

        #region CheckTaskInProjectIsUsed

        /// <summary>
        /// Checks the task in project is used.
        /// </summary>
        /// <param name="taskID">    The task identifier. </param>
        /// <param name="projectID"> The project identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckTaskInProjectIsUsed(int taskID, int projectID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.Where(p =>
                p.TaskLinkedToProject.ID_Project == projectID &&
                p.TaskLinkedToProject.ID_Task == taskID).Any();
        }

        #endregion CheckTaskInProjectIsUsed

        #region CheckTaskAlreadyLinkedToProject

        /// <summary>
        /// Checks the task already linked to project.
        /// </summary>
        /// <param name="taskID">    The task identifier. </param>
        /// <param name="projectID"> The project identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckTaskAlreadyLinkedToProject(int taskID, int projectID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.TaskLinkedToProject.Where(t => t.ID_Project == projectID && t.ID_Task == taskID).Any();
        }

        #endregion CheckTaskAlreadyLinkedToProject
    }
}