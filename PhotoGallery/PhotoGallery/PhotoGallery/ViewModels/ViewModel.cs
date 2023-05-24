using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PhotoGallery.ViewModels
{
    public class ViewModel : INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;

        protected void Set<T>(
            ref T field, 
            T newValue,
            [CallerMemberName] string propertyName = null
        )
        {
            if( !EqualityComparer<T>.Default.Equals(field, newValue) )
            {
                field = newValue;
                RaisePropertyChanged(propertyName);
            }
        }

        protected void RaisePropertyChanged(
            [CallerMemberName] string propertyName = null
        )
        {
            PropertyChanging?.Invoke(
                this, 
                new PropertyChangingEventArgs(propertyName)
            );
        }

        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                Set(ref isBusy, value);
                RaisePropertyChanged(nameof(isNotBusy));
            }

        }
        public bool isNotBusy;
    }
}
