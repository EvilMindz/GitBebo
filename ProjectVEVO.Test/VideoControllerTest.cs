using System.Collections.Generic;
using System.Web.Http.Results;
using NUnit.Framework;
using ProjectBebo.API.Controllers;
using ProjectBebo.API.Models;
using ProjectBebo.BL;

namespace ProjectBebo.Test
{
    [TestFixture]
    public class VideoControllerTest
    {
        [Test]
        public void GetShouldReturnVideos()
        {
            var controller = new VideoController(new VideoManager());

            var videos = controller.Get();
            if (videos != null)
            {
                Assert.IsAssignableFrom<OkNegotiatedContentResult<List<VideosDictViewModel>>>(videos);
            }
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
