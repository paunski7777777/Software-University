namespace MishMash.Controllers
{
    using MishMash.Models;
    using MishMash.Models.Enums;
    using MishMash.ViewModels.Channels;

    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System;
    using System.Linq;

    public class ChannelsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var channelViewModel = this.db.Channels.Where(ch => ch.Id == id)
                                                   .Select(vm => new ChannelDetailsViewModel
                                                   {
                                                       Name = vm.Name,
                                                       Type = vm.Type,
                                                       Description = vm.Description,
                                                       Tags = vm.Tags.Select(t => t.Tag.Name),
                                                       Followers = vm.Followers.Count
                                                   })
                                                   .FirstOrDefault();

            if (channelViewModel == null)
            {
                return this.BadRequestError("Invalid channel id!");
            }

            return this.View(channelViewModel);
        }

        [Authorize]
        public IHttpResponse Followed()
        {
            var followedChannels = this.db.Channels.Where(ch => ch.Followers
                                                                 .Any(u => u.User.Username == this.User.Username))
                                                    .Select(vm => new FollowedChannelViewModel
                                                    {
                                                        Id = vm.Id,
                                                        Name = vm.Name,
                                                        Type = vm.Type,
                                                        Followers = vm.Followers.Count
                                                    })
                                                    .ToList();

            var followedChannelsViewModel = new FollowedChannelsViewModel
            {
                FollowedChannelViewModels = followedChannels
            };

            return this.View(followedChannelsViewModel);
        }

        [Authorize]
        public IHttpResponse Follow(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (!this.db.UsersChannels.Any(u => u.UserId == user.Id && u.ChannelId == id))
            {
                this.db.UsersChannels.Add(new UserChannel
                {
                    UserId = user.Id,
                    ChannelId = id
                });

                this.db.SaveChanges();
            }

            return this.Redirect("/Channels/Followed");
        }

        [Authorize]
        public IHttpResponse Unfollow(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            var userChannel = this.db.UsersChannels.FirstOrDefault(u => u.UserId == user.Id && u.ChannelId == id);

            if (userChannel != null)
            {
                this.db.UsersChannels.Remove(userChannel);
                this.db.SaveChanges();
            }

            return this.Redirect("/Channels/Followed");
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Create() => this.View();

        [Authorize(nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(CreateChannelViewModel model)
        {
            if (!Enum.TryParse(model.Type, true, out ChannelType channelType))
            {
                return this.BadRequestErrorWithView("Invalid channel type!");
            }

            var channel = new Channel
            {
                Name = model.Name,
                Description = model.Description,
                Type = channelType

            };

            if (!string.IsNullOrWhiteSpace(model.Tags))
            {
                var tags = model.Tags.Split(',', ';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var tag in tags)
                {
                    var dbTag = this.db.Tags.FirstOrDefault(t => t.Name == tag.Trim());
                    if (dbTag == null)
                    {
                        dbTag = new Tag
                        {
                            Name = tag.Trim()
                        };

                        this.db.Tags.Add(dbTag);
                        this.db.SaveChanges();
                    }

                    channel.Tags.Add(new ChannelTag
                    {
                        TagId = dbTag.Id
                    });
                }
            }

            this.db.Channels.Add(channel);
            this.db.SaveChanges();

            return this.Redirect($"/Channels/Details?id={channel.Id}");
        }
    }
}