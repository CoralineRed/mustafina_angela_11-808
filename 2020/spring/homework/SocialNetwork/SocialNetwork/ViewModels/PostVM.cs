using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class PostVM
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public IFormFile Photo { get; set; }
    }
}
