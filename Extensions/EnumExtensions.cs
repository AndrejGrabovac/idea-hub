using System;
using System.ComponentModel;
using System.Reflection;

namespace IdeaHub.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Vraća Description atribut enum vrijednosti ili naziv enum-a ako nema Description
        /// </summary>
        /// <param name="value">Enum vrijednost</param>
        /// <returns>Description string ili naziv enum-a</returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return string.Empty;

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                return value.ToString();

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Provjerava da li enum vrijednost ima definiran Description atribut
        /// </summary>
        /// <param name="value">Enum vrijednost</param>
        /// <returns>True ako ima Description, inače False</returns>
        public static bool HasDescription(this Enum value)
        {
            if (value == null)
                return false;

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                return false;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0;
        }
    }
}