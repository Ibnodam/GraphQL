﻿using GraphQL.Models;

namespace GraphQL.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts([Service] BlogDbContext
            context) => context.Posts;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetComments([Service]
        BlogDbContext context) => context.Comments;

    }
}
