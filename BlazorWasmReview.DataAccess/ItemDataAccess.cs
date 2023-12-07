using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.DataAccess;

public class ItemDataAccess : IItemDataAccess
{
    private readonly IPersistenceService _persistenceService;
    public ItemDataAccess(IPersistenceService persistenceService)
    {
        _persistenceService = persistenceService;
    }
    public async Task DeleteItemsAsync<TItem>(IEnumerable<TItem> items) where TItem : BaseItem
    {
        foreach (var item in items)
        {
            await _persistenceService.DeleteAsync(item);  
        }
    }

    public async Task<IEnumerable<TItem>> GetItemsOfUserAsync<TItem>(int parentId) where TItem : BaseItem
    {
        return await _persistenceService.GetAsync<TItem>(i => i.ParentId == parentId);
    }

    public async Task InsertItemAsync<TItem>(TItem item) where TItem : BaseItem
    {
        var id = await _persistenceService.InsertAsync(item);
        item.Id = id;   
    }

    public async Task UpdateItemAsync<TItem>(TItem item) where TItem : BaseItem
    {
         await _persistenceService.UpdateAsync(item);
    }
}
