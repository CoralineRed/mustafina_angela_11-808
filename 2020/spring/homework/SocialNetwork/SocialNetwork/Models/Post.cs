using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public byte[] Photo { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EditTime { get; set; }
    }
}
