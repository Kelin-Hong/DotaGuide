using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
namespace Dota攻略宝典.Httphelp
{
    public delegate void Callback(string downloadStr);
    class HtmlHelp
    {
        Callback callback;
        public void DownloadImgae(string localpath, string uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                 IAsyncResult result=  request.BeginGetResponse(null, null);
                 HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
               // (HttpWebResponse)request.EndGetResponse();
                Stream read = response.GetResponseStream();
                int count = 0;
                byte[] buffer = new byte[1024 * 4];
                FileStream afile = new FileStream(localpath, FileMode.CreateNew);
                while ((count = read.Read(buffer, 0, buffer.Length)) > 0)
                {
                    afile.Write(buffer, 0, count);
                }
                if (response != null)
                    response.Close();
                if (read != null)
                    read.Close();
                if (afile != null)
                    afile.Close();

            }
            catch
            {
                throw;
            }

        }


        public void DownloadPage(string uri,Callback callback)
        {
            this.callback = callback;
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

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            callback(e.Result);
        }
       

        /// <summary>
        /// 获取唯一性的html部分，如果返回值是string.empty,则错误.
        /// </summary>
        /// <param name="source">html源码</param>
        /// <param name="tag">tag name</param>
        /// <param name="character">特征值</param>
        /// <returns></returns>
        public string GetUniqTag(string source, string tag, string character)
        {


            string begin = "<\\s*" + tag;
            string end = "<\\s*/\\s*" + tag + "\\s*>";
            string other = begin;

            int tempcount = 0;

            Regex regex_begin = new Regex(begin + "\\s*" + character, RegexOptions.IgnoreCase);
            Regex regex_other = new Regex(other, RegexOptions.IgnoreCase);
            Regex regex_end = new Regex(end, RegexOptions.IgnoreCase);


            /////begin match
            MatchCollection match_begin = regex_begin.Matches(source);
            //MatchCollection tests = regex_other.Matches(source);
            //Console.WriteLine(tests.Count);
            if (match_begin.Count > 0)
            {
                if (match_begin.Count == 1)
                {
                    tempcount = match_begin[0].Index;
                    source = source.Substring(tempcount);
                    MatchCollection matches_begin = regex_other.Matches(source);
                    MatchCollection matches_end = regex_end.Matches(source);
                    int count_begin = matches_begin.Count;
                    int count_end = matches_end.Count;

                    if (count_end > 0 && count_begin > 0)
                    {
                        int[] int_begin = new int[matches_begin.Count];
                        int[] int_end = new int[matches_end.Count];

                        for (int i = 0; i < count_begin; i++)
                        {
                            int_begin[i] = matches_begin[i].Index; //记录出现的位置
                        }
                        for (int i = 0; i < count_end; i++)
                        {
                            int_end[i] = matches_end[i].Index;//记录出现的位置
                        }
                        bool isend = false;

                        for (int i = 0; i < count_begin - 1; i++)
                        {
                            if (int_begin[i + 1] > int_end[i])
                            {
                                tempcount = int_end[i];
                                isend = true;
                                break;
                            }
                        }

                        if (isend == false)
                        {
                            tempcount = int_end[count_begin - 1];
                        }

                        if (source.Length == tempcount + tag.Length + 3)///because of </> sum 3;
                        {
                            return source;
                        }

                        else
                        {

                            string laststring = source.Substring(tempcount);

                            Regex tempregex = new Regex(">", RegexOptions.IgnoreCase);
                            Match tempmatch = tempregex.Match(laststring);

                            return source.Substring(0, tempcount + tempmatch.Index + 1);
                        }

                    }
                    // else throw new ArgumentException("源代码没有结束标签");
                    return string.Empty;


                }
                //else throw new ArgumentException("查找对象不是唯一");
                return string.Empty;
            }

            else
            {

                //throw new ArgumentException("未找到查找对象");
                return string.Empty;
            }


        }


