using Model.Models;

namespace Model.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a new car.
    /// </summary>
    public class NewCar
    {
        /// <summary>
        /// Gets or sets the details of the new car to be created.
        /// </summary>
        public Car? Car { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the owner for the new car (0 if there is no owner).
        /// </summary>
        public int OwnerId { get; set; }
    }
}
