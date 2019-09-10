using Application;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class PostVm
    {
        public string Name { get; set; }
        public bool HasLike { get; set; }
        public static PostVm WrapToPostVm(PostDto model)
        {
            return new PostVm
            {
                Name = model.Title,
                HasLike = model.HasLike
            };
        }
    }
}
