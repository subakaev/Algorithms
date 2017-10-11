using System;
using System.ComponentModel;
using System.Globalization;

namespace Wpf.Utils
{
    /// <summary>
    /// TypeConverter для Enum, преобразовывающий Enum к строке с
    /// учетом атрибута Description
    /// </summary>
    public class EnumTypeConverter : EnumConverter
    {
        private readonly Type enumType;

        public EnumTypeConverter(Type type) : base(type)
        {
            enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            var fi = enumType.GetField(Enum.GetName(enumType, value));
            var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute), false);

            return dna != null ? dna.Description : value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            foreach (var fi in enumType.GetFields())
            {
                var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute), false);

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(enumType, fi.Name);
            }

            return Enum.Parse(enumType, (string)value);
        }

    }
}
