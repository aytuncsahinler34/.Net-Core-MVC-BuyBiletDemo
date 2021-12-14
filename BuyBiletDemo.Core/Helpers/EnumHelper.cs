using BuyBiletDemo.Core.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BuyBiletDemo.Core.Helpers
{
    public static class EnumHelper
    {
        public static List<CommonOptionDto<object>> GetEnumDescriptionOptions(Type type) {
            if (!type.IsEnum)
                throw new InvalidOperationException();
            List<CommonOptionDto<object>> list = new List<CommonOptionDto<object>>();
            var fields = type.GetFields();
            foreach (var field in fields) {
                var descriptionAttributes = (field.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[]);

                if (descriptionAttributes != null && descriptionAttributes.Any()) {
                    string description = descriptionAttributes.First().Description;
                    list.Add(new CommonOptionDto<object>(field.GetRawConstantValue(), description));
                }
            }

            return list;

        }
        public static T GetAttributeOfType<T>(this System.Enum enumVal) where T : System.Attribute {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
