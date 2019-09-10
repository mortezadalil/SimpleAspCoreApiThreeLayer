using Application.Dto;
using Entities;
using System;
using System.Collections.Generic;

namespace Application
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetPosts();
        PostDto GetPostById(string id);
        bool AddPost(AddPostDto model);
    }
}
