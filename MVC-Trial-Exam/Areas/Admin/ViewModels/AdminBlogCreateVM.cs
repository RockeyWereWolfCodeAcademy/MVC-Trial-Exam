using System.ComponentModel.DataAnnotations;

namespace MVC_Trial_Exam.Areas.Admin.ViewModels
{
    public class AdminBlogCreateVM
    {
        public string Author { get; set; }
        [MaxLength(16)]
        public string Title { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
