using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetNET.OAuth;
using TweetNET.Parameters;
using System.Net;

namespace TweetNET.Requests.Timelines.Statuses {
    /// <summary>
    /// <para>
    /// Returns a collection of the most recent Tweets posted by the user indicated by the screen_name or user_id parameters. 
    /// </para>
    /// <para>
    /// User timelines belonging to protected users may only be requested when the authenticated user either "owns" the timeline or is an approved 
    /// follower of the owner. 
    /// </para>
    /// </summary>
    /// <remarks>
    /// The  timeline returned is the equivalent of the one seen when you view a user's profile on twitter.com. This method can only return up to 3,200 of a 
    /// user's most recent Tweets. Native retweets of other statuses by the user is included in this total, regardless of whether include_rts is set to 
    /// false when requesting this resource.
    /// </remarks>
    public class UserTimelineRequest : Request {
        private const string USER_ID_KEY = "user_id";
        private const string SCREEN_NAME_KEY = "screen_name"; 
        private const string SINCE_ID_KEY = "since_id";
        private const string COUNT_KEY = "count";
        private const string MAX_ID_KEY = "max_id";
        private const string TRIM_USER_KEY = "trim_user";
        private const string EXCLUDE_REPLIES_KEY = "exclude_replies";
        private const string CONTRIBUTOR_DETAILS_KEY = "contributor_details";
        private const string INCLUDE_RTS_KEY = "include_rts";

        private string _User_ID = string.Empty;
        private string _Screen_Name = string.Empty;
        private string _Since_ID = string.Empty;
        private string _Count = string.Empty;
        private string _Max_ID = string.Empty;
        private string _Trim_User = string.Empty;
        private string _Exclude_Replies = string.Empty;
        private string _Contributor_Details = string.Empty;
        private string _Include_RTS = string.Empty;

        /// <summary>
        /// (one of User_ID and Screen_Name must be set) - 
        /// ID of the user for whom to return results for.
        /// </summary>
        /// <example>Example Values: "12345"</example>
        public string User_ID {
            get {
                return _User_ID;
            }
            set {
                RequestParams.Add(USER_ID_KEY, value);
                _User_ID = value;
            }
        }
        /// <summary>
        /// (one of User_ID and Screen_Name must be set) - 
        /// The screen name of the user for whom to return results for.
        /// </summary>
        /// <example>Example Values: "noradio"</example>
        public string Screen_Name {
            get {
                return _Screen_Name;
            }
            set {
                RequestParams.Add(SCREEN_NAME_KEY, value);
                _Screen_Name = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. 
        /// </summary>
        /// <remarks>
        /// There are limits to the number of Tweets which can be accessed through the API. If the 
        /// limit of Tweets has occured since the since_id, the since_id will be forced to the 
        /// oldest ID available.
        /// </remarks>
        /// <example>Example Values: "12345"</example>
        public string Since_ID {
            get {
                return _Since_ID;
            }
            set {
                RequestParams.Add(SINCE_ID_KEY, value);
                _Since_ID = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Specifies the number of tweets to try and retrieve, up to a maximum of 200 per distinct
        /// request.
        /// </summary>
        /// <remarks>
        /// The value of count is best thought of as a limit to the number of tweets to 
        /// return because suspended or deleted content is removed after the count has been applied. 
        /// We include retweets in the count, even if include_rts is not supplied. It is recommended 
        /// you always send include_rts=1 when using this API method.
        /// </remarks>
        /// <example>Example Values: "25"</example>
        public string Count {
            get {
                return _Count;
            }
            set {
                RequestParams.Add(COUNT_KEY, value);
                _Count = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        /// <example>Example Values: "54321"</example>
        public string Max_ID {
            get {
                return _Max_ID;
            }
            set {
                RequestParams.Add(MAX_ID_KEY, value);
                _Max_ID = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// When set to either true, t or 1, each tweet returned in a timeline will include a user 
        /// object including only the status authors numerical ID. 
        /// <para>
        /// Omit this parameter to receive the complete user object.
        /// </para>
        /// </summary>
        /// <example>Example Values: "true"</example>
        public string Trim_User {
            get {
                return _Trim_User;
            }
            set {
                RequestParams.Add(TRIM_USER_KEY, value);
                _Trim_User = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// This parameter will prevent replies from appearing in the returned timeline. 
        /// </summary>
        /// <remarks>
        /// Using exclude_replies with the count parameter will mean you will receive up-to count tweets — 
        /// this is because the count parameter retrieves that many tweets before filtering out 
        /// retweets and replies. This parameter is only supported for JSON and XML responses.
        /// </remarks>
        /// <example>Example Values: "true"</example>
        public string Exclude_Replies {
            get {
                return _Exclude_Replies;
            }
            set {
                RequestParams.Add(EXCLUDE_REPLIES_KEY, value);
                _Exclude_Replies = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// This parameter enhances the contributors element of the status response to include the 
        /// screen_name of the contributor. 
        /// <para>
        /// By default only the user_id of the contributor is included.
        /// </para>
        /// </summary>
        /// <example>Example Values: "true"</example>
        public string Contributor_Details {
            get {
                return _Contributor_Details;
            }
            set {
                RequestParams.Add(CONTRIBUTOR_DETAILS_KEY, value);
                _Contributor_Details = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// When set to false, the timeline will strip any native retweets (though they will still 
        /// count toward both the maximal length of the timeline and the slice selected by the 
        /// count parameter). 
        /// </summary>
        /// <remarks>Note: If you're using the trim_user parameter in conjunction with 
        /// include_rts, the retweets will still contain a full user object.</remarks>
        /// <example>Example Values: "false"</example>
        public string Include_RTS {
            get {
                return _Include_RTS;
            }
            set {
                RequestParams.Add(INCLUDE_RTS_KEY, value);
                _Include_RTS = value;
            }
        }

        /// <summary>
        /// Creates a new UserTimelineRequest instance
        /// </summary>
        /// <param name="oAuthTokens">oAuth keys, tokens and secrets used to authorize the request</param>
        public UserTimelineRequest(SecurityTokens oAuthTokens)
            : base(RequestMethods.GET, Globals.Common.RESOURCE_URL_USER_TIMELINE, new RequestParameterCollection(), oAuthTokens) {
        }

        public override HttpWebRequest BuildRequest(string compositeKey) {
            if (Screen_Name != string.Empty || User_ID != string.Empty) {
                return base.BuildRequest(compositeKey);
            } else {
                throw new Exception("Request not built: A User ID or Screen Name must be supplied for this request");
            }
        }
    }
}
