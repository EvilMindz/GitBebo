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
        private ConcurrentDictionary<string, IVideo> videosDict;

        public VideoController(IVideoManager videoMgr)
        {
            //Inserted via Ninject
            this.vidMgr = videoMgr;
        }

        
 
        // GET api/video
        [HttpGet]
        public IHttpActionResult Get()
        {
            videosDict = vidMgr.GetAllVideos();

            if (videosDict != null)
            {

                return Ok(videosDict.Select(src => new VideosDictViewModel() { Key = src.Key.ToString(), VevoVideo = src.Value }).ToList());
            }

            return NotFound();
            
        }

        // GET api/video/5
        [NonAction()]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/video
        [HttpPost()]        
        public bool Post(string title, string description)
        {            
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                IVideo video = new Video() { Title = title, Description = description };

                return vidMgr.AddVideo(video);
            }

            return false;
        }
        
        // PUT api/video/
        [HttpPut]
        [NonAction()]
        public void Put([FromBody] VideosDictViewModel videoVM)
        {
            
        }

        // DELETE api/video/5
        [HttpDelete]
        //public IHttpActionResult Delete([FromBody] VideosDictViewModel videoToDelete)
        public IHttpActionResult Delete(string title)
        {            
            if (!string.IsNullOrEmpty(title))
            {
                return Ok(vidMgr.DeleteVideoBy(title));
            }

            return NotFound();
        }

        // DELETE api/video/5
        //[HttpDelete]
        //public IHttpActionResult Delete([FromBody] VideosDictViewModel videoToDelete)        
        //{
        //    if (videoToDelete != null && !string.IsNullOrEmpty(videoToDelete.Key))
        //    {
        //        return Ok(vidMgr.DeleteVideoBy(videoToDelete.Key));
        //    }

        //    return NotFound();
        //}

        // POST api/video
        //[HttpPost()]
        //public IHttpActionResult Post([FromBody] VideosDictViewModel videoVM)        
        //{
        //    if (videoVM != null)
        //    {
        //        IVideo video = (IVideo)videoVM.VevoVideo;

        //        if (video != null)
        //        {
        //            return Ok(vidMgr.AddVideo(video));
        //        }
        //    }

        //    return NotFound();
        //}
    }
}
