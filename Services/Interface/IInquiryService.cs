using Domain.Models;

namespace Services.Interface
{
    public interface IInquiryService
    {
        bool Submit(InqueryRequest request);
        List<Inquiry> GetAllRequests();
        bool ValidateCovers(List<Cover> covers);
    }
}
