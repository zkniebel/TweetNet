using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetNET.OAuth;
using TweetNET.Parameters;

namespace TweetNET.Requests.Streaming.Statuses {
    /// <summary>
    /// 
    /// </summary>
    public class FilterRequest : Request {
        private const string FOLLOW_KEY = "follow";
        private const string TRACK_KEY = "track";
        private const string LOCATIONS_KEY = "locations";
        private const string DELIMITED_KEY = "delimited";
        private const string STALL_WARNINGS_KEY = "stall_warnings";

        private string _Follow = string.Empty;
        private string _Track = string.Empty;
        private string _Locations = string.Empty;
        private string _Delimited = string.Empty;
        private string _Stall_Warnings = string.Empty;

        /// <summary>
        /// (optional) - 
        /// A comma separated list of user IDs, indicating the users to return statuses for in the stream. 
        /// <para>
        /// See the follow parameter documentation for more information (https://dev.twitter.com/docs/streaming-apis/parameters#follow)
        /// </para>
        /// </summary>
        public string Follow {
            get {
                return _Follow;
            }
            set {
                RequestParams.Add(FOLLOW_KEY, value);
                _Follow = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// 
        /// </summary>
        public string Track {
            get {
                return _Track;
            }
            set {
                RequestParams.Add(TRACK_KEY, value);
                _Track = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// 
        /// </summary>
        /// <example></example>
        public string Locations {
            get {
                return _Locations;
            }
            set {
                RequestParams.Add(LOCATIONS_KEY, value);
                _Locations = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// 
        /// </summary>
        /// <example></example>
        public string Delimited {
            get {
                return _Delimited;
            }
            set {
                RequestParams.Add(DELIMITED_KEY, value);
                _Delimited = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// 
        /// </summary>
        /// <example></example>
        public string Stall_Warnings {
            get {
                return _Stall_Warnings;
            }
            set {
                RequestParams.Add(STALL_WARNINGS_KEY, value);
                _Stall_Warnings = value;
            }
        }

        /// <summary>
        /// Creates a new StatusesFilterGETRequest instance
        /// </summary>
        /// <param name="requestMethod">Enum value representing the desired request method (either GET or POST)</param>
        /// <param name="tokens">A SecurityTokens object that holds all of the keys, tokens and secrets assigned by Twitter</param>
        public FilterRequest(RequestMethods requestMethod, SecurityTokens tokens)
            : base(requestMethod, Globals.Common.RESOURCE_URL_STATUSES_FILTER, new RequestParameterCollection(), tokens) {
        }
    }
}
