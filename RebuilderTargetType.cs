 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGEPRO.GUI
{
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
