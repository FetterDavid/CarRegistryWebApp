namespace Model.Models
{
    public partial class CarOwnership
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int CarId { get; set; }
    }
}
