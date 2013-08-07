using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Dota攻略宝典.Httphelp
{
    public class HtmlHelper
    {
       static Callback callback;
        public static void DownloadPage(string uri, Callback _callback)
        {
            callback = _callback;
            try
            {
                WebClient client = new WebClient();
                //client.Encoding = Encoding.Unicode;
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri(uri));
            }
            catch
            {
                callback("NO");
            }
        }

        static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            callback(e.Result);
        }
            
            internal static string getOnlyTag(string html, string tag, string name, string character)
            {
                // string s = "<div class=\"feed-list\"><a>dfsf</a><div class=\"index\">fslfs</div></div>";
                string pattern = @"<" + tag + " " + name + "=" + "\"" + character + "\"" + "[\\s\\S]*?" + "<" + "/" + tag + ">";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(html))
                {
                    return regex.Match(html).Value;
                }
                return null;
            }
            internal static string getOnlyTag(string html, string tag)
            {
                // string s = "<div class=\"feed-list\"><a>dfsf</a><div class=\"index\">fslfs</div></div>";
                string pattern = @"<" + tag + ">" + "[\\s\\S]*?" + "<" + "/" + tag + ">";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(html))
                {
                    return regex.Match(html).Value;
                }
                return null;
            }
            internal static List<string> getTagCollection(string html, string tag, string name, string character)
            {
                string pattern = "<" + tag + "[\\s\\S]*?" + name + "=" + "\"" + character + "\"" + "[\\s\\S]*?" + "<" + "/" + tag + ">";
                Regex regex = new Regex(pattern);
                MatchCollection matchCollection = regex.Matches(html);

                if (matchCollection.Count != 0)
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < matchCollection.Count; i++)
                    {
                        list.Add(matchCollection[i].Value);
                    }
                    return list;
                }

                return null;
            }
            internal static string getContent(string html, string tag)
            {

                int begin = html.IndexOf('>');

                int end = html.LastIndexOf('<');
                return html.Substring(begin + 1, end - begin - 1);
            }
        

    }
}
