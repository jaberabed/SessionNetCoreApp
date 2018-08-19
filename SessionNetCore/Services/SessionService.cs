using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SessionNetCore.Models;
using System.Collections.Generic;

namespace SessionNetCore.Services
{
    public class SessionService
    {
        public void Set(ISession session, string key, Bookmark bookmark)
        {
            var bookmarks = Get(session, key);
            if (bookmarks == null)
            {
                bookmarks = new List<Bookmark>();
            }
            bookmarks.Add(bookmark);
            session.SetString(key, JsonConvert.SerializeObject(bookmarks));
        }

        public List<Bookmark> Get(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(List<Bookmark>) :
                JsonConvert.DeserializeObject<List<Bookmark>>(value);
        }
    }
}
