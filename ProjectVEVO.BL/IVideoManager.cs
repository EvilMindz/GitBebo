using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Concurrent;

namespace ProjectVEVO.BL
{
    public interface IVideoManager
    {
        ConcurrentDictionary<string, IVideo> GetAllVideos();
        bool AddVideo(IVideo video);
        bool DeleteVideoBy(IVideo video);
        bool DeleteVideoBy(string titleToDelete);        
    }
}
