namespace ProjectManagementApi.Helper
{
    public enum UserType
    {
        ADMIN,
        PROJECT_MANAGER,
        EMPLOYEE
    }

    public enum Status
    {
        TO_DO,
        IN_PROGRESS,
        TESTING,
        DONE,
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
