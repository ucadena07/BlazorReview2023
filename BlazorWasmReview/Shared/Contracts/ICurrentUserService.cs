using BlazorWasmReview.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Shared.Contracts;

public interface ICurrentUserService
{
    User CurrentUser { get; set; }
}
