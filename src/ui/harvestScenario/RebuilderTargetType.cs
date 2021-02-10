 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmfs.Agepro.Gui
{
    /// <summary>
    /// A BindingList object to populate the "Rebulider Target Type" Combo Box. 
    /// </summary>
    class RebuilderTargetType : AgeproPropertyChanged
    {

        public int index { get; set; }
        private string _rebuilderTargetTypename;
        public string rebuilderTargetTypeName 
        {
            get { return _rebuilderTargetTypename; }
            set { SetProperty(ref _rebuilderTargetTypename, value); } 
        }
        
    }
}
