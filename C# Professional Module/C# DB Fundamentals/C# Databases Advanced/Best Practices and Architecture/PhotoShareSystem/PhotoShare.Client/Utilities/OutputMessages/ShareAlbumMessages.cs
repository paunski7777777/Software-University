namespace PhotoShare.Client.Utilities.OutputMessages
{
    public class ShareAlbumMessages
    {
        public const string SuccessMessage = "Username [{0}] added to album [{1}] ([{2}])";
        public const string AlbumNotFoundMessage = "Album [{0}] not found!";
        public const string UserNotFoundMessage = "User [{0}] not found!";
        public const string InvalidPermissionMessage = "Permission must be either \"Owner\" or \"Viewer\"!";
    }
}