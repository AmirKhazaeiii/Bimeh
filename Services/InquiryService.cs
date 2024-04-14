using Domain.Context;
using Domain.Models;
using Services.Interface;

namespace Services
{
    public class InquiryService : IInquiryService, IDisposable
    {
        private readonly DataContext _context;
        public InquiryService(DataContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Inquiry> GetAllRequests()
        {
            return _context.Requests.ToList();
        }

        public bool Submit(InqueryRequest request)
        {
            try
            {
                if (!ValidateCovers(request.Covers))
                {
                    return false;
                }
                var newInquiry = new Inquiry(request.Title, request.Covers, request.Capital);
                var validation = new InquiryValidator();
                //var validRes = validation.Validate(newInquiry);
                //if (!validRes.IsValid)
                //{
                //    Console.WriteLine(validRes.Errors.FirstOrDefault());
                //}
                _context.Requests.Add(newInquiry);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateCovers(List<Cover> covers)
        {
            if (covers.Count == 0)
            {
                return false;
            }
            return true;
        }

        //private bool ValidateCovers(List<Cover> covers)
        //{
        //if (covers.Count == 0)
        //{
        //    return false;
        //}
        //return true;
        //}
    }
}
