using System.Collections.Concurrent;

namespace ProjectBebo.BL
{
    public interface IVideoManager
    {
        ConcurrentDictionary<string, IVideo> GetAllVideos();
        bool AddVideo(IVideo video);
        bool DeleteVideoBy(IVideo video);
        bool DeleteVideoBy(string titleToDelete);        
    }
}
