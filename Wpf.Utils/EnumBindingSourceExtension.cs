using System;
using System.Linq;
using System.Windows.Markup;

namespace Wpf.Utils
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private readonly Enum[] except;
        private Type enumType;

        public Type EnumType {
            get { return enumType; }
            set {
                if (value != enumType) {
                    if (null != value) {
                        var type = Nullable.GetUnderlyingType(value) ?? value;
                        if (!type.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType) {
            EnumType = enumType;
        }

        public EnumBindingSourceExtension(Type enumType, params Enum[] except) {
            this.except = except;
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            if (null == enumType)
                throw new InvalidOperationException("The EnumType must be specified.");

            var actualEnumType = Nullable.GetUnderlyingType(enumType) ?? enumType;
            var enumValues = except == null ? Enum.GetValues(actualEnumType) : Enum.GetValues(actualEnumType).Cast<Enum>().Except(except).ToArray();

            if (actualEnumType == enumType)
                return enumValues;

            var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}