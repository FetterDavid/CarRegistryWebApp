using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public partial class CarOwnership
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int CarId { get; set; }
    }
}
