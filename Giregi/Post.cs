using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ilwar.Giregi
{
    public struct Post
    {
        public Post(string day, string siteName, string nickName, string title, string text)
        {
                this.day = day;
                this.siteName = siteName;
                this.nickName = nickName;
                this.title = title;
                this.text = text;
        }
        public string day;
        public string siteName;
        public string nickName;
        public string title;
        public string text;
    }
}
