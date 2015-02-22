using ProjectVEVO.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectVEVO.API.Models
{
    public class VideosListViewModel
    {
        public string Key { get; set; }
        public IVideo VevoVideo { get; set; }
    }
}