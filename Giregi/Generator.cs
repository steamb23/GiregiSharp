/*
 * 코드 설명이 필요하시다면 https://github.com/rainygirl/giregi 에서 코드를 분석하시거나 문의하세요.
 * 왠만하면 C#에 알맞게 포팅하려했는데 API가 다르다보니 조금 코드가 지저분 해졌습니다.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ilwar.Giregi
{
    public class Generator
    {
        public Generator(Post post)
        {
            this.Post = post;
        }
        /// <summary>
        /// 포스트를 가져오거나 설정합니다.
        /// </summary>
        public Post Post
        {
            get;
            set;
        }
        /// <summary>
        /// 기레기 기사를 생성합니다.
        /// </summary>
        /// <returns></returns>
        public string Generation()
        {
            Post post = this.Post;
            string[] tail = { "그와 함께 \"", "\"라면서,", " \"", "\"라고 했다.\n", "또\"", "\"라면서, ", "\"", "\"라고도 했다.\n", "\"는 등의 장문의 글을 남겼다.\n" };
            string[] reply = Shuffle(new string[] { "진짜 대단하다", "정말 멋지다", "감사해요", "궁금하네요" });
            string[] paragraphs_ = Cutting(PostInitalize(post));
            StringBuilder article = new StringBuilder();
            List<string> paragraphs = new List<string>();

            for (int i = 0; i < paragraphs_.Length; i++)
            {
                if (paragraphs_[i].RegexReplace(@"/\s/gi", "") == "")
                    continue;
                paragraphs.Add(paragraphs_[i].Trim());
            }
            article.Append("(서울=일워뉴스) 기레기 기자 = 최근 한 온라인 커뮤니티에 ").Append(post.title).Append("라는 글이 올라와 네티즌들의 화제를 모으고 있다.\n");
            if (string.Join("", paragraphs_).RegexReplace(@"/,/gi", "").Length == 0)
                article.Append(post.siteName).Append("의 닉네임 \"").Append(post.nickName).Append("라는 이용자가 ").Append(post.day).Append(" 올린 글은 화제의 그림을 담고 있으며, ");
            else
                article.Append(post.siteName).Append("의 닉네임 \"").Append(post.nickName).Append("라는 이용자가 ").Append(post.day).Append(" 올린 글에 따르면, \"");

            int j = 0;
            for (int i = 0; i < paragraphs.Count; i++)
            {
                if (j > 0 && tail[j % 8] != "")
                    article.Append(tail[j % 8]);
                article.Append(paragraphs[i].RegexReplace(@"/,/gi", "").RegexReplace(@"/./gi", ""));
                if (i == paragraphs.Count - 1)
                    article.Append(tail[3]);
                else if (j == 18)
                {
                    article.Append(tail[8]);
                    break;
                }
                else
                    article.Append(tail[j % 8 + 1]);
                j += 2;
                try
                {
                    post.title = post.title.Substring(0, 15) + (post.title.Length > 15 ? "..." : "");
                }
                catch (ArgumentOutOfRangeException)
                {
                    // 아무것도 안함.
                }
            }
            article.Append("이에 네티즌들은 \"").
                Append(post.title).Append(", ").Append(reply[0]).Append("\", \"").
                Append(post.title).Append(", ").Append(reply[1]).Append("\", \"").
                Append(post.title).Append(", ").Append(reply[2]).Append("\", \"").
                Append(post.title).Append(", ").Append(reply[3]).Append("\", \"").
                Append("\" 등의 반응을 보였다. \n\n온라인이슈팀\n\n<ⓒ정론직필 정통언론 일워뉴스 ilwar.com, 무단전재 배포금지>");
            return article.ToString();
        }
        // 배열 섞기
        string[] Shuffle(string[] stringArray)
        {
            List<string> list = new List<string>(stringArray);
            Stack<string> stack = new Stack<string>();
            Random random = new Random();
            while (0 < list.Count)
            {
                int index = random.Next(list.Count);
                stack.Push(list[index]);
                list.RemoveAt(index);
            }
            return stack.ToArray();
        }

        Post PostInitalize(Post post)
        {
            if (string.IsNullOrEmpty(post.day))
                post.day = "최근";
            return post;
        }
        string[] Cutting(Post post)
        {
            return post.text.RegexReplace(@"/<br>/gi", "\n").RegexReplace(@"/<([^>]+)>/gi", "").RegexReplace(@"/(<!--|-->)/gi", "").Replace(@"&nbsp;", " ").Split('\n');
        }
    }
}
