using ProjectBebo.BL;

namespace ProjectBebo.API.Models
{
    public class VideosDictViewModel
    {
        public string Key { get; set; }
        public IVideo BeboVideo { get; set; }
    }
}