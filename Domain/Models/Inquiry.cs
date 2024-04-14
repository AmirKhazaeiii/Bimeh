using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Inquiry
    {
        protected Inquiry()
        {

        }

        public Inquiry(string title, List<Cover> covers, decimal captal)
        {
            Title = title;
            Covers = string.Join(",", covers.Select(p => (int)p).ToList());
            Capital = captal;
        }
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Covers { get; private set; }
        public decimal Capital { get; private set; }

        [NotMapped]
        public List<Cover> CoversList =>
            (!string.IsNullOrEmpty(Covers) ?
            Covers.Split(",").Select(p => (Cover)int.Parse(p)).ToList() :
            new List<Cover>());
    }

    public class InqueryRequest
    {
        public string Title { get; set; }
        public List<Cover> Covers { get; set; }
        public decimal Capital { get; set; }
    }
}