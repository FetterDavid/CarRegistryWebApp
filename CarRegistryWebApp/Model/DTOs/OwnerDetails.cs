using Model.Models;

namespace Model.DTOs
{
    public class OwnerDetails
    {
        public Owner Owner { get; set; }
        public List<Car> Cars { get; set; }
    }
}
