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
    public class GetComicInfo
    {
        int volumeId = 0;
        int issueNumber = 0;
        string seriesTitle = "";

        private GetComicInfo(string seriesTitle, int issueNumber)
        {
            this.seriesTitle = seriesTitle;
            this.issueNumber = issueNumber;
        }

        /// <summary>
        /// Map of the JSON ComicVine sends back.
        /// Items without a description are unused.
        /// </summary>
        public class ComicVineResult
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
            public Result[] results { get; set; }
            public string version { get; set; }
        }

        public class Result
        {
            public string aliases { get; set; }
            public string api_detail_url { get; set; }
            public int count_of_issues { get; set; }
            public string date_added { get; set; }
            public string date_last_updated { get; set; }
            public string deck { get; set; }
            public string description { get; set; }
            public First_Issue first_issue { get; set; }
            public int id { get; set; }
            public Image image { get; set; }
            public Last_Issue last_issue { get; set; }
            public string name { get; set; }
            public Publisher publisher { get; set; }
            public string site_detail_url { get; set; }
            public string start_year { get; set; }
        }

        public class First_Issue
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string issue_number { get; set; }
        }

        public class Image
        {
            public string icon_url { get; set; }
            public string medium_url { get; set; }
            public string screen_url { get; set; }
            public string screen_large_url { get; set; }
            public string small_url { get; set; }
            public string super_url { get; set; }
            public string thumb_url { get; set; }
            public string tiny_url { get; set; }
            public string original_url { get; set; }
            public string image_tags { get; set; }
        }

        public class Last_Issue
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string issue_number { get; set; }
        }

        public class Publisher
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }


        /// <summary>
        /// Get volume information to retrieve publisher
        /// </summary>
        /// <param name="seriesTitle"></param>
        /// <returns></returns>
        public int GetVolumeInfo(string seriesTitle)
        {
            var client = new RestClient("http://www.comicvine.com/api/volumes/?api_key=c4bfb45f7bcb288c0dba5973d0888b3dd4f4b05f&format=json&filter=name:Omaha");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            return volumeId;
        }

    }
}
