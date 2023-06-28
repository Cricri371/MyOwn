using System.Collections.Generic;
using System.Linq;

using Cricri371.Framework.Databases.EntityFramework.Program;
using Cricri371.Time.Manager.Dto;

namespace Cricri371.Time.Manager.Model
{
    /// <summary>
    /// Class TaskModel.
    /// </summary>
    public class TaskModel
    {
        #region CheckTaskIsUsed

        /// <summary>
        /// Checks the task is used.
        /// </summary>
        /// <param name="taskID"> The task identifier. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckTaskIsUsed(int taskID)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.TaskLinkedToProject.Where(p => p.ID_Task == taskID).Any();
        }

        #endregion CheckTaskIsUsed

        #region CheckTaskExists

        /// <summary>
        /// Checks the task exists.
        /// </summary>
        /// <param name="taskName"> Name of the task. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckTaskExists(string taskName)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Task.Where(t => t.Name == taskName).Any();
        }

        /// <summary>
        /// Checks the task exists.
        /// </summary>
        /// <param name="taskID">   The task identifier. </param>
        /// <param name="taskName"> Name of the task. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckTaskExists(int taskID, string taskName)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Task.Where(t => t.Name == taskName && t.ID_Task != taskID).Any();
        }

        #endregion CheckTaskExists

        #region GetTaskByID

        /// <summary>
        /// Gets the task by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> The task. </returns>
        public Tasks GetTaskByID(int id)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.Task.FirstOrDefault(t => t.ID_Task == id);
        }

        #endregion GetTaskByID

        #region GetTasks

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        /// <returns> Ordered list of TaskDto. </returns>
        public IOrderedEnumerable<TaskDto> GetTasks()
        {
            var tasks = new List<TaskDto>();

            foreach (var task in EntityContext<Cricri371TimeManagerEntities>.GetContext.Task)
            {
                tasks.Add(new TaskDto()
                {
                    ID = task.ID_Task,
                    Name = task.Name
                });
            }

            return tasks.OrderBy(t => t.Name);
        }

        #endregion GetTasks

        #region AddTask

        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="taskToAdd"> The task to add. </param>
        public void AddTask(TaskDto taskToAdd)
        {
            var task = new Tasks
            {
                Name = taskToAdd.Name
            };

            EntityContext<Cricri371TimeManagerEntities>.GetContext.Task.AddObject(task);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion AddTask

        #region UpdateTask

        /// <summary>
        /// Updates the task.
        /// </summary>
        /// <param name="taskToModify"> The task to modify. </param>
        public void UpdateTask(TaskDto taskToModify)
        {
            var task = GetTaskByID(taskToModify.ID);
            task.Name = taskToModify.Name;

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion UpdateTask

        #region DeleteTask

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="taskToDelete"> The task to delete. </param>
        public void DeleteTask(TaskDto taskToDelete)
        {
            var task = GetTaskByID(taskToDelete.ID);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.DeleteObject(task);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion DeleteTask
    }
}