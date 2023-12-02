using BlazorWasmReview.Shared.Entities;
using BlazorWasmReview.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Shared.Contracts
{
    public interface IUserItemManager
    {
        Task<TextItem> CreateNewUserItemAndAddItToUserAsync(User user, ItemTypeEnum text);
    }
}
