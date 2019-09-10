using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class AddPostDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}