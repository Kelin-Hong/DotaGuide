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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dota攻略宝典.DataBase;
namespace Dota攻略宝典.Httphelp
{
    public class GetDataHelp
    {
    }

    // class PageHero
    //{
    //    public void DownloadPage()
    //    {
    //        string link = "http://dota.sgamer.com/hero/";
    //        HtmlHelp htmlhelp = new HtmlHelp();
    //        string dotapage = htmlhelp.DownloadPage(link);
    //        string heropart = htmlhelp.GetUniqTag(htmlhelp.DownLoadStr, "div", "class=\"BG_Block\"");
    //        List<string> allheros = htmlhelp.GetTagCollectByCharacter(heropart, "li", "");
    //        foreach (var item in allheros)
    //        {
    //            Hero hero = new Hero(item);
    //        }
    //    }
    //}

    class Hero
    {
        public string Alt { get; set; }
        public string Href { get; set; }
        public string Src { get; set; }


        public string GetContent(string source, string item)
        {
            int begin = item.Length;
            Regex regex = new Regex(item + "=\"[^\"]*" + "\"");
            Match match = regex.Match(source);

            if (match.Success)
            {
                return match.Value.Substring(begin + 2).Trim('"');
            }
            return string.Empty;
        }
        public Hero(string source)
        {
            Alt = GetContent(source, "alt");
            Href = GetContent(source, "href");
            Src = GetContent(source, "src");
        }

        //public void DownloadImage(string path, string src)
        //{
        //    HtmlHelp htmlhelp = new HtmlHelp();
        //    htmlhelp.DownloadImgae(path, src);
        //}
        //public void DownloadPage(string link)
        //{

        //    HtmlHelp htmlhelp = new HtmlHelp();
        //    string page = htmlhelp.DownloadPage(link);
        //    string main = htmlhelp.GetUniqTag(page, "div", "");

        //}
    }

    class SingleHeroClass
    {
        public string Image { get; set; }

        public string Chinese { get; set; }
        public string Kuaijie { get; set; }
        public string English { get; set; }
        public string Short { get; set; }

        public string Body { get; set; }

        //输出等数据
        public int Gank { get; set; }
        public int Shuchu { get; set; }
        public int Fuzhu { get; set; }
        public int Tuijin { get; set; }
        public int Roudun { get; set; }

        //
        public string Changgui { get; set; }
        public List<string> ChangguiImage { get; set; }
        public string Chumen { get; set; }
        public List<string> ChumenImage { get; set; }
        public string Zhongqi { get; set; }
        public List<string> ZhongqiImage { get; set; }
        public string Houqi { get; set; }
        public List<string> HouqiImage { get; set; }

        //
        public List<Jineng> list_Jienng = new List<Jineng>();
        public Jineng First = new Jineng();
        public Jineng Second = new Jineng();
        public Jineng Third = new Jineng();
        public Jineng Forth = new Jineng();

        //function
        private string page;
        private HtmlHelp htmlhelp = new HtmlHelp();
        public SingleHeroClass(string _page)
        {

           // page = htmlhelp.DownloadPage(link);
            page = _page;
            FillData();
        }




        private void FillData()
        {
            GetImage();
            GetHead();
            GetBody();
            GetRank();
            GetJiadian();
            GetJineng();

        }

        private void GetImage()
        {
            string content = htmlhelp.GetUniqTag(page, "div", "class=\"H_pic1\"");
            Image = GetContent(content, "src");
        }
        private string GetContent(string source, string item)
        {
            int begin = item.Length;
            Regex regex = new Regex(item + "=\"[^\"]*" + "\"");
            Match match = regex.Match(source);

            if (match.Success)
            {
                return match.Value.Substring(begin + 2).Trim('"');
            }
            return string.Empty;
        }

        private void GetHead()
        {
            string content = htmlhelp.GetUniqTag(page, "div", "class=\"H_mid_R\"");
            string h1 = "<h1>";
            string zuokuohao = "(";
            string kuaijie = "快捷键:";
            string jiancheng = "简称:";
            string h4 = "<h4>";

            int h1_index = content.IndexOf(h1);
            int zuokuohao_index = content.IndexOf(zuokuohao);
            Chinese = content.Substring(h1_index + h1.Length, zuokuohao_index - h1_index - h1.Length);

            int kuaijie_index = content.IndexOf(kuaijie);
            Kuaijie = content.Substring(kuaijie_index + kuaijie.Length, 1);

            int h4_index = content.IndexOf(h4);
            int jiancheng_index = content.IndexOf(jiancheng);
            English = content.Substring(h4_index + h4.Length, jiancheng_index - h4.Length - h4_index).Trim();

            int h4endindex = content.IndexOf(@"</h4>");
            Short = content.Substring(jiancheng_index + jiancheng.Length, h4endindex - jiancheng.Length - jiancheng_index);

            return;

        }

        private void GetBody()
        {
            string content = htmlhelp.GetUniqTag(page, "div", "class=\"H_mid_content\"");
            int begin = content.IndexOf("<p>") + 3;
            int end = content.IndexOf("</p>");
            Body = content.Substring(begin, end - begin);
        }

        private void GetRank()
        {
            //content contains all canshu;
            string content = htmlhelp.GetUniqTag(page, "div", "class=\"H_right\"");

            Gank = CountImage(content, 0);
            Shuchu = CountImage(content, 1);
            Fuzhu = CountImage(content, 2);
            Tuijin = CountImage(content, 3);
            Roudun = CountImage(content, 4);

        }

