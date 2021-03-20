using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nmfs.Agepro.Gui
{
    class AgeproPropertyChanged : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        //DanRigby
        /// <summary>
        /// Sets PropertyChanged 
        /// </summary>
        /// <typeparam name="T">The Parameter's datatype</typeparam>
        /// <param name="field">The Parameter</param>
        /// <param name="value">New value of the parameter</param>
        /// <param name="name">Parameter's name (automatically by CallerMemberName)</param>
        /// <returns> True if value was changed, false if it was the same</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(name);
            return true;
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
