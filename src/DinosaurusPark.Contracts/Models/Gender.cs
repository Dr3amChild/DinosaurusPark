using System.ComponentModel;

namespace DinosaurusPark.Contracts.Models
{
    public enum Gender
    {
        /// <summary>
        /// Самец
        /// </summary>
        [Description("Самец")]
        Male = 0,

        /// <summary>
        /// Самка
        /// </summary>
        [Description("Самка")]
        Female = 1,
    }
}
