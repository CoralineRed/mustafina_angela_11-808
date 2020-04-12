using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class PostWithComments
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