        private int CountImage(string source, int part)
        {
            string content = htmlhelp.GetIndexTag(source, "tr", part);

            string xingxing = "xx_b.jpg";
            Regex regex = new Regex(xingxing, RegexOptions.IgnoreCase);
            return regex.Matches(content).Count;
        }

        public string GetChinese(string source)
        {

            Regex regex_chinese = new Regex("([\u4e00-\u9fa5])*");
            Match match = regex_chinese.Match(source);
            if (match.Success)
            {
                return match.Value;
            }
            return string.Empty;

        }
        private string GetIntro(string source)
        {
            string target = "<div class=\"skillnote\">";
            int index = source.IndexOf(target) + target.Length;
            return source.Substring(index).Replace("</div>", "");
        }

        private void GetJiadian()
        {
            string content = htmlhelp.GetUniqTag(page, "div", "id=\"jinengjiadian\"");

            List<string> contents = htmlhelp.GetTagCollectByCharacter(content, "div", "class=\"styleContent\"");
            if (contents.Count == 4)
            {
                ChangguiImage = htmlhelp.GetImgTagFromHtml(contents[0]);
                Changgui = GetIntro(contents[0]);
                ChumenImage = new List<string>();
                foreach(string s in htmlhelp.GetImgTagFromHtml(contents[1]))
                {
                    ChumenImage.Add(GetContent(s, "src"));
               
                }
                 Chumen = GetIntro(contents[1]);
                 ZhongqiImage = new List<string>();
                foreach(string s in htmlhelp.GetImgTagFromHtml(contents[2]))
                {
                    ZhongqiImage.Add(GetContent(s, "src"));
                }
                Zhongqi = GetIntro(contents[2]);
                HouqiImage = new List<string>();
                 foreach(string s in htmlhelp.GetImgTagFromHtml(contents[3]))
                {
                    HouqiImage.Add(GetContent(s, "src"));
                }
                Houqi = GetIntro(contents[3]);
            }
        }

        private void GetJineng()
        {
            string content = htmlhelp.GetUniqTag(page, "div", "id=\"jieshao\"");
            List<string> contents = htmlhelp.GetTagCollectByCharacter(content, "li", "class=\"H_Skill wrapfix\"");
            if (contents.Count == 4)
            {
                FillJineng(contents[0], ref First.Image, ref First.Name, ref First.Kuaijie, ref First.Intro, ref First.Detail);

                FillJineng(contents[1], ref Second.Image, ref Second.Name, ref Second.Kuaijie, ref Second.Intro, ref Second.Detail);

                FillJineng(contents[2], ref Third.Image, ref Third.Name, ref Third.Kuaijie, ref Third.Intro, ref Third.Detail);

                FillJineng(contents[3], ref Forth.Image, ref Forth.Name, ref Forth.Kuaijie, ref Forth.Intro, ref Forth.Detail);

            }
            list_Jienng.Add(First);
            list_Jienng.Add(Second);
            list_Jienng.Add(Third);
            list_Jienng.Add(Forth);
        }

        private void FillJineng(string content, ref string image, ref string name, ref string kuaijie, ref string intro, ref string detail)
        {
            image = GetContent(content, "src");
            string name_part = htmlhelp.GetUniqTag(content, "div", "class=\"H_SkillName\"");

            string name_check = "<div class=\"H_SkillName\">";
            int name_begin = name_part.IndexOf(name_check) + name_check.Length;
            int name_end = name_part.IndexOf("<span");
            name = name_part.Substring(name_begin, name_end - name_begin);

            int begin = name_part.IndexOf("(") + 1;
            int end = name_part.IndexOf(")");
            kuaijie = name_part.Substring(begin, end - begin);

            string intro_part = htmlhelp.GetUniqTag(content, "div", "class=\"H_SkillIntro\"");
            string intro_check = "<div class=\"H_SkillIntro\">";
            intro = intro_part.Replace(intro_check, "").Replace("</div>", "");

            string detail_part = htmlhelp.GetUniqTag(content, "div", "class=\"H_SkillLevel\"");
            detail = detail_part.Replace("<div class=\"H_SkillLevel\">", "").Replace("</div>", "").Replace("<b>", "").Replace("</b>", "").Replace("<br/>", "\n");

        }



        private bool IsImageExist(string src)
        {
            return true;
        }
    }
    public class Jineng
    {
        public string Image = string.Empty;
        public string Name = "";
        public string Kuaijie = "";
        public string Intro = "";
        public string Detail = "";
    }

    class ItemsClass
    {
        HtmlHelp htmlhelp = new HtmlHelp();
        public string AvatarUri;
        public string Detail;
        public ItemsClass(string htmlStr)
        {
            string str = htmlhelp.GetUniqTag(htmlStr, "div", "Class=\"R1C1 wrapfix\"");
            List<string> contents = htmlhelp.GetImgTagFromHtml1(str);
            foreach (string s in contents)
            {

                AvatarUri = GetContent(s, "src");
                Regex regex = new Regex("[0-9]{2,6}");
                Match match = regex.Match(GetContent(s, "onmouseover"));
                if (match.Success)
                {
                    htmlhelp.DownloadPage("http://cms1.sgamer.com/Ajax/DisplayDOTAItem?callback=?&itemID=" + match.Value,callback); 
                }
               

            }
        }
        private void callback(string detail)
        {
            detail = detail.Substring(2, detail.Length - 3);
            Detail = detail;
        }
        public string GetContent(string source, string item)
        {
            int begin = item.Length;
            Regex regex = new Regex(item + "=\"[^\"]*" + "\"");
            Match match = regex.Match(source);

            if (match.Success)
            {
                return match.Value.Substring(begin + 2).Trim('"');
            }
            return string.Empty;
        }
    }
}
