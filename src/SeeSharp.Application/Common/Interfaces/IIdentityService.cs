﻿using System;
using SeeSharp.Application.Common.Models;

namespace SeeSharp.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<(string UserId,string FullName, string UserName, string Email, IList<string> Roles)> GetUserDetailsByUserNameAsync(string userName);

    Task<(string UserId, string FullName, string UserName, string Email, IList<string> Roles)> GetUserDetailsByEmailAsync(string userName);

    Task<Result> AddToRolesAsync(string userId, List<string> roles);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthenticateAsync(string username, string password);

    Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string email, string password);

    Task<Result> DeleteUserAsync(string userId);
}

