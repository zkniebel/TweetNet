using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetNET.Globals {
    /// <summary>
    /// Class to hold commonly used string constants
    /// </summary>
    public class Common {
        /// <summary>
        /// String used to represent the GET request method
        /// </summary>
        /// <value>"GET"</value>
        public const string REQUEST_METHOD_GET = "GET";
        /// <summary>
        /// String used to represent the POST request method
        /// </summary>
        /// <value>
        /// "POST"
        /// </value>
        public const string REQUEST_METHOD_POST = "POST";

        /// <summary>
        /// Ampersand-delimited string format
        /// </summary>
        /// <value>
        /// "{0}&amp;{1}"
        /// </value>
        public const string STRING_FORMAT_AMPERSAND_DELIM = "{0}&{1}";
        /// <summary>
        /// Question mark-delimited string format
        /// </summary>
        /// <value>
        /// "{0}?{1}"
        /// </value>
        public const string STRING_FORMAT_QUESTION_MARK_DELIM = "{0}?{1}";

        /// <summary>
        /// String consisting of, and only of an ampersand
        /// </summary>
        /// <value>
        /// "&amp;"
        /// </value>
        public const string COMMON_STRING_AMPERSAND = "&";
    }
}
