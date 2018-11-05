namespace MishMash.Controllers
{
    using MishMash.ViewModels.Channels;
    using MishMash.ViewModels.Home;

    using SIS.HTTP.Responses;

    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user != null)
            {

                var yourChannels = this.db.Channels.Where(ch => ch.Followers
                                                                  .Any(u => u.User.Username == this.User.Username))
                                                   .Select(vm => new FollowedChannelViewModel
                                                   {
                                                       Id = vm.Id,
                                                       Name = vm.Name,
                                                       Type = vm.Type,
                                                       Followers = vm.Followers.Count
                                                   })
                                                   .ToList();

                var followedChannelsTags = this.db.Channels.Where(ch => ch.Followers
                                                                   .Any(u => u.User.Username == this.User.Username))
                                                           .SelectMany(ch => ch.Tags
                                                                                .Select(t => t.Tag.Id))
                                                           .ToList();

                var suggestedChannels = this.db.Channels.Where(ch => !ch.Followers
                                                                         .Any(u => u.User.Username == this.User.Username)
                                                                                && ch.Tags.Any(t => followedChannelsTags
                                                                                                   .Contains(t.TagId)))
                                                         .Select(vm => new FollowedChannelViewModel
                                                         {
                                                             Id = vm.Id,
                                                             Name = vm.Name,
                                                             Type = vm.Type,
                                                             Followers = vm.Followers.Count
                                                         })
                                                         .ToList();

                var ids = yourChannels.Select(x => x.Id).ToList();
                ids = ids.Concat(suggestedChannels.Select(x => x.Id)).ToList();
                ids = ids.Distinct().ToList();

                var seeOthers = this.db.Channels.Where(ch => !ids.Contains(ch.Id))
                                                .Select(vm => new FollowedChannelViewModel
                                                {
                                                    Id = vm.Id,
                                                    Name = vm.Name,
                                                    Type = vm.Type,
                                                    Followers = vm.Followers.Count
                                                })
                                                .ToList();

                var loggedInViewModel = new IndexLoggedInViewModel
                {
                    YourChannels = yourChannels,
                    Suggested = suggestedChannels,
                    SeeOther = seeOthers
                };

                return this.View("Home/IndexLoggedIn", loggedInViewModel);
            }

            return this.View();
        }
    }
}