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
        public string Brand { get; set; } = null!;
        /// <summary>
        /// Gets or sets the type of the car.
        /// </summary>
        public string Type { get; set; } = null!;
        /// <summary>
        /// Gets or sets the registration number of the car.
        /// </summary>
        public string RegistrationNumber { get; set; } = null!;
        /// <summary>
        /// Gets or sets the production date of the car.
        /// </summary>
        public DateTime ProductionDate { get; set; }
    }
}
