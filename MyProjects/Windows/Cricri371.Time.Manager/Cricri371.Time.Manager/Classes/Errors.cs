namespace Cricri371.Time.Manager.Classes
{
    public enum ApplicationErrors
    {
        ApplicationAlreadyExists,
        ApplicationNameNull,
        CompanyNotSelected,
        ApplicationUsed
    }

    public enum ProjectErrors
    {
        ProjectAlreadyExists,
        ProjectNameNull,
        ApplicationNotSelected,
        ProjectUsed,
        TaskIsUsedInProject,
        TaskAlreadyLinkedToProject
    }

    public enum TaskErrors
    {
        TaskAlreadyExists,
        TaskNameNull,
        TaskUsed
    }

    public enum CompanyErrors
    {
        CompanyAlreadyExists,
        CompanyNameNull,
        CompanyUsed
    }

    public enum MainViewErrors
    {
        StartMustBeSmallerThanEnd,
        NoMultiTask
    }

    public enum UpdateViewErrors
    {
        StartMustBeSmallerThanEnd
    }

    public enum SplitLineViewErrors
    {
        StartMustBeSmallerThanEnd
    }

    /// <summary>
    /// Class ErrorMessages.
    /// </summary>
    public class ErrorMessages
    {
        public const string ApplicationNameNull = "You must fill the name of the application";
        public const string ProjectNameNull = "You must fill the name and the short name of the project";
        public const string CompanyNameNull = "You must fill the name of the company";
        public const string TaskNameNull = "You must fill the name of the task";
        public const string ApplicationAlreadyExists = "The application already exists";
        public const string TaskAlreadyExists = "The task already exists";
        public const string ProjectAlreadyExists = "The project already exists";
        public const string CompanyAlreadyExists = "The company already exists";
        public const string CompanyNotSelected = "You must select a company";
        public const string ApplicationNotSelected = "You must select an application";
        public const string StartMustBeSmallerThanEnd = "The start date time must be smaller than the end date time";
        public const string NoMultiTask = "You haven't configured the multi tasks. Change the option of close the open task";
        public const string ApplicationUsed = "You can't delete an application which is used";
        public const string TaskUsed = "You can't delete a task which is used";
        public const string CompanyUsed = "You can't delete a company which is used";
        public const string ProjectUsed = "You can't delete a project which is used";
        public const string TaskIsUsedInProject = "You can't delete a task which is linked to a project and which is used";
        public const string TaskAlreadyLinkedToProject = "The task is already linked to the project";
    }
}