namespace IRunes.App.Controllers
{
    using IRunes.Models;

    using SIS.Http.Enums;
    using SIS.Http.Requests.Contracts;
    using SIS.Http.Responses.Contracts;
    using SIS.WebServer.Results;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    public class AlbumsController : BaseController
    {
        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            var albums = this.Context.Albums;

            if (albums.Any())
            {
                var listOfAlbums = string.Empty;

                foreach (var album in albums)
                {
                    var albumHtml = $@"<p><a href=""/albums/details/{album.Id}"">{album.Name}</a></p>";
                    listOfAlbums += albumHtml;
                }

                this.ViewBag["albumsList"] = listOfAlbums;
            }
            else
            {
                this.ViewBag["albumsList"] = "There are currently no albums.";
            }

            return this.ViewMethod();
        }

        //public IHttpResponse Create(IHttpRequest request)
        //{
        //    if (!this.IsAuthenticated(request))
        //    {
        //        return new RedirectResult("/users/login");
        //    }

        //    return this.View();
        //}

        //public IHttpResponse CreatePost(IHttpRequest request)
        //{
        //    if (!this.IsAuthenticated(request))
        //    {
        //        return new RedirectResult("/users/login");
        //    }

        //    var albumName = request.FormData["albumName"].ToString();
        //    var cover = request.FormData["cover"].ToString();

        //    if (this.Context.Albums.Any(a => a.Name == albumName))
        //    {
        //        return new BadRequestResult("Album already exists!", HttpResponseStatusCode.SeeOther);
        //    }

        //    var album = new Album()
        //    {
        //        Name = albumName,
        //        Cover = WebUtility.UrlDecode(cover)
        //    };

        //    this.Context.Albums.Add(album);

        //    try
        //    {
        //        this.Context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        return new BadRequestResult(e.Message, HttpResponseStatusCode.InternalServerError);
        //    }

        //    return new RedirectResult("/albums/all");
        //}

        //public IHttpResponse AlbumDetails(IHttpRequest request)
        //{
        //    if (!this.IsAuthenticated(request))
        //    {
        //        return new RedirectResult("/users/login");
        //    }

        //    var albumId = request.QueryData["id"].ToString();

        //    var album = this.Context.Albums.Find(albumId);

        //    if (album == null)
        //    {
        //        return new BadRequestResult("Album not found", HttpResponseStatusCode.NotFound);
        //    }

        //    var albumInfo = new StringBuilder();
        //    var albumPrice = album?.Price ?? 0.00m;

        //    var trackList = new StringBuilder();

        //    albumInfo.AppendLine($@"<img src=""{album.Cover}"" alt=""{album.Name}"">");
        //    albumInfo.AppendLine($"<h2><strong>Name: {album.Name}</strong></h2>");
        //    albumInfo.AppendLine($"<h2><strong>Price: ${albumPrice:f2}</strong</h2>");


        //    if (album.Tracks.ToList().Any())
        //    {
        //        trackList.AppendLine("<ul>");

        //        int count = 1;
        //        foreach (var track in album.Tracks.ToList())
        //        {
        //            trackList.AppendLine($"<li><strong>{count++}</strong>.<em>{track.Track.Name}</em></li>");
        //        }

        //        trackList.AppendLine("</ul>");

        //        this.ViewBag["albumDetails"] = albumInfo.ToString();
        //        this.ViewBag["albumTracks"] = trackList.ToString();
        //    }
        //    else
        //    {
        //        this.ViewBag["albumTracks"] = "There are currently no tracks in the album";
        //    }

        //    return this.View();
        //}
    }
}