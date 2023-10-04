﻿using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Dtos
{
    public class AddProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
    }
}
