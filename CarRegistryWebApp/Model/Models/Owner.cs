using Model.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    /// <summary>
    /// Represents an owner entity.
    /// </summary>
    public partial class Owner
    {
        /// <summary>
        /// Gets or sets the unique identifier of the owner.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the last name of the owner.
        /// </summary>
        [Required, MaxLength(50), NameValidation]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// Gets or sets the first name of the owner.
        /// </summary>
        [Required, MaxLength(50), NameValidation]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Gets or sets the birth date of the owner.
        /// </summary>
        [Required, LaterThan("1900-01-01")]
        public DateTime BirthDate { get; set; }
    }
}
