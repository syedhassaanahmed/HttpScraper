using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace HttpScraper.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public static SynchronizationContext Context { private get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if ((currentValue != null) && currentValue.Equals(newValue))
                return false;

            currentValue = newValue;
            Notify(propertyName);

            return true;
        }

        void Notify(string propertyName)
        {
            if(PropertyChanged != null)
                InvokeOnSynchronizationContext(() => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
        }

        static void InvokeOnSynchronizationContext(Action action)
        {
            if (Context == SynchronizationContext.Current)
                action();
            else
                Context.Post(a => action(), null);
        }
    }
}
