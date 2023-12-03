using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;

namespace BlazorWasmReview.TestFake;

public class UserManagerFake : IUserManager
{
    public Task<User> InsertUserAsync(User user)
    {
        return Task.FromResult(user);
    }

    public Task<User> TrySignInAndGetUserAsync(User user)
    {
        return Task.FromResult(user);
    }
}
