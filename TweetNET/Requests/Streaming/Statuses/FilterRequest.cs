using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetNET.OAuth;
using TweetNET.Parameters;

namespace TweetNET.Requests.Streaming.Statuses {
    /// <summary>
    /// Class used for requesting public statuses that match one or more filter predicates. 
    /// </summary>
    /// <remarks>
    /// Multiple parameters may be specified which allows most clients to use a single connection to the Streaming API. Both GET and POST 
    /// requests are supported, but GET requests with too many parameters may cause the request to be rejected for excessive URL length. 
    /// Use a POST request to avoid long URLs.
    /// <para>
    /// The track, follow, and locations fields should be considered to be combined with an OR operator. track=foo&amp;follow=1234 returns 
    /// Tweets matching "foo" OR created by user 1234.
    /// </para>
    /// The default access level allows up to 400 track keywords, 5,000 follow userids and 25 0.1-360 degree location boxes. If you need 
    /// elevated access to the Streaming API, you should explore our partner providers of Twitter data here.
    /// </remarks>
    public class FilterRequest : RequestBuilder {
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
        /// <para>
        /// (At least one of <see cref="FilterRequest.Track"/>, <see cref="FilterRequest.Follow"/>, or <see cref="FilterRequest.Locations"/> must 
        /// be specified)
        /// </para>
        /// A comma separated list of user IDs, indicating the users to return statuses for in the stream. 
        /// </summary>
        /// <remarks>
        /// See the <a href="https://dev.twitter.com/docs/streaming-apis/parameters#follow">follow parameter documentation</a> for more information 
        /// </remarks>
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
        /// <para>
        /// (At least one of <see cref="FilterRequest.Track"/>, <see cref="FilterRequest.Follow"/>, or <see cref="FilterRequest.Locations"/> must 
        /// be specified)
        /// </para>
        /// Keywords to track. Phrases of keywords are specified by a comma-separated list. 
        /// </summary>
        /// <remarks>
        /// See the <a href="https://dev.twitter.com/docs/streaming-apis/parameters#track">track parameter documentation</a> for more information 
        /// </remarks>
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
        /// <para>
        /// (At least one of <see cref="FilterRequest.Track"/>, <see cref="FilterRequest.Follow"/>, or <see cref="FilterRequest.Locations"/> must 
        /// be specified)
        /// </para>
        /// Specifies a set of bounding boxes to track. 
        /// </summary>
        /// <remarks>
        /// See the <a href="https://dev.twitter.com/docs/streaming-apis/parameters#locations">locations parameter documentation</a> for more information 
        /// </remarks>
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
        /// Specifies whether messages should be length-delimited. 
        /// </summary>
        /// <remarks>
        /// See the <a href="https://dev.twitter.com/docs/streaming-apis/parameters#delimited">delimited parameter documentation</a> for more information 
        /// </remarks>
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
        /// Specifies whether stall warnings should be delivered. 
        /// </summary>
        /// <remarks>
        /// See the <a href="https://dev.twitter.com/docs/streaming-apis/parameters#stall_warnings">stall_warnings parameter documentation</a> for more information
        /// </remarks>
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
        /// Creates a new <see cref="FilterRequest"/> instance
        /// </summary>
        /// <param name="requestMethod"><see cref="RequestBuilder.RequestMethods"/> value representing the desired request method (either GET or POST)</param>
        /// <param name="tokens">
        /// <see cref="SecurityTokens"/> object that holds all of the keys, tokens and secrets assigned by Twitter for authorizing the request
        /// </param>
        public FilterRequest(RequestMethods requestMethod, SecurityTokens tokens)
            : base(requestMethod, "https://stream.twitter.com/1.1/statuses/filter.json", new RequestParameterCollection(), tokens) {
        }
    }
}
