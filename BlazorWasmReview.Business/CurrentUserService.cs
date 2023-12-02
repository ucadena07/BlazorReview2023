using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Business;

public class CurrentUserService : ICurrentUserService
{
    public User CurrentUser { get; set; }
}
