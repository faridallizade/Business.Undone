namespace Business.P_1.ViewModels
{
    public class UpdateBlogVm
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
