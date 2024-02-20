using Model.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    /// <summary>
    /// Represents a car entity.
    /// </summary>
    public partial class Car
    {
        /// <summary>
        /// Gets or sets the unique identifier of the car.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the brand of the car.
        /// </summary>
        [Required, MaxLength(50)]
        public string Brand { get; set; } = null!;
        /// <summary>
        /// Gets or sets the type of the car.
        /// </summary>
        [Required, MaxLength(50)]
        public string Type { get; set; } = null!;
        /// <summary>
        /// Gets or sets the registration number of the car.
        /// </summary>
        [Required, ValidRegistrationNumber]
        public string RegistrationNumber { get; set; } = null!;
        /// <summary>
        /// Gets or sets the production date of the car.
        /// </summary>
        [Required, LaterThan("1886-01-29")]
        public DateTime ProductionDate { get; set; }
    }
}
