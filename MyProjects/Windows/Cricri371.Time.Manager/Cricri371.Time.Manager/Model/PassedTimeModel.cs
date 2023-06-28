using System;
using System.Collections.Generic;
using System.Linq;

using Cricri371.Framework.Configuration.AppSettings;
using Cricri371.Framework.Databases.EntityFramework.Program;
using Cricri371.Framework.Tools.Linq;
using Cricri371.Time.Manager.Dto;

using GalaSoft.MvvmLight.Messaging;

namespace Cricri371.Time.Manager.Model
{
    /// <summary>
    /// Class PassedTimeModel.
    /// </summary>
    public class PassedTimeModel
    {
        #region GetPassedTimes

        /// <summary>
        /// Gets the passed times.
        /// </summary>
        /// <param name="targetDate">    The target date. </param>
        /// <param name="endTargetDate"> The end target date. </param>
        /// <returns> The ordered list of PassedTimeDto. </returns>
        public IOrderedEnumerable<PassedTimeDto> GetPassedTimes(DateTime targetDate, DateTime? endTargetDate)
        {
            var passedTimes = new List<PassedTimeDto>();
            IQueryable<PassedTimes> result = null;
            if (endTargetDate.HasValue)
            {
                result = EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.BetweenDates(p => p.StartDateTime, p => p.EndDateTime, targetDate, endTargetDate.Value);
            }
            else
            {
                result = EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.BetweenDates(p => p.StartDateTime, p => p.EndDateTime, targetDate);
            }

            foreach (var r in result)
            {
                passedTimes.Add(new PassedTimeDto()
                {
                    ID = r.ID_PassedTime,
                    Project = new ProjectDto()
                    {
                        Application = new ApplicationDto() { ID = r.TaskLinkedToProject.Project.Application.ID_Application, Name = r.TaskLinkedToProject.Project.Application.Name },
                        ID = r.TaskLinkedToProject.Project.ID_Project,
                        Name = r.TaskLinkedToProject.Project.Name,
                        ShortName = r.TaskLinkedToProject.Project.ShortName
                    },
                    Comment = r.Comment,
                    EndDateTime = r.EndDateTime,
                    StartDatetime = r.StartDateTime,
                    Task = new TaskDto() { ID = r.TaskLinkedToProject.Task.ID_Task, Name = r.TaskLinkedToProject.Task.Name }
                });
            }

            return passedTimes.OrderBy(pT => pT.StartDatetime);
        }

        #endregion GetPassedTimes

        #region GetPassedTimeByID

        /// <summary>
        /// Gets the passed time by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> The PassedTimes. </returns>
        private PassedTimes GetPassedTimeByID(int id)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.FirstOrDefault(pT => pT.ID_PassedTime == id);
        }

        #endregion GetPassedTimeByID

        #region AddPassedTime

        /// <summary>
        /// Adds the passed time.
        /// </summary>
        /// <param name="startDateTime"> The start date time. </param>
        /// <param name="endDateTime">   The end date time. </param>
        /// <param name="comment">       The comment. </param>
        /// <param name="projectID">     The project identifier. </param>
        /// <param name="taskID">        The task identifier. </param>
        public void AddPassedTime(DateTime startDateTime, DateTime endDateTime, string comment, int projectID, int taskID)
        {
            AddPassedTime(startDateTime, endDateTime, comment, new ProjectDto() { ID = projectID }, new TaskDto() { ID = taskID });
        }

