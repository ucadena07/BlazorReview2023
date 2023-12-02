using BlazorWasmReview.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Shared.Contracts;

public interface IUserManager
{
    Task<User> InsertUserAsync(User user);
    Task<User> TrySignInAndGetUserAsync(User user);
}
