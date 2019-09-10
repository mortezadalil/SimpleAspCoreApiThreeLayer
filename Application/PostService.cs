using Application.Dto;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class PostService : IPostService
    {
        private readonly Context _context;

        public PostService(Context context)
        {
            _context = context;
            //Use context without injectiona
            //var optionsBuilder = new DbContextOptionsBuilder<Context>();
            //optionsBuilder.UseSqlServer(Context.connectionString);
            //_context = new Context(optionsBuilder.Options);
        }

        public bool AddPost(AddPostDto model)
        {

            _context.Posts.Add(new Entities.Post
            {
                Title = model.Title,
                Body = model.Body,
                Created = DateTime.Now,
                LikesCount = 0,
                Id = Guid.NewGuid()
            });

            _context.SaveChanges();

            return true;
        }

        public PostDto GetPostById(string id)
        {
            var guid = new Guid(id);
            var result = _context.Posts.FirstOrDefault(x => x.Id == guid);
            return new PostDto
            {
                Title = result.Title,
                LikesCount = result.LikesCount
            };
        }

        public IEnumerable<PostDto> GetPosts()
        {
            return _context.Posts.Select(x => new PostDto
            {
                Title = x.Title,
                LikesCount = x.LikesCount
            }).ToList();
        }
    }
}
