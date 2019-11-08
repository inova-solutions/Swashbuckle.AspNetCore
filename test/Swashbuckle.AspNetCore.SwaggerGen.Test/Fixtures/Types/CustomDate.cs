using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test.Fixtures.Types
{
    [Serializable]
    [TypeConverter(typeof(CustomDateTypeConverter))]
    public struct CustomDate
    {
        private DateTime _date;

        public CustomDate(DateTime value)
        {
            _date = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, DateTimeKind.Local);
        }

        public override string ToString()
        {
            return _date.ToString("d");
        }

        public string ToString(string format)
        {
            return _date.ToString(format);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return _date.ToString(format, provider);
        }

        public static implicit operator CustomDate(DateTime d)
        {
            return new CustomDate(d);
        }
        public static explicit operator DateTime(CustomDate d)
        {
            return d._date;
        }
    }
    public class CustomDateTypeConverter : DateTimeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var dateTime = (DateTime)base.ConvertFrom(context, culture, value);
            return new CustomDate(dateTime);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is CustomDate date)
                value = (DateTime)date;

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}