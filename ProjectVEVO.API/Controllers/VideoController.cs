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

        //// POST api/video
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/video/
        [HttpPut]
        public bool Put([FromBody] VideosListViewModel videoVM)
        {
            if (videoVM != null)
            {
                IVideo video = (IVideo)videoVM.VevoVideo;

                if (video != null)
                {
                    return vidMgr.AddVideo(video);
                }                
            }

            return false;
        }

        // DELETE api/video/5
        [HttpDelete]
        public IHttpActionResult Delete([FromBody]string titleToDelete)
        {
            return Ok(vidMgr.DeleteVideoBy(titleToDelete));
        }

        //// DELETE api/video/5         
        //public IHttpActionResult Delete([FromUri] string title)
        //{
        //    return Ok(vidMgr.DeleteVideoBy(title));
        //}

        //// DELETE api/video/5
        //public IHttpActionResult Delete([FromBody] VideosListViewModel videoVM)
        //{
        //    return Ok(vidMgr.DeleteVideoBy(videoVM.VevoVideo as IVideo));
        //}
    }
}
