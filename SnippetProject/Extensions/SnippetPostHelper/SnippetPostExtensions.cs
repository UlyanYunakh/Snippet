using System;
using System.Collections.Generic;
using Snippet.Services.Models;

namespace SnippetProject.Extensions.SnippetPostHelper
{
    public static class SnippetPostExtensions
    {
        public static SnippetPost ConfigureDefault(this SnippetPost post, ulong id = default)
        {
            post.Id = id;
            post.Title = "default title";
            post.Description = "default description";
            post.Snippet = "default snippet";
            post.Date = DateTime.Now;
            post.Language = new Language() { Id = 1, Name = "Haskell" };
            post.Tags = new List<Tag>(){
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" }
            };
            post.User = new User() { Id = 3, Username = "Ulyan" };
            return post;
        }

        public static ShortSnippetPost ConfigureDefault(this ShortSnippetPost post, ulong id = default)
        {
            post.Id = id;
            post.Title = "default title";
            post.Description = "default description";
            post.Date = DateTime.Now;
            post.Language = new Language() { Id = 1, Name = "Haskell" };
            post.User = new User() { Id = 3, Username = "Ulyan" };
            post.Tags = new List<Tag>(){
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" },
                new Tag() { Id = 2, Name="#tag" }
            };
            return post;
        }
    }
}