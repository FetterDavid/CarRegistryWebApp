using Model.Models;

namespace Model.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) containing details about a car and its owner.
    /// </summary>
    public class CarDetails
    {
        /// <summary>
        /// Gets or sets the car itself.
        /// </summary>
        public Car? Car { get; set; }
        /// <summary>
        /// Gets or sets the owner of the car.
        /// </summary>
        public Owner? Owner { get; set; }
    }
}
