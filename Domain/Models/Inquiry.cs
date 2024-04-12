namespace Domain.Models
{
    public class Inquiry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Cover> Covers { get; set; }
        public decimal Capital { get; set; }
    }
}