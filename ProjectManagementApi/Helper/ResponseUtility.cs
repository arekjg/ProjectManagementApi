﻿using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementApi.Helper
{
    public class ResponseUtility
    {
        public static IActionResult InternalServerError(Exception e)
        {
            return new ObjectResult($"An error occurred: {e.Message}")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        public static IActionResult OkOrNotFound(object? obj)
        {
            if (obj != null)
            {
                return new OkObjectResult(obj);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
