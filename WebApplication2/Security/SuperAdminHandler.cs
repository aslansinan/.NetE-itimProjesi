﻿using EmployeeManangement.Security;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

public class SuperAdminHandler :
    AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ManageAdminRolesAndClaimsRequirement requirement)
    {
        if (context.User.IsInRole("Super Admin"))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}