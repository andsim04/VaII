using System.ComponentModel;

namespace VaII
{
    public class FileViewModel
    {
        [DisplayName("Photo")]
        public IFormFile? FormFile { get; set; }
    }
}
