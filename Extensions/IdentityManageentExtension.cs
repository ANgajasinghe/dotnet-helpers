using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Vertex.RMS.Application.Common.Models;

namespace Vertex.RMS.Application.Common.Extensions;

public static class IdentityManageentExtension
{
    public static IResult ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Results.Ok()
            : Results.BadRequest(Result.Failure(result.Errors.Select(e => e.Description)));
    }

    public static IResult ToApplicationResult(this SignInResult result)
    {
        return result.Succeeded
            ? Results.Ok()
            : Results.BadRequest(Result.Failure(new[]
            {
                "Invalid email or password",
                $"{nameof(result.IsLockedOut)}:{result.IsLockedOut}",
                $"{nameof(result.IsNotAllowed)}:{result.IsNotAllowed}",
                $"{nameof(result.RequiresTwoFactor)}:{result.RequiresTwoFactor}"
            }));
    }

    //public static IResult ToApplicationResponse<T>(this SignInResult result, T data)
    //{
    //    return result.Succeeded
    //        ? Results.Ok(data)
    //        : Results.BadRequest(Result.Failure(new[]
    //        {
    //            "Invalid email or password",
    //            $"{nameof(result.IsLockedOut)}:{result.IsLockedOut}",
    //            $"{nameof(result.IsNotAllowed)}:{result.IsNotAllowed}",
    //            $"{nameof(result.RequiresTwoFactor)}:{result.RequiresTwoFactor}"
    //        }));
    //}
}