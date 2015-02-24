using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectVEVO.BL;
using NUnit.Framework;
using ProjectVEVO.API.Controllers;
using ProjectVEVO.API.Models;
using System.Web.Http.Results;

namespace ProjectVEVO.Test
{
    [TestFixture]
    public class VideoControllerTest
    {
        [Test]
        public void GetShouldReturnVideos()
        {
            var controller = new VideoController(new VideoManager());

            var videos = controller.Get();
            Assert.IsAssignableFrom<OkNegotiatedContentResult<List<VideosDictViewModel>>>(videos);
        }

        [Test]
        public void GetShouldNotReturnNotFound()
        {
            var controller = new VideoController(new VideoManager());

            var videos = controller.Get();
            Assert.IsNotAssignableFrom<NotFoundResult>(videos);
        }
    }
}
