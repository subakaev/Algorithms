using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Wpf.Utils
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] properties) {
            if (PropertyChanged == null) return;

            foreach (var property in properties)
                OnPropertyChanged(property);
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> action) {
            OnPropertyChanged(GetPropertyName(action));
        }

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action) {
            var expression = (MemberExpression) action.Body;
            return expression.Member.Name;
        }
    }
}