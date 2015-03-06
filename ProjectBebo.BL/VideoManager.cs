using System;
using System.Collections.Concurrent;

namespace ProjectBebo.BL
{
    public class VideoManager:IVideoManager
    {
        private ConcurrentDictionary<string, IVideo> safeVideoDict;
        private const string ThreadsafeVideoDict = "ThreadsafeVideoDict";
        private IVideo video;


        public ConcurrentDictionary<string, IVideo> GetAllVideos()
        {
            try
            {                
                safeVideoDict = GetCachedDictionary(true);
            }
            catch
            {
                safeVideoDict = null;
                throw;
            }

            return safeVideoDict;
        }

        private ConcurrentDictionary<string, IVideo> GetCachedDictionary(bool createNewIfEmpty)
        {
            ConcurrentDictionary<string, IVideo> cachedDictionary = null;

            try
            {

                var cachedObjectList = MemCacheUtil.GetCachedObject(ThreadsafeVideoDict);

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

                        MemCacheUtil.Add(ThreadsafeVideoDict, cachedDictionary, DateTimeOffset.UtcNow.AddHours(24));
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
                        safeVideoDict = GetCachedDictionary(true);

                        safeVideoDict.TryAdd(video.Title, video);

                        status = true;
                    }
                    else
                    {

                        throw new ArgumentException("Video title and/or description is invalid or missing.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("IVideo cannot be null.");
                }
            }
            //catch (ArgumentNullException ex)
            //{
            //    throw ex;
            //}
            //catch (ArgumentException e)
            //{
            //    throw e;
            //}
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
                else
                {
                    throw new ArgumentNullException("IVideo cannot be null.");
                }
            }
            catch
            {                
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
                    safeVideoDict = GetCachedDictionary(false);

                    if (safeVideoDict != null)
                    {
                        status = safeVideoDict.TryRemove(title, out video);
                        
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
