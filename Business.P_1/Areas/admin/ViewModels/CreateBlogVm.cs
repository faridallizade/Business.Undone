using Microsoft.AspNetCore.Http.Metadata;

namespace Business.P_1.ViewModels
{
    public class CreateBlogVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
