namespace Forum
{
    using Forum.Data;
    using Forum.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var db = new ForumDbContext();

            var tags = new[]
            {
                new Tag {Name = "C#"},
                new Tag {Name = "Programming"},
                new Tag {Name = "Praise"},
                new Tag {Name = "Microsoft"}
            };

            var postTags = new[]
            {
                new PostTag(){PostId = 1, Tag = tags[0]},
                new PostTag(){PostId = 1, Tag = tags[1]},
                new PostTag(){PostId = 1, Tag = tags[2]},
                new PostTag(){PostId = 1, Tag = tags[3]}
            };

            db.PostTags.AddRange(postTags);
            db.SaveChanges();

            //  ResetDatabase(db);

            //var categories = db.Categories 
            //    .Include(c => c.Posts)
            //      .ThenInclude(p => p.Author)
            //    .Include(c => c.Posts)
            //      .ThenInclude(p => p.Replies)
            //          .ThenInclude(r => r.Author)
            //    .ToList();

            var categories = db.Categories
                .Select(c => new
                {
                    c.Name,
                    Posts = c.Posts.Select(p => new
                    {
                        p.Title,
                        p.Content,
                        Author = p.Author.Username,
                        Replies = p.Replies.Select(r => new
                        {
                            r.Content,
                            Author = r.Author.Username
                        }),
                        Tags = p.PostTags.Select(t => t.Tag.Name)
                        .ToList(),
                    })
                    .ToList()
                })
                .ToList();

            foreach (var c in categories)
            {
                Console.WriteLine($"{c.Name} {c.Posts.Count()}");

                foreach (var p in c.Posts)
                {
                    Console.WriteLine($"--{p.Title} {p.Content}");
                    Console.WriteLine($"--by {p.Author}");

                    Console.WriteLine($"Tags: {string.Join(", ", p.Tags)}");

                    foreach (var r in p.Replies)
                    {
                        Console.WriteLine($"-----{r.Content} from {r.Author}");
                    }
                }
            }
        }

        private static void ResetDatabase(ForumDbContext db)
        {
            db.Database.EnsureDeleted();

            db.Database.Migrate();

            Seed(db);
        }

        private static void Seed(ForumDbContext db)
        {
            var users = new[]
           {
                new User("gosho", "123"),
                new User("pesho", "456"),
                new User("tosho", "789"),
                new User("ivan", "000")
            };

            db.Users.AddRange(users);

            var categories = new[]
            {
                new Category("C#"),
                new Category("Support"),
                new Category("Python"),
                new Category("EF KOR")
            };

            db.Categories.AddRange(categories);

            var posts = new[]
            {
                new Post("C# Rulz", "verno", users[0], categories[0]),
                new Post("Python Rulz", "pak verno", users[1], categories[2]),
                new Post("kompa ne ba4ka", "deiba", users[2], categories[1])
            };

            db.Posts.AddRange(posts);

            var replies = new[]
            {
                new Reply("turn it on", posts[2], users[0]),
                new Reply("dua", posts[0], users[3])
            };

            db.Replies.AddRange(replies);

            db.SaveChanges();
        }
    }
}
