﻿using BlazorWasmReview.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Shared.Contracts;

public interface IItemDataAccess
{
    Task<IEnumerable<TItem>> GetItemsOfUserAsync<TItem>(int parentId) where TItem : BaseItem;
    Task InsertItemAsync<TItem>(TItem item) where TItem : BaseItem;
    Task UpdateItemAsync<TItem>(TItem item) where TItem : BaseItem;
    Task DeleteItemsAsync<TItem>(IEnumerable<TItem> items) where TItem : BaseItem;
}
