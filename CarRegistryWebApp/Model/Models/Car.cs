namespace Model.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public DateTime ProductionDate { get; set; }
    }
}
