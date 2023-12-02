using BlazorWasmReview.GeneralUI.DropdownControl;
using BlazorWasmReview.Shared.Entities;
using BlazorWasmReview.Shared.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;
using System.Linq.Expressions;

namespace BlazorWasmReview.Client.Pages;

public partial class SignUp
{
    [Inject]
    private NavigationManager _navManager { get; set; }
    protected User User { get; set; } = new();
    protected EditContext EditContext { get; set; }
    public IList<DropdownItem<GenderTypeEnum>> GenderTypesDropdownItems { get; set; }
    public DropdownItem<GenderTypeEnum> SelectedGenderType { get; set; }
    protected override void OnInitialized()
    {
        GenderTypesDropdownItems = new List<DropdownItem<GenderTypeEnum>>();
        base.OnInitialized();
        EditContext = new EditContext(User);
        var male = new DropdownItem<GenderTypeEnum>()
        {
            ItemObject = GenderTypeEnum.Male,
            DisplayText = "Male"
        };
        var female = new DropdownItem<GenderTypeEnum>()
        {
            ItemObject = GenderTypeEnum.Female,
            DisplayText = "Female"
        };
        var neutral = new DropdownItem<GenderTypeEnum>()
        {
            ItemObject = GenderTypeEnum.Neutral,
            DisplayText = "Neutral"
        };
        GenderTypesDropdownItems.Add(male);
        GenderTypesDropdownItems.Add(female);
        GenderTypesDropdownItems.Add(neutral);

        SelectedGenderType = female;
        TryGetUsernameFromUrl();

    }
    public string GetError(Expression<Func<object>> fu)
    {
        if (EditContext == null)
        {
            return null;
        }
        return EditContext.GetValidationMessages(fu).FirstOrDefault();
    }

    protected void OnValidSubmit()
    {
        User.Gender = (GenderTypeEnum)Enum.Parse(typeof(GenderTypeEnum), SelectedGenderType.DisplayText);
        if(EditContext.Validate())
            _navManager.NavigateTo("signin");
    }

    void TryGetUsernameFromUrl()
    {
        var uri = _navManager.ToAbsoluteUri(_navManager.Uri);
        StringValues sv;
        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("username", out sv))
        {
            User.UserName = sv; 
        }
    }
}