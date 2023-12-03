using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using BlazorWasmReview.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Business;

public class UserItemManager : IUserItemManager
{
    public async Task<ChildItem> CreateNewChildItemAndAddItToParentItemAsync(ParentItem parent)
    {
        var childItem = new ChildItem();
        childItem.ParentId = parent.Id;
        childItem.ItemTypeEnum = ItemTypeEnum.Child;

        //await _itemDataAccess.InsertItemAsync(childItem);

        parent.ChildItems.Add(childItem);
        return await Task.FromResult(childItem);
    }
}
