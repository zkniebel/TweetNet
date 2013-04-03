using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetNET.Parameters {
    /// <summary>
    /// Class representation of a list of <see cref="RequestParameter"/> objects
    /// </summary>
    /// <remarks>
    /// Note that this class inherits <see cref="System.Collections.Generic.List{T}"/> and overloads the <see cref="System.Collections.Generic.List{T}.Add"/> method. The overloading method should almost 
    /// always be used when adding <see cref="RequestParameter"/> objects to the collection.
    /// </remarks>
    public class RequestParameterCollection : List<RequestParameter> {

        /// <summary>
        /// Adds a new <see cref="RequestParameter"/> object with the given key and value to the collection
        /// </summary>
        /// <param name="key">The <see cref="RequestParameter.Key"/> of the <see cref="RequestParameter"/> object to add</param>
        /// <param name="value">The <see cref="RequestParameter.Value"/> of the <see cref="RequestParameter"/> object to add</param>
        public void Add(string key, string value) {
            RemoveAll(i => i.Key == key);
            Add(new RequestParameter(key, value));
        }
    }
}
