using System;
using NUnit.Framework;
using ProjectBebo.BL;

namespace ProjectBebo.Test
{
    [TestFixture]
    public class VideoManagerTest
    {
        #region "Unit Tests for getting videos"
        #endregion

        #region "Unit Tests for adding a video"

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddVideoForNull()
        {            
            IVideoManager vidMgr = new VideoManager();
            IVideo video = null;

            var result = vidMgr.AddVideo(video: video);            

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { throw new ArgumentNullException(); });

            Assert.That(ex.Message,Is.EqualTo("IVideo cannot be null"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddVideoForMissingTitle()
        {            

            IVideoManager vidMgr = new VideoManager();
            IVideo video = new Video();
            
            video.Title = string.Empty;
            video.Description = "Test Description";


            var result = vidMgr.AddVideo(video);            

            ArgumentException ex = Assert.Throws<ArgumentException>(() => { throw new ArgumentException(); });

            Assert.That(ex.Message, Is.EqualTo("Video title and/or description is invalid or missing"));

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddVideoForMissingDescription()
        {            
            IVideoManager vidMgr = new VideoManager();

            IVideo video = new Video();
            
            video.Title = "Test Title";
            video.Description = string.Empty;


            var result = vidMgr.AddVideo(video);
            
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => { throw new ArgumentException(); });

            Assert.That(ex.Message, Is.EqualTo("Video title and/or description is invalid or missing"));

        }

        [Test]
        public void TestAddVideoAsExpected()
        {
            bool expected = true;

            IVideoManager vidMgr = new VideoManager();

            IVideo video = new Video();
            
            video.Title = "Bebo Video";
            video.Description = "Bebo video Description";


            var result = vidMgr.AddVideo(video);

            Assert.AreEqual(expected, result, "TestAddVideoAsExpected failed");

        }

        #endregion

        #region "Unit Tests for deleting a video"
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDeleteVideoForNull()
        {
           
            IVideoManager vidMgr = new VideoManager();

            IVideo video = null;            

            var result = vidMgr.AddVideo(video);            

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { throw new ArgumentNullException(); });

            Assert.That(ex.Message, Is.EqualTo("IVideo cannot be null"));
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
