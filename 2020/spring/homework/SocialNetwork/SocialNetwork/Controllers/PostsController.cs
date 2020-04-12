using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationContext db;

        public PostsController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult MyPosts()
        {           
            return View(db.GetPosts(User.Identity.Name));
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(PostVM model)
        {
            if (ModelState.IsValid)
            {
                await db.AddPost(new Post
                {
                    UserId = db.GetUserByLogin(User.Identity.Name).Id,
                    CreationTime = DateTime.Now,
                    Name = model.Name,
                    Text = model.Text,
                    Photo = Helper.ConvertFileToBytes(model.Photo)
                });
                return RedirectToAction("MyPosts", "Posts");
            }
            return View(model);
        }

        public IActionResult Post(int postId)
        {
            return View(new PostWithComments
            {
                Post = db.Posts.FirstOrDefault(p => p.Id == postId),
                Comments = db.Comments.Where(c => c.PostId == postId)
                    .OrderByDescending(c => c.CreationTime)
                    .ToList()
            });
        }
    }
}