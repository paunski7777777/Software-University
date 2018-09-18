namespace Instagraph.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Instagraph.Data;
    using Instagraph.Models;
    using Instagraph.DataProcessor.Dtos.Import;
    using System.Xml.Serialization;
    using System.IO;

    public class Deserializer
    {
        private const string ERROR_MESSAGE = "Error: Invalid data.";
        private const string SUCCESS_MESSAGE = "Successfully imported {0}.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedPictures = JsonConvert.DeserializeObject<List<PictureDto>>(jsonString);

            var pictures = new List<Picture>();

            foreach (var pictureDto in deserializedPictures)
            {
                bool pictureExists = context.Pictures.Any(p => p.Path == pictureDto.Path)
                    || pictures.Any(p => p.Path == pictureDto.Path);

                if (!IsValid(pictureDto) || pictureExists)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var picture = Mapper.Map<Picture>(pictureDto);

                pictures.Add(picture);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE, $"Picture {picture.Path}"));
            }

            context.Pictures.AddRange(pictures);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedUsers = JsonConvert.DeserializeObject<List<UserDto>>(jsonString);

            var users = new List<User>();

            foreach (var userDto in deserializedUsers)
            {
                var picture = context.Pictures.FirstOrDefault(p => p.Path == userDto.ProfilePicture);

                if (!IsValid(userDto) || picture == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var user = Mapper.Map<User>(userDto);
                user.ProfilePicture = picture;

                users.Add(user);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE, $"User {user.Username}"));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedFollowers = JsonConvert.DeserializeObject<List<UserFollowerDto>>(jsonString);

            var userFollowers = new List<UserFollower>();

            foreach (var userFollowerDto in deserializedFollowers)
            {
                int? userId = context.Users.FirstOrDefault(u => u.Username == userFollowerDto.User)?.Id;
                int? followerId = context.Users.FirstOrDefault(u => u.Username == userFollowerDto.Follower)?.Id;

                if (userId == null || followerId == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                bool alreadyFollowed = userFollowers.Any(f => f.UserId == userId && f.FollowerId == followerId);

                if (alreadyFollowed)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var userFollower = new UserFollower
                {
                    UserId = userId.Value,
                    FollowerId = followerId.Value
                };

                userFollowers.Add(userFollower);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE, $"Follower {userFollowerDto.Follower} to User {userFollowerDto.User}"));
            }

            context.UsersFollowers.AddRange(userFollowers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<PostDto>), new XmlRootAttribute("posts"));

            var deserializedPosts = (List<PostDto>)serializer.Deserialize(new StringReader(xmlString));

            var posts = new List<Post>();

            foreach (var postDto in deserializedPosts)
            {
                int? userId = context.Users.FirstOrDefault(u => u.Username == postDto.User)?.Id;
                int? pictureId = context.Pictures.FirstOrDefault(p => p.Path == postDto.Picture)?.Id;

                if (userId == null || pictureId == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                if (!IsValid(postDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var post = new Post
                {
                    Caption = postDto.Caption,
                    UserId = userId.Value,
                    PictureId = pictureId.Value
                };

                posts.Add(post);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE, $"Post {post.Caption}"));
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<CommentDto>), new XmlRootAttribute("comments"));

            var deserializedComments = (List<CommentDto>)serializer.Deserialize(new StringReader(xmlString));

            var comments = new List<Comment>();

            foreach (var commentDto in deserializedComments)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == commentDto.User);

                if (!IsValid(commentDto) || user == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                bool isIdParsed = int.TryParse(commentDto.Post?.Id, out int parsedId);

                if (!isIdParsed)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var postId = context.Posts.FirstOrDefault(p => p.Id == parsedId)?.Id;

                if (postId == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var comment = new Comment
                {
                    Content = commentDto.Content,
                    User = user,
                    PostId = postId.Value
                };

                comments.Add(comment);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE, $"Comment {comment.Content}"));
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}