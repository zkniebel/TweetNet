using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetNET.OAuth;
using TweetNET.Parameters;

namespace TweetNET.Requests.Tweets.Show {
    /// <summary>
    /// Returns a single Tweet, specified by the id parameter. The Tweet's author will also be embedded within the tweet.
    /// </summary>
    public class ByIDRequest : Request {
        private const string ID_KEY = "id";
        private const string TRIM_USER_KEY = "trim_user";
        private const string INCLUDE_MY_RETWEET_KEY = "include_my_retweet";
        private const string INCLUDE_ENTITIES_KEY = "include_entities";

        private string _ID = string.Empty;
        private string _Trim_User = string.Empty;
        private string _Include_My_Retweet = string.Empty;
        private string _Include_Entities = string.Empty;

        /// <summary>
        /// (required) - 
        /// The numerical ID of the desired Tweet.
        /// </summary>
        /// <example>Example Values: 123</example>
        public string ID {
            get {
                return _ID;
            }
            set {
                RequestParams.Add(ID_KEY, value);
            }
        }
        /// <summary>
        /// (optional) - 
        /// When set to either true, t or 1, each tweet returned in a timeline will include a user object including 
        /// only the status authors numerical ID. 
        /// <para>Omit this parameter to receive the complete user object.</para>
        /// </summary>
        /// <example>Example Values: true</example>
        public string Trim_User {
            get {
                return _Trim_User;
            }
            set {
                RequestParams.Add(TRIM_USER_KEY, value);
            }
        }
        /// <summary>
        /// (optional) - 
        /// When set to either true, t or 1, any Tweets returned that have been retweeted by the authenticating 
        /// user will include an additional current_user_retweet node, containing the ID of the source status for 
        /// the retweet.
        /// </summary>
        /// <example>Example Values: true</example>
        public string Include_My_Retweet {
            get {
                return _Include_My_Retweet;
            }
            set {
                RequestParams.Add(INCLUDE_MY_RETWEET_KEY, value);
            }
        }
        /// <summary>
        /// (optional) - 
        /// The entities node will be disincluded when set to false.
        /// </summary>
        /// <example>Example Values: false</example>
        public string Include_Entities {
            get {
                return _Include_Entities;
            }
            set {
                RequestParams.Add(INCLUDE_ENTITIES_KEY, value);
            }
        }

        /// <summary>
        /// Creates a new StatusByIDGETRequest instance
        /// </summary>
        /// <param name="id">ID of the tweet to be retrieved</param>
        /// <param name="oAuthTokens">oAuth security keys, tokens and secrets assigned by Twitter</param>
        public ByIDRequest(string id, SecurityTokens oAuthTokens) 
            : base(RequestMethods.GET, Globals.Common.RESOURCE_URL_STATUS_BY_ID, new RequestParameterCollection(), oAuthTokens) {
                ID = id;
        }
    }
}
