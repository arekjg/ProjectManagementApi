﻿namespace ProjectManagementApi.Dtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SupervisorId { get; set; }
    }
}
