using BlazorWasmReview.Business;
using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BlazorWasmReview.Client.Pages
{
    public partial class SignIn
    {
        [Inject]
        private NavigationManager _navManager { get; set; }
        [Inject]
        public IUserManager _userManager { get; set; }
        protected User User { get; set; } = new();
        private string Day { get; } = DateTime.Now.DayOfWeek.ToString();
        string UserName;
        protected EditContext EditContext { get; set; }

        private void HandleUserNameChanged(ChangeEventArgs e)
        {
            UserName = e.Value.ToString();
        }

        void HandleUserNameChanged(string value)
        {
            UserName = value;
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            EditContext = new EditContext(User);
        }

        public string GetError(Expression<Func<object>> fu)
        {
            if(EditContext == null)
            {
                return null;
            }
            return EditContext.GetValidationMessages(fu).FirstOrDefault();
        }
        protected async Task OnSubmit()
        {
            //if(!EditContext.Validate())
            //{
            //    return;
            //}

            var foundUser = await _userManager.TrySignInAndGetUserAsync(User);
            if(foundUser != null)
            {
                _navManager.NavigateTo("");
            }
        }
    }
}