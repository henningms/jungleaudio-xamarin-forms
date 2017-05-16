using HtmlAgilityPack;
using JungleAudio.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JungleAudio.Services
{
    public class AudiojungleWebService
    {
        public static async Task<IList<AudioItem>> GetFavoritesAsync(int page = 1)
        {
            var client = new HttpClient();

            // First page
            var favoritesHtml = await client.GetStringAsync(new Uri($"http://audiojungle.net/favorites?page={page}"));

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(favoritesHtml);

            var audioItems = new List<AudioItem>();

            foreach (HtmlNode link in htmlDoc.DocumentNode.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "js-google-analytics__list-event-container audio")))
            {
                var thumbnailUrl = GetThumbnailUrlFromItemNode(link);
                var previewUrl = GetPreviewUrlFromItemNode(link);
                var title = GetTitleFromItemNode(link);
                var detailUrl = GetDetailUrlFromItemNode(link);
                var author = GetAuthorFromItemNode(link);
                var authorUrl = GetAuthorUrlFromItemNode(link);

                audioItems.Add(new AudioItem
                {
                    ThumbnailUrl = thumbnailUrl,
                    PreviewUrl = previewUrl,
                    Title = title,
                    DetailUrl = detailUrl,
                    Author = author,
                    AuthorProfileUrl = authorUrl
                });
            }

            return audioItems;

        }

        private static String GetThumbnailUrlFromItemNode(HtmlNode node)
        {
            var thumbnailNode = node.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "tooltip-magnifier preload no_preview")).FirstOrDefault();

            if (thumbnailNode == null) return "";

            return thumbnailNode.Attributes.First(x => x.Name == "src").Value.ToString().Trim();
        }

        private static String GetPreviewUrlFromItemNode(HtmlNode node)
        {
            var previewNode = node.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "js-audio-player audio-player-mini--is-paused")).FirstOrDefault();

            if (previewNode == null) return "";

            return previewNode.Attributes.First(x => x.Name == "href").Value.ToString().Trim();
        }

        private static String GetTitleFromItemNode(HtmlNode node)
        {
            var itemInfoNode = node.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "item-info")).FirstOrDefault();

            if (itemInfoNode == null) return "";

            return itemInfoNode.Descendants().First(x => x.Name == "a").InnerText.Trim();
        }

        private static String GetDetailUrlFromItemNode(HtmlNode node)
        {
            var itemInfoNode = node.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "item-info")).FirstOrDefault();

            if (itemInfoNode == null) return "";

            return itemInfoNode.Descendants().First(x => x.Name == "a").Attributes.First(x => x.Name == "href").Value.ToString().Trim();
        }

        private static String GetAuthorFromItemNode(HtmlNode node)
        {
            var itemInfoNode = node.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "item-info")).FirstOrDefault();

            if (itemInfoNode == null) return "";

            return itemInfoNode.Descendants().First(x => x.Attributes.Any(y => y.Value == "author")).InnerText.Trim();
        }

        private static String GetAuthorUrlFromItemNode(HtmlNode node)
        {
            var itemInfoNode = node.Descendants().Where(x => x.Attributes.Any(y => y.Name == "class" && y.Value == "item-info")).FirstOrDefault();

            if (itemInfoNode == null) return "";

            return itemInfoNode.Descendants().First(x => x.Attributes.Any(y => y.Value == "author")).Attributes.First(x => x.Name == "href").Value.ToString().Trim();
        }
    }
}
