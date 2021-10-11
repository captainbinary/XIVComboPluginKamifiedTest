using System;

namespace XIVComboKamifiedTestPlugin
{
    /// <summary>
    /// Attribute designating secret combos.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal class SecretCustomComboAttribute : Attribute
    {
    }
}
