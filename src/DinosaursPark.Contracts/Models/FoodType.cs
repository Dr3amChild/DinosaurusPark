using System.ComponentModel;

namespace DinosaursPark.Contracts.Models
{
    public enum FoodType
    {
        /// <summary>
        /// Травоядный
        /// </summary>
        [Description("Травоядный")]
        Herbivorous,

        /// <summary>
        /// Хищник
        /// </summary>
        [Description("Хищник")]
        Predator,

        /// <summary>
        /// Всеядный
        /// </summary>
        [Description("Всеядный")]
        Omnivore,
    }
}
