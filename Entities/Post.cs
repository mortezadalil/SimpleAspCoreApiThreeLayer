using System;

namespace Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; }
        public int LikesCount { get; set; }
    }

}
