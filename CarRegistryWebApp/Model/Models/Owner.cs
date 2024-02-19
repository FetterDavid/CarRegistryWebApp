using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public partial class Owner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
