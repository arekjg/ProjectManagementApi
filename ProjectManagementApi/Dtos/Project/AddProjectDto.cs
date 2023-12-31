﻿using ProjectManagementApi.Helper;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos
{
    public class AddProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int CreatedById { get; set; }
        public int CreatedAtDate { get; set; }
        public int DeadlineDate { get; set; }
        public Priority Priority { get; set; }
    }
}