        /// <summary>
        /// Adds the passed time.
        /// </summary>
        /// <param name="startDateTime"> The start date time. </param>
        /// <param name="endDateTime">   The end date time. </param>
        /// <param name="comment">       The comment. </param>
        /// <param name="project">       The project. </param>
        /// <param name="task">          The task. </param>
        public void AddPassedTime(DateTime startDateTime, DateTime endDateTime, string comment, ProjectDto project, TaskDto task)
        {
            var taskProject = EntityContext<Cricri371TimeManagerEntities>.GetContext.TaskLinkedToProject.First(t => t.ID_Project == project.ID && t.ID_Task == task.ID);
            var passedTimeToAdd = new PassedTimes
            {
                TaskLinkedToProject = taskProject,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                Comment = comment
            };

            EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.AddObject(passedTimeToAdd);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion AddPassedTime

        #region ClosePassedTime

        /// <summary>
        /// Closes the passed time.
        /// </summary>
        /// <param name="passedTimeDto"> The passed time dto. </param>
        /// <param name="comment">       The comment. </param>
        public void ClosePassedTime(PassedTimeDto passedTimeDto, string comment)
        {
            var passedTime = GetPassedTimeByID(passedTimeDto.ID);
            passedTime.EndDateTime = DateTime.Now.AddSeconds(-1);
            passedTime.Comment = comment;

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion ClosePassedTime

        #region UpdatePassedTime

        /// <summary>
        /// Updates the passed time.
        /// </summary>
        /// <param name="passedTime"> The passed time. </param>
        public void UpdatePassedTime(PassedTimeDto passedTime)
        {
            var result = EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.FirstOrDefault(p => p.ID_PassedTime == passedTime.ID);
            if (result != null)
            {
                if (result.StartDateTime == passedTime.StartDatetime && result.EndDateTime == passedTime.EndDateTime)
                {
                    var taskProject = EntityContext<Cricri371TimeManagerEntities>.GetContext.TaskLinkedToProject.First(t => t.ID_Project == passedTime.Project.ID && t.ID_Task == passedTime.Task.ID);
                    result.TaskLinkedToProject = taskProject;
                    result.Comment = passedTime.Comment;

                    EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
                }
                else
                {
                    DeletePassedTime(result.ID_PassedTime);

                    AddPassedTimePastAndFuture(passedTime.StartDatetime, passedTime.EndDateTime, passedTime.Comment, passedTime.Project, passedTime.Task, "OverridePassedTimesUpdate");
                }
            }
        }

        #endregion UpdatePassedTime

        #region CheckActiveTasksExist

        /// <summary>
        /// Checks the active tasks exist.
        /// </summary>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckActiveTasksExist()
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.Any(p => p.EndDateTime == DateTime.MaxValue.Date);
        }

        #endregion CheckActiveTasksExist

        #region CheckOverlapsExistingTasks

        /// <summary>
        /// Checks the overlaps existing tasks.
        /// </summary>
        /// <param name="targetDate">    The target date. </param>
        /// <param name="endTargetDate"> The end target date. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool CheckOverlapsExistingTasks(DateTime targetDate, DateTime endTargetDate)
        {
            return EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.BetweenDates(p => p.StartDateTime, p => p.EndDateTime, targetDate, endTargetDate).Any();
        }

        #endregion CheckOverlapsExistingTasks

        #region AutoCloseTasks

        /// <summary>
        /// Automatics the close tasks.
        /// </summary>
        /// <param name="targetDateTime">  The target date time. </param>
        /// <param name="closingDateTime"> The closing date time. </param>
        public void AutoCloseTasks(DateTime targetDateTime, DateTime closingDateTime)
        {
            foreach (var passedTime in EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.Where(p => p.StartDateTime >= targetDateTime && p.EndDateTime == DateTime.MaxValue.Date))
            {
                passedTime.EndDateTime = closingDateTime.AddSeconds(-1);

                EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
            }
        }

        #endregion AutoCloseTasks

        #region ClosePreviousTasks

        /// <summary>
        /// Closes the previous tasks.
        /// </summary>
        /// <param name="targetDateTime"> The target date time. </param>
        public void ClosePreviousTasks(DateTime targetDateTime)
        {
            foreach (var passedTime in EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.Where(p => p.EndDateTime == DateTime.MaxValue.Date))
            {
                if (passedTime.StartDateTime.Date != targetDateTime)
                {
                    passedTime.EndDateTime = passedTime.StartDateTime.Date.AddDays(1).AddSeconds(-1);

                    EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
                }
            }
        }

        #endregion ClosePreviousTasks

        #region DeletePassedTime

        /// <summary>
        /// Deletes the passed time.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public void DeletePassedTime(int id)
        {
            var passedTime = GetPassedTimeByID(id);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.DeleteObject(passedTime);

            EntityContext<Cricri371TimeManagerEntities>.GetContext.SaveChanges();
        }

        #endregion DeletePassedTime

        #region GetFilteredPassedTimes

        /// <summary>
        /// Gets the filtered passed times.
        /// </summary>
        /// <param name="beginDate">           The begin date. </param>
        /// <param name="endDate">             The end date. </param>
        /// <param name="taskIDFilter">        The task identifier filter. </param>
        /// <param name="applicationIDFilter"> The application identifier filter. </param>
        /// <param name="projectIDFilter">     The project identifier filter. </param>
        /// <param name="companyIDFilter">     The company identifier filter. </param>
        /// <returns> The ordered list of PassedTimeDto. </returns>
        public IOrderedEnumerable<PassedTimeDto> GetFilteredPassedTimes(DateTime beginDate, DateTime endDate, int? taskIDFilter, int? applicationIDFilter, int? projectIDFilter, int? companyIDFilter)
        {
            var passedTimes = new List<PassedTimeDto>();
            var result = EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.BetweenDates(p => p.StartDateTime, p => p.EndDateTime, beginDate, endDate);

            if (projectIDFilter.HasValue)
            {
                result = result.Where(r => r.TaskLinkedToProject.ID_Project == projectIDFilter.Value);
            }

            if (companyIDFilter.HasValue)
            {
                result = result.Where(r => r.TaskLinkedToProject.Project.Application.ID_Company == companyIDFilter.Value);
            }

            if (taskIDFilter.HasValue)
            {
                result = result.Where(r => r.TaskLinkedToProject.ID_Task == taskIDFilter.Value);
            }

            if (applicationIDFilter.HasValue)
            {
                result = result.Where(r => r.TaskLinkedToProject.Project.ID_Application == applicationIDFilter.Value);
            }

            foreach (var r in result)
            {
                passedTimes.Add(new PassedTimeDto()
                {
                    ID = r.ID_PassedTime,
                    Project = new ProjectDto()
                    {
                        ID = r.TaskLinkedToProject.Project.ID_Project,
                        Name = r.TaskLinkedToProject.Project.Name,
                        ShortName = r.TaskLinkedToProject.Project.ShortName,
                        Application = new ApplicationDto()
                        {
                            ID = r.TaskLinkedToProject.Project.Application.ID_Application,
                            Name = r.TaskLinkedToProject.Project.Application.Name,
                            Company = new CompanyDto()
                            {
                                ID = r.TaskLinkedToProject.Project.Application.Company.ID_Company,
                                Name = r.TaskLinkedToProject.Project.Application.Company.Name
                            }
                        }
                    },
                    Comment = r.Comment,
                    EndDateTime = r.EndDateTime,
                    StartDatetime = r.StartDateTime,
                    Task = new TaskDto() { ID = r.TaskLinkedToProject.Task.ID_Task, Name = r.TaskLinkedToProject.Task.Name }
                });
            }

            return passedTimes.OrderBy(pT => pT.StartDatetime);
        }

        #endregion GetFilteredPassedTimes

        #region AddPassedTimePastAndFuture

        /// <summary>
        /// Adds the passed time past and future.
        /// </summary>
        /// <param name="startDateTimeReference"> The start date time reference. </param>
        /// <param name="endDateTimeReference">   The end date time reference. </param>
        /// <param name="comment">                The comment. </param>
        /// <param name="project">                The project. </param>
        /// <param name="task">                   The task. </param>
        /// <param name="messageInteraction">     The message interaction. </param>
        public void AddPassedTimePastAndFuture(DateTime startDateTimeReference, DateTime endDateTimeReference, string comment, ProjectDto project, TaskDto task, string messageInteraction)
        {
            var passedTimes = new List<PassedTimeDto>();
            var result = EntityContext<Cricri371TimeManagerEntities>.GetContext.PassedTime.BetweenDates(p => p.StartDateTime, p => p.EndDateTime, startDateTimeReference, endDateTimeReference);

            var treat = false;
            if (result.Any())
            {
                Messenger.Default.Send(
                    new DialogMessage(
                        string.Empty,
                        res =>
                        {
                            if (res == System.Windows.MessageBoxResult.Yes)
                            {
                                treat = true;
                            }
                        }),
                    messageInteraction);
            }
            else
            {
                treat = true;
            }

            if (treat)
            {
                if (!AppSettingsSingleton.Instance.GetBooleanValue("MultiTask"))
                {
                    var tempList = new List<PassedTimes>();
                    result.ToList().ForEach(p => tempList.Add(p));

                    foreach (var passedTime in tempList)
                    {
                        if (passedTime.StartDateTime >= startDateTimeReference && passedTime.EndDateTime <= endDateTimeReference)
                        {
                            DeletePassedTime(passedTime.ID_PassedTime);
                        }
                        else
                        {
                            if (passedTime.StartDateTime < startDateTimeReference && passedTime.EndDateTime > endDateTimeReference)
                            {
                                AddPassedTime(endDateTimeReference, passedTime.EndDateTime, passedTime.Comment, passedTime.TaskLinkedToProject.ID_Project, passedTime.TaskLinkedToProject.ID_Task);
                                passedTime.EndDateTime = startDateTimeReference.AddSeconds(-1);
                            }
                            else
                            {
                                if (passedTime.StartDateTime >= startDateTimeReference && passedTime.StartDateTime <= endDateTimeReference)
                                {
                                    passedTime.StartDateTime = endDateTimeReference;
                                }
                                else
                                {
                                    if (passedTime.EndDateTime >= startDateTimeReference && passedTime.EndDateTime <= endDateTimeReference)
                                    {
                                        passedTime.EndDateTime = startDateTimeReference.AddSeconds(-1);
                                    }
                                }
                            }
                        }
                    }
                }

                AddPassedTime(startDateTimeReference, endDateTimeReference, comment, project, task);
            }
        }

        #endregion AddPassedTimePastAndFuture
    }
}