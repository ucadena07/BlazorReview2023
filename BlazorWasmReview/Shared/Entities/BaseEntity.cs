using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.Shared.Entities;

public class BaseEntity : NotifyObject
{
    public int Id 
    { 
        get {  return _id; }    
        set
        {
            if(_id != value )
            {
                return;
            }
            _id = value;
            NotifyPropertyChanged();
        }
    }
    private int _id;    
}
