using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Collections.Concurrent;
using System.Web.Http.Cors;

using ProjectVEVO.BL;
using ProjectVEVO.API.Models;

namespace ProjectVEVO.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideoController : ApiController
    {
        private IVideoManager vidMgr;
        private ConcurrentDictionary<string, IVideo> videosList;

        public VideoController(IVideoManager videoMgr)
        {
            //Inserted via Ninject
            this.vidMgr = videoMgr;
        }

        
 
        // GET api/video
        [HttpGet]
        public IHttpActionResult Get()
        {
            videosList = vidMgr.GetAllVideos();

            return Ok(videosList.Select(src => new VideosListViewModel() { Key = src.Key.ToString(), VevoVideo = src.Value }).ToList());
        }

        //// GET api/video/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/video
        [HttpPost()]
        //public bool Post([FromBody] VideosListViewModel videoVM)
        public bool Post(string title, string description)
        {
            //if (videoVM != null)
            //{
            //    IVideo video = (IVideo)videoVM.VevoVideo;

            //    if (video != null)
            //    {
            //        return vidMgr.AddVideo(video);
            //    }
            //}

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                IVideo video = new Video() { Title = title, Description = description };

                return vidMgr.AddVideo(video);
            }

            return false;
        }

        // PUT api/video/
        [HttpPut]
        public void Put([FromBody] VideosListViewModel videoVM)
        {
            
        }

        // DELETE api/video/5
        [HttpDelete]
        //public IHttpActionResult Delete([FromBody] VideosListViewModel videoToDelete)
        public IHttpActionResult Delete(string title)
        {
            //if (!string.IsNullOrEmpty(videoToDelete.Key))
            //{
            //    return Ok(vidMgr.DeleteVideoBy(videoToDelete.Key));
            //}

            if (!string.IsNullOrEmpty(title))
            {
                return Ok(vidMgr.DeleteVideoBy(title));
            }

            return NotFound();
        }
    }
}
