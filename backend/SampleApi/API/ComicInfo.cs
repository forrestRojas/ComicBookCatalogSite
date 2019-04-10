using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.API
{

    /// <summary>
    /// Get comic information from ComicVine
    /// </summary>
    public class ComicInfo
    {
        ComicApiInfo comicApiInfo = new API.ComicApiInfo();
        int volumeId = 0;
        int issueNumber = 0;
        string seriesTitle = "";
        string publisherName = "";

        /// <summary>
        /// Basic constructor, takes two input parameters
        /// </summary>
        /// <param name="seriesTitle">Title of the comic</param>
        /// <param name="issueNumber">Issue we're looking for</param>
        public ComicInfo(string seriesTitle, int issueNumber)
        {
            this.seriesTitle = seriesTitle;
            this.issueNumber = issueNumber;
            this.volumeId = comicApiInfo.GetVolumeInfo(seriesTitle);
            this.comic = comicApiInfo.GetIssueInfo(volumeId, issueNumber);
        }


    }

    public class ComicApiInfo
    {
        int volumeId = 0;
        string publisherName = "";

        /// <summary>
        /// Map of the JSON ComicVine sends back for volume queries.
        /// Items without a description are unused.
        /// </summary>
        public class ComicVineVolumeResponse
        {
            public string error { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int number_of_page_results { get; set; }
            public int number_of_total_results { get; set; }
            public int status_code { get; set; }

            /// <summary>
            /// array of results from request
            /// </summary>
            public VolumeResult[] results { get; set; }
            public string version { get; set; }
        }

        /// <summary>
        /// array of volumes matching the seriesTitle
        /// </summary>
        public class VolumeResult
        {
            public string aliases { get; set; }
            public string api_detail_url { get; set; }
            public int count_of_issues { get; set; }
            public string date_added { get; set; }
            public string date_last_updated { get; set; }
            public string deck { get; set; }
            public string description { get; set; }
            public string first_issue { get; set; }

            /// <summary>
            /// Volume ID, used to retrieve issue record
            /// </summary>
            public int id { get; set; }

            public string image { get; set; }
            public string last_issue { get; set; }

            /// <summary>
            /// Series title
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// object for publisher info
            /// </summary>
            public Publisher publisher { get; set; }

            public string site_detail_url { get; set; }
            public string start_year { get; set; }
        }

        /// <summary>
        /// Used to get the publisher name
        /// </summary>
        public class Publisher
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }

            /// <summary>
            /// The publisher name, stored in comic detail database
            /// </summary>
            public string name { get; set; }
        }

        /// <summary>
        /// Map of the JSON ComicVine sends back for issue queries.
        /// Items without a description are unused.
        /// </summary>
        public class ComicVineIssueResponse
        {
            public string error { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int number_of_page_results { get; set; }
            public int number_of_total_results { get; set; }
            public int status_code { get; set; }

            /// <summary>
            /// array of results from request
            /// </summary>
            public IssueResult[] results { get; set; }
            public string version { get; set; }
        }

        /// <summary>
        /// Array of issues matching the issue number for this volume 
        /// (We hope there will be only one)
        /// </summary>
        public class IssueResult
        {
            public object aliases { get; set; }
            public string api_detail_url { get; set; }

            /// <summary>
            /// The issue date of the comic
            /// </summary>
            public string cover_date { get; set; }

            public string date_added { get; set; }
            public string date_last_updated { get; set; }

            /// <summary>
            /// Short summary of the issue
            /// </summary>
            public object deck { get; set; }

            /// <summary>
            /// Long description of the issue
            /// </summary>
            public object description { get; set; }

            public bool has_staff_review { get; set; }

            /// <summary>
            /// ComicVine ID of the issue - saved in case we need to re-reference
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// Array of images related to the issue
            /// We will use the thumbnail image
            /// </summary>
            public Image image { get; set; }

            /// <summary>
            /// The issue number
            /// </summary>
            public string issue_number { get; set; }

            /// <summary>
            /// The issue title
            /// </summary>
            public object name { get; set; }

            public string site_detail_url { get; set; }
            public object store_date { get; set; }
            public string volume { get; set; }
        }

        public class Image
        {
            public string icon_url { get; set; }
            public string medium_url { get; set; }
            public string screen_url { get; set; }
            public string screen_large_url { get; set; }
            public string small_url { get; set; }
            public string super_url { get; set; }

            /// <summary>
            /// This is the image the website will use
            /// </summary>
            public string thumb_url { get; set; }

            public string tiny_url { get; set; }
            public string original_url { get; set; }
            public string image_tags { get; set; }
        }

        /// <summary>
        /// Stripped object for insertion in comic database
        /// </summary>
        public class Issue
        {
            /// <summary>
            /// The issue date of the comic
            /// </summary>
            public string cover_date { get; set; }

            /// <summary>
            /// Short summary of the issue
            /// </summary>
            public object deck { get; set; }

            /// <summary>
            /// Long description of the issue
            /// </summary>
            public object description { get; set; }

            /// <summary>
            /// ComicVine ID of the issue - saved in case we need to re-reference
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// The cover image - thumbnail
            /// </summary>
            public string image { get; set; }

            /// <summary>
            /// The issue number
            /// </summary>
            public string issue_number { get; set; }

            /// <summary>
            /// The issue title
            /// </summary>
            public object name { get; set; }

            /// <summary>
            /// The publisher of the comic
            /// </summary>
            public string publisher { get; set; }
        }

        /// <summary>
        /// Get volume information to retrieve publisher
        /// </summary>
        /// <param name="seriesTitle"></param>
        /// <returns></returns>
        public int GetVolumeInfo(string seriesTitle)
        {
            var client = new RestClient("http://www.comicvine.com/api/volumes/?api_key=c4bfb45f7bcb288c0dba5973d0888b3dd4f4b05f&format=json&filter=name:" + seriesTitle);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            ComicVineVolumeResponse volumeResponse = (ComicVineVolumeResponse)response;
            foreach (VolumeResult volume in volumeResponse.results)
            {
                if (volume.name == seriesTitle)
                {
                    volumeId = volume.id;
                    publisherName = volume.publisher.name;
                    break; // Found the volume we need
                }
            }
            return volumeId;
        }

        /// <summary>
        /// Build record to populate comic DB
        /// </summary>
        /// <param name="volumeId">Volume for this title</param>
        /// <param name="issueNumber">Issue number we're building a record for</param>
        /// <returns></returns>
        public Issue GetIssueInfo(int volumeId, int issueNumber)
        {
            var client = new RestClient("http://www.comicvine.com/api/issues/?api_key=c4bfb45f7bcb288c0dba5973d0888b3dd4f4b05f&format=json&filter=volume:filter=volume:" + volumeId + ",issue_number:" + issueNumber);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            ComicVineIssueResponse issueResponse = (ComicVineIssueResponse)response;
            Issue issue = new Issue();
            issue.cover_date = issueResponse.results[0].cover_date;
            issue.deck = issueResponse.results[0].deck;
            issue.description = issueResponse.results[0].description;
            issue.id = issueResponse.results[0].id;
            issue.image = issueResponse.results[0].image.thumb_url;
            issue.issue_number = issueResponse.results[0].issue_number;
            issue.name = issueResponse.results[0].name;
            issue.publisher = publisherName;

            return issue;
        }
    }
}
