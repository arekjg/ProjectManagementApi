namespace ProjectManagementApi.Helper
{
    public enum UserType
    {
        ADMIN,
        PROJECT_MANAGER,
        EMPLOYEE
    }

    public enum JobStatus
    {
        TO_DO,
        IN_PROGRESS,
        TESTING,
        DONE,
        CLOSED
    }

    public enum ProjectStatus
    {
        PREPARED,
        OPEN,
        CLOSED
    }

    public enum Priority
    {
        LOWEST,
        LOW,
        MODERATE,
        HIGH,
        HIGHEST
    }
}
