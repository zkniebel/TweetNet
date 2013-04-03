using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetNET.OAuth;
using TweetNET.Parameters;

namespace TweetNET.Requests.Search {
    /// <summary>
    /// Class used for requesting a collection of relevant Tweets matching a specified query. 
    /// </summary>
    /// <remarks>
    /// In API v1.1, the response format of the Search API has been improved to return Tweet objects more similar to the objects you'll 
    /// find across the REST API and platform. You may need to tolerate some inconsistencies and variance in perspectival values (fields that 
    /// pertain to the perspective of the authenticating user) and embedded user objects.
    /// <para>
    /// Please note that Twitter's search service and, by extension, the Search API is not meant to be an exhaustive source of Tweets. Not all Tweets 
    /// will be indexed or made available via the search interface.
    /// </para>
    /// </remarks>
    public class TweetsRequest : RequestBuilder {
        private const string Q_KEY = "q";
        private const string GEOCODE_KEY = "geocode";
        private const string LANG_KEY = "lang";
        private const string LOCALE_KEY = "locale";
        private const string RESULT_TYPE_KEY = "result_type";
        private const string COUNT_KEY = "count";
        private const string UNTIL_KEY = "until";
        private const string SINCE_ID_KEY = "since_id";
        private const string MAX_ID_KEY = "max_id";
        private const string INCLUDE_ENTITIES_KEY = "include_entities";
        private const string CALLBACK_KEY = "callback";

        private string _Q = string.Empty;
        private string _Geocode = string.Empty;
        private string _Lang = string.Empty;
        private string _Locale = string.Empty;
        private string _Result_Type = string.Empty;
        private string _Count = string.Empty;
        private string _Until = string.Empty;
        private string _Since_ID = string.Empty;
        private string _Max_ID = string.Empty;
        private string _Include_Entities = string.Empty;
        private string _Callback = string.Empty;

        /// <summary>
        /// (required) - 
        /// A UTF-8, URL-encoded search query of 1,000 characters maximum, including operators. 
        /// <para>
        /// Queries may additionally be limited by complexity.
        /// </para>
        /// </summary>
        /// <example>Example Values: @noradio</example>
        public string Q {
            get {
                return _Q;
            }
            set {
                RequestParams.Add(Q_KEY, value);
                _Q = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Returns tweets by users located within a given radius of the given latitude/longitude. 
        /// </summary>
        /// <remarks>
        /// The location is preferentially taking from the Geotagging API, but will fall back to their Twitter profile. The parameter value is 
        /// specified by "latitude,longitude,radius", where radius units must be specified as either "mi" (miles) or "km" (kilometers). Note 
        /// that you cannot use the near operator via the API to geocode arbitrary locations; however you can use this geocode parameter to 
        /// search near geocodes directly. A maximum of 1,000 distinct "sub-regions" will be considered when using the radius modifier.
        /// </remarks>
        /// <example>Example Values: 37.781157,-122.398720,1mi</example>
        public string Geocode {
            get {
                return _Geocode;
            }
            set {
                RequestParams.Add(GEOCODE_KEY, value);
                _Geocode = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Restricts tweets to the given language, given by an ISO 639-1 code. Language detection is best-effort.
        /// </summary>
        /// <example>Example Values: eu</example>
        public string Lang {
            get {
                return _Lang;
            }
            set {
                RequestParams.Add(LANG_KEY, value);
                _Lang = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Specify the language of the query you are sending (only ja is currently effective). 
        /// </summary>
        /// <remarks>
        /// This is intended for language-specific consumers and the default should work in the majority of cases.
        /// </remarks>
        /// <example>Example Values: ja</example>
        public string Locale {
            get {
                return _Locale;
            }
            set {
                RequestParams.Add(LOCALE_KEY, value);
                _Locale = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Specifies what type of search results you would prefer to receive. 
        /// <para>
        /// The current default is "mixed." Valid values include:
        /// </para>
        /// <list type="bullet">
        ///  <item>mixed: Include both popular and real time results in the response.</item>
        ///  <item>recent: return only the most recent results in the response</item>
        ///  <item>popular: return only the most popular results in the response.</item>
        ///  </list>
        /// </summary>
        /// <example>Example Values: mixed, recent, popular</example>
        public string Result_Type {
            get {
                return _Result_Type;
            }
            set {
                RequestParams.Add(RESULT_TYPE_KEY, value);
                _Result_Type = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// The number of tweets to return per page, up to a maximum of 100. Defaults to 15. 
        /// </summary>
        /// <remarks>
        /// This was formerly the "rpp" parameter in the old Search API. 
        /// </remarks>
        /// <example>Example Values: 100</example>
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
        /// Returns tweets generated before the given date. 
        /// <para>
        /// Date should be formatted as YYYY-MM-DD. 
        /// </para>
        /// </summary>
        /// <remarks>
        /// Keep in mind that the search index may not go back as far as the date you specify here.
        /// </remarks>
        /// <example>Example Values: 2012-09-01</example>
        public string Until {
            get {
                return _Until;
            }
            set {
                RequestParams.Add(UNTIL_KEY, value);
                _Until = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. 
        /// </summary>
        /// <remarks>
        /// There are limits to the number of Tweets which can be accessed through the API. If the limit of Tweets has occured since the 
        /// since_id, the since_id will be forced to the oldest ID available.
        /// </remarks>
        /// <example>Example Values: 12345</example>
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
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        /// <example>Example Values: 54321</example>
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
        /// The entities node will be disincluded when set to false.
        /// </summary>
        /// <example>Example Values: false</example>
        public string Include_Entities {
            get {
                return _Include_Entities;
            }
            set {
                RequestParams.Add(INCLUDE_ENTITIES_KEY, value);
                _Include_Entities = value;
            }
        }
        /// <summary>
        /// (optional) - 
        /// If supplied, the response will use the JSONP format with a callback of the given name. 
        /// </summary>
        /// <remarks>
        /// The usefulness of this parameter is somewhat diminished by the requirement of authentication for requests to this endpoint.
        /// </remarks>
        /// <example>Example Values: processTweets</example>
        public string Callback {
            get {
                return _Callback;
            }
            set {
                RequestParams.Add(CALLBACK_KEY, value);
                _Callback = value;
            }
        }

        /// <summary>
        /// Creates a new <see cref="TweetsRequest"/> instance
        /// </summary>
        /// <param name="q">UTF-8, URL-encoded search query (see the <see cref="TweetsRequest.Q"/> property)</param>
        /// <param name="tokens">The <see cref="SecurityTokens"/> object holding the security keys, tokens, and secrets assigned by Twitter</param>
        public TweetsRequest(string q, SecurityTokens tokens)
            : base(RequestMethods.GET, "https://api.twitter.com/1.1/search/tweets.json", new RequestParameterCollection(), tokens) {
            Q = q;
        }
    }
}
