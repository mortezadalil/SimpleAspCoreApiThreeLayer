using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var methodResult= _postService.GetPosts();
            var result = methodResult.Select(PostVm.WrapToPostVm);
            return Ok(new 
            {
                Status = 1,
                Result = result,
                Error=""
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var methodResult = _postService.GetPostById(id);
            var result = PostVm.WrapToPostVm(methodResult);
            return Ok(new
            {
                Status = 1,
                Result = result,
                Error = ""
            });
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] AddPostDto model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    status = 0,
                    Result = "",
                    Error = "Validation Problem"
                });
            }
            var methodResult = _postService.AddPost(model);
            return Ok(new
            {
                Status = 1,
                Result = methodResult,
                Error = ""
            });
        }

    }
}
