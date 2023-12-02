using BlazorWasmReview.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Shared.Entities;

public class User : BaseEntity
{
    [Required]
    public string UserName { get; set; }
    [Required(ErrorMessage ="The password is required!!!")]
    public string Password { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [Phone]
    public string Phone { get; set; }
    [Required]

    public GenderTypeEnum Gender { get; set; }
    public ObservableCollection<BaseItem> UserItems { get; set; }

    
}
