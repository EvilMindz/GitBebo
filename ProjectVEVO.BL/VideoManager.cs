using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace ProjectVEVO.BL
{
    public class VideoManager:IVideoManager
    {
        private ConcurrentDictionary<string, IVideo> safeVideoList;
        private const string ThreadSafeVideoList = "ThreadSafeVideoList";
        private IVideo video;


        public ConcurrentDictionary<string, IVideo> GetAllVideos()
        {
            try
            {                
                safeVideoList = GetCachedDictionary(true);
            }
            catch
            {
                safeVideoList = null;
                throw;
            }

            return safeVideoList;
        }

        private ConcurrentDictionary<string, IVideo> GetCachedDictionary(bool createNewIfEmpty)
        {
            ConcurrentDictionary<string, IVideo> cachedDictionary = null;

            try
            {

                var cachedObjectList = MemCacheUtil.GetCachedObject(ThreadSafeVideoList);

                if (cachedObjectList != null)
                {
                    cachedDictionary = cachedObjectList as ConcurrentDictionary<string, IVideo>;
                }
                else
                {
                    if (createNewIfEmpty)
                    {
                        cachedDictionary = new ConcurrentDictionary<string, IVideo>();


                        //TODO: Remove once code is complete - BEGIN
                        for (int i = 1; i <= 10; i++)
                        {
                            IVideo vid = new Video();

                            vid.Title = "Dummy Title " + i.ToString();
                            vid.Description = "Dummy Description " + i.ToString();

                            cachedDictionary.TryAdd(vid.Title, vid);
                        }

                        MemCacheUtil.Add(ThreadSafeVideoList, cachedDictionary, DateTimeOffset.UtcNow.AddHours(24));
                        //TODO: Remove once code is complete - END
                    }
                }
            }
            catch
            {
                cachedDictionary = null;
                throw;
            }

            return cachedDictionary;
        }

        public bool AddVideo(IVideo video)
        {
            bool status = false;            

            try
            {
                if (video != null)
                {
                    if (!string.IsNullOrEmpty(video.Title) && !string.IsNullOrEmpty(video.Description))
                    {             
                        safeVideoList = GetCachedDictionary(true);

                        safeVideoList.TryAdd(video.Title, video);

                        status = true;

                        //status = MemCacheUtil.Add(ThreadSafeVideoList, safeVideoList, DateTimeOffset.UtcNow.AddHours(24));
                    }
                }
            }
            catch
            {
                throw;
            }

            return status;
        }

        public bool DeleteVideoBy(IVideo video)
        {
            bool status = false;

            try
            {
                if (video != null)
                {
                    status = DeleteVideoBy(video.Title);
                }
            }
            catch
            {
                status = false;
                throw;
            }

            return status;
        }

        public bool DeleteVideoBy(string title)
        {
            bool status = false;

            try
            {                
                if (!string.IsNullOrWhiteSpace(title))
                {
                    //TODO: What if cachedObjectList is not yet available? Will this condition ever arise? - 
                    //DONE: handled in test
                    safeVideoList = GetCachedDictionary(false);

                    if (safeVideoList != null)
                    {
                        status = safeVideoList.TryRemove(title, out video);

                        //TODO: What if title is not found in the list because somebody already deleted it? - 
                        //DONE: handled in test
                        if (video != null)
                        {
                            status = true;
                        }
                    }
                }
            }
            catch
            {
                status = false;
                throw;
            }

            return status;
        }
    }
}
