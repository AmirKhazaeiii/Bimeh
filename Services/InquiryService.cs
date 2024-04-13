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
            return _context.inquiries.ToList();
        }

        public bool Submit(Inquiry request)
        {
            try
            {
                if (ValidateCovers(request.Covers))
                {
                    var newInquiry = new Inquiry
                    {
                        Title = request.Title,
                        Covers = request.Covers,
                        Capital = request.Capital,
                    };
                    return true;
                }
                else
                {
                    return false;
                }
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
