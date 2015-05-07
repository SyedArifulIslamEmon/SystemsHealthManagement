using System;

namespace Integra.Dominio.Base
{
    public static class StringValueAttributeExtention
    {

        public static string GetStringValue(this Enum value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            var attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs != null && attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}