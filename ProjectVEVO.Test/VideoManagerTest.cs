using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectVEVO.BL;
using NUnit.Framework;

namespace ProjectVEVO.Test
{
    [TestFixture]
    public class VideoManagerTest
    {
        #region "Unit Tests for getting videos"
        #endregion

        #region "Unit Tests for adding a video"

        [Test]
        public void TestAddVideoForNull()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();
            IVideo video = null;

            var result = vidMgr.AddVideo(video);

            Assert.AreEqual(expected, result, "TestAddVideoForNull failed");            
        }

        [Test]
        public void TestAddVideoForMissingTitle()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();
            IVideo video = new Video();
            
            video.Title = string.Empty;
            video.Description = "Test Description";


            var result = vidMgr.AddVideo(video);

            Assert.AreEqual(expected, result, "TestAddVideoForMissingTitle failed");    

        }

        [Test]
        public void TestAddVideoForMissingDescription()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();

            IVideo video = new Video();
            
            video.Title = "Test Title";
            video.Description = string.Empty;


            var result = vidMgr.AddVideo(video);

            Assert.AreEqual(expected, result, "TestAddVideoForMissingDescription failed");

        }

        [Test]
        public void TestAddVideoAsExpected()
        {
            bool expected = true;

            IVideoManager vidMgr = new VideoManager();

            IVideo video = new Video();
            
            video.Title = "Vevo Video";
            video.Description = "Vevo video Description";


            var result = vidMgr.AddVideo(video);

            Assert.AreEqual(expected, result, "TestAddVideoAsExpected failed");

        }

        #endregion

        #region "Unit Tests for deleting a video"
        [Test]
        public void TestDeleteVideoForNull()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();

            IVideo video = new Video();
            
            video.Title = "Test Title";
            video.Description = string.Empty;


            var result = vidMgr.AddVideo(video);

            Assert.AreEqual(expected, result, "TestAddVideoForMissingDescription failed");
        }

        [Test]
        public void TestDeleteVideoByIdForEmptyTitleFilter()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();
            string titleToDelete = string.Empty;

            var result = vidMgr.DeleteVideoBy(titleToDelete);

            Assert.AreEqual(expected, result, "TestDeleteVideoByIdForEmptyTitleFilter failed");
        }

        [Test]
        public void TestDeleteVideoByIdForEmptyCache()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();
            string titleToDelete = "Empty Cache";

            var result = vidMgr.DeleteVideoBy(titleToDelete);

            Assert.AreEqual(expected, result, "TestDeleteVideoByIdForEmptyCache failed");
        }

        [Test]
        public void TestDeleteVideoByIdForTitleNotFound()
        {
            bool expected = false;

            IVideoManager vidMgr = new VideoManager();
            string titleToDelete = "Some random Title not found in the Cache";

            var result = vidMgr.DeleteVideoBy(titleToDelete);

            Assert.AreEqual(expected, result, "TestDeleteVideoByIdForTitleNotFound failed");
        }

        [Test]
        public void TestDeleteVideoByVideoAsExpected()
        {
            bool expected = true;

            IVideoManager vidMgr = new VideoManager();
            //IVideo video = new Video();

            for (int i = 0; i < 10; i++)
            {
                IVideo video = new Video();
                
                video.Title = "Test Title " + i.ToString();
                video.Description = "Test Description " + i.ToString();

                vidMgr.AddVideo(video);
            }


            IVideo videoToDelete = new Video();
            
            videoToDelete.Title = "Test Title 4";
            videoToDelete.Description = "Test Description 4";

            var result = vidMgr.DeleteVideoBy(videoToDelete);

            Assert.AreEqual(expected, result, "TestDeleteVideoByVideo failed");
        }

        [Test]
        public void TestDeleteVideoByTitleAsExpected()
        {
            bool expected = true;

            IVideoManager vidMgr = new VideoManager();
            //IVideo video = new Video();

            for (int i = 0; i < 10; i++)
            {
                IVideo video = new Video();
                
                video.Title = "Test Title " + i.ToString();
                video.Description = "Test Description " + i.ToString();

                vidMgr.AddVideo(video);
            }

            string titleToDelete = "Test Title 4";

            var result = vidMgr.DeleteVideoBy(titleToDelete);

            Assert.AreEqual(expected, result, "TestDeleteVideoByTitleAsExpected failed");
        }

        #endregion
    }
}
