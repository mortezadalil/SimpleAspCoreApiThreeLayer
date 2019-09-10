using System;

namespace Application.Dto
{
    public class PostDto
    {
        public string Title { get; set; }
        public bool HasLike
        {
            get
            {
                return LikesCount > 0 ? true : false;
            }
        }

        public int LikesCount { get; set; }
    }
}