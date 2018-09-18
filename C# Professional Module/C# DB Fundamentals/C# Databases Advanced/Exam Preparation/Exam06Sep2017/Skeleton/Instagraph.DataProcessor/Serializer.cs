namespace Instagraph.DataProcessor
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;

    using Instagraph.Data;
    using Instagraph.DataProcessor.Dtos.Export;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                               .Where(p => p.Comments.Count < 1)
                               .OrderBy(i => i.Id)
                               .Select(c => new
                               {
                                   Id = c.Id,
                                   Picture = c.Picture.Path,
                                   User = c.User.Username
                               })
                               .ToList();

            var jsonString = JsonConvert.SerializeObject(posts, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                               .Where(p => p.Posts
                                            .Any(c => c.Comments
                                                       .Any(f => p.Followers
                                                                  .Any(fi => fi.FollowerId == f.UserId))))
                               .Select(u => new
                               {
                                   Username = u.Username,
                                   Followers = u.Followers.Count
                               })
                               .ToList();

            var jsonString = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var sb = new StringBuilder();

            var users = context.Users
                               .ProjectTo<UserCommentsDto>()
                               .OrderByDescending(mc => mc.MostComments)
                               .ThenBy(u => u.Username)
                               .ToList();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(List<UserCommentsDto>), new XmlRootAttribute("users"));

            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}