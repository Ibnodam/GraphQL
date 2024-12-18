using GraphQL.Models;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GraphQL.Data
{
    public class Mutation
    {
        [Serial]
        public async Task<Post?> UpdatePost([Service]
        BlogDbContext context, Post model)
        { 

            var post = await context.Posts.Where(post => post.Id ==
            model.Id).FirstOrDefaultAsync();
            if (post != null)
            {
                if (!string.IsNullOrEmpty(model.Title)) post.Title = model.Title;
                if (!string.IsNullOrEmpty(model.Content)) post.Content = model.Content;
                if (!string.IsNullOrEmpty(model.Author)) post.Author = model.Author;

                post.CreateAt = DateTime.Now;
                context.Posts.Update(post);
                await context.SaveChangesAsync();
            }
            return post;
        }
        [Serial]
        public async Task DeletePost(
            [Service]
        BlogDbContext context, Post model)
        { 
            var post = await context.Posts.Where(p=>p.Id
            ==model.Id).FirstOrDefaultAsync();
            if (post != null)
            { 
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
            
        }
        [Serial]
        public async Task InsertPost(
            [Service]
            BlogDbContext context, Post model)
        {
            context.Posts.Add(model);
            await context.SaveChangesAsync();
        }
    }
}
