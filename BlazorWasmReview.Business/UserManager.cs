using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Business;

public class UserManager : IUserManager
{
    public async Task<User> TrySignInAndGetUserAsync(User user)
    {
        return await Task.FromResult(new User());
    }
    public async Task<User> InsertUserAsync(User user)
    {
        return await Task.FromResult(new User());
    }
}