        /// <summary>
        /// 获取第n个标签，空值表示未找到
        /// </summary>
        /// <param name="source">html源码</param>
        /// <param name="tag">tag标签</param>
        /// <param name="tagindex">从零开始的index</param>
        /// <returns></returns>
        public string GetIndexTag(string source, string tag, int tagindex = 0)
        {
            source += ">";
            string begin_string = "<\\s*" + tag + "[^>]*" + ">";
            string end_string = "</\\s*" + tag + "\\s*>";

            Regex begin_regex = new Regex(begin_string, RegexOptions.IgnoreCase);
            Regex end_regex = new Regex(end_string, RegexOptions.IgnoreCase);



            int begin_count = 0;

            int tozero = -1;
            int begin_record = 0;
            int end_record = 0;
            bool is_begin_on = true;

            bool is_tozero_on = true;



            MatchCollection temp_matches = begin_regex.Matches(source);


            if (temp_matches.Count <= tagindex)
                //return "error-tagindex is to large";
                return string.Empty;
            //空值代表没有合适的内容可以返回

            string tempsource = source.Substring(temp_matches[tagindex].Index);

            MatchCollection begin_matches = begin_regex.Matches(tempsource);
            MatchCollection end_matches = end_regex.Matches(tempsource);

            begin_count = begin_matches.Count;
            int i = 0;
            int j = 0;



            while (tozero != 0)
            {

                if (is_tozero_on)
                {
                    tozero = 0;
                    is_tozero_on = false;
                }
                try
                {

                    int begin_index = begin_matches[i].Index;
                    int end_index = end_matches[j].Index;



                    if (begin_index < end_index)
                    {

                        tozero += 1;
                        i = i + 1;
                        if (is_begin_on)
                        {
                            begin_record = begin_index;
                            is_begin_on = false;
                        }
                    }
                    else
                    {

                        tozero -= 1;
                        j = j + 1;
                        if (tozero == 0)
                        {
                            end_record = end_index;

                        }
                    }

                    if (i >= begin_count - 1)
                    {
                        if (i == 1)
                            i = 0;

                        end_record = end_matches[i].Index;

                        break;

                    }
                    //here have some special deal
                }
                catch 
                {
                    throw;

                }

            }
            int length = end_record - begin_record + tag.Length + 3;
            return tempsource.Substring(begin_record, length);



        }

        /// <summary>
        /// 获取tag标签内容，标签内不能有其他标签
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string GetTagContent(string source)
        {
            string returnModel = string.Empty;
            Regex regex = new Regex(">.*<", RegexOptions.IgnoreCase);

            Match match = regex.Match(source);
            if (match.Success)
            {
                return match.Value.Substring(1, match.Value.Length - 2).Trim();
            }
            else return string.Empty;

        }

        /// <summary>
        /// 获取符合条件的tag标签
        /// </summary>
        /// <param name="source">html源码</param>
        /// <param name="tag">tag标签</param>
        /// <param name="character">特征值</param>
        /// <returns></returns>
        public List<string> GetTagCollectByCharacter(string source, string tag, string character)
        {
            List<string> returnModel = new List<string>();

            //test


            string end_string = "</\\s*" + tag + "\\s*>";

            Regex begin_regex = new Regex("<" + tag + "\\s*" + character, RegexOptions.IgnoreCase);

            Regex end_regex = new Regex(end_string, RegexOptions.IgnoreCase);
            string tempstring = source;

            while (true)
            {
                MatchCollection begin_matches = begin_regex.Matches(tempstring);
                if (begin_matches.Count <= 0)
                    return returnModel;

                int begin = begin_matches[0].Index;
                tempstring = tempstring.Substring(begin);

                string addModel = GetIndexTag(tempstring, tag, 0);
                returnModel.Add(addModel);

                tempstring = tempstring.Substring(addModel.Length);

            }
        }



        /// <summary>
        /// 返回格式：<img src=""></img>
        /// </summary>
        /// <param name="source">html源码</param>
        /// <returns></returns>
        public List<string> GetImgTagFromHtml(string source)
        {
            string img = "<img\\s*src=\"[^>]*>";
            Regex begin_regex = new Regex(img, RegexOptions.IgnoreCase);

            MatchCollection matches = begin_regex.Matches(source);

            List<string> returnModel = new List<string>();

            int imagecount = 0;
            if ((imagecount = matches.Count) <= 0)
                return returnModel;

            for (int i = 0; i < imagecount; i++)
            {
                returnModel.Add(matches[i].Value);
            }

            return returnModel;


        }
        public List<string> GetImgTagFromHtml1(string source)
        {
            // string img = "<img\\s*src=\"[^>]*>";
            string img = "<img.*>";
            Regex begin_regex = new Regex(img, RegexOptions.IgnoreCase);

            MatchCollection matches = begin_regex.Matches(source);

            List<string> returnModel = new List<string>();

            int imagecount = 0;
            if ((imagecount = matches.Count) <= 0)
                return returnModel;

            for (int i = 0; i < imagecount; i++)
            {
                returnModel.Add(matches[i].Value);
            }

            return returnModel;


        }

    }
}
