using Business.P_1.Models.Base;

namespace Business.P_1.Models
{
    public class Blog:BaseEntity
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
