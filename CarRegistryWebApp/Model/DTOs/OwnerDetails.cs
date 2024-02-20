using Model.Models;

namespace Model.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) containing details about an owner and their cars.
    /// </summary>
    public class OwnerDetails
    {
        /// <summary>
        /// Gets or sets the owner itself.
        /// </summary>
        public Owner? Owner { get; set; }
        /// <summary>
        /// Gets or sets the list of cars owned by the owner.
        /// </summary>
        public List<Car>? Cars { get; set; }
    }
}
