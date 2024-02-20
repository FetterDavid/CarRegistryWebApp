using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    /// <summary>
    /// Represents a relationship between a car and its owner.
    /// </summary>
    public partial class CarOwnership
    {
        /// <summary>
        /// Gets or sets the unique identifier of the car ownership.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the owner associated with this car ownership.
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the car associated with this car ownership.
        /// </summary>
        public int CarId { get; set; }
    }
}
