using System;

namespace AutoClicker.Utils.IniParser
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IniIgnorePropertyAttribute : Attribute {}
}
