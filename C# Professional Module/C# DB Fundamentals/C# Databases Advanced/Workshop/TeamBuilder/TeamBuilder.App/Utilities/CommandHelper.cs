namespace TeamBuilder.App.Utilities
{
    using System.Linq;

    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }
        public static bool IsUserxisting(string userName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.Any(u => u.Username == userName && !u.IsDeleted);
            }
        }
        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }
        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Single(t => t.Name == teamName).Members.Any(u => u.User.Username == username);
            }
        }
        public static bool IsEvenetExisting(string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.Name == eventName);
            }
        }
        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            return user.CreatedEvents.SingleOrDefault(e => e.Name == eventName) == null ? false : true;
        }
        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            return user.CreatedUserTeams.SingleOrDefault(t => t.Team.Name == teamName) == null ? false : true;
        }
    }
}