namespace Lighting.Extension
{
    public class ContentVideoHelper
    {

        public static string? AssignVideo(string? strhtml){
            var linkList = new List<string>(); //เก็บลอ้ง
            foreach (var str in strhtml.Split("\"")) //แยกurl link ทั้งหมดออกมา
            {
                //Console.WriteLine(str);
                if (str.StartsWith("https://www.youtube.com/watch?v"))
                {
                    linkList.Add(str.Substring(0, str.IndexOf(';')));
                }
            }

            var Index = new List<IndexLink>(); //เก็บ index
            var startindex = 0;

            while (true) //หาtag เริ่มต้นทั้งหมด
            {
                startindex = strhtml.IndexOf("<figure class=\"media\">", startindex);
                if (startindex == -1) break;
                Index.Add(new IndexLink
                {
                    Start = startindex
                });
                //Console.WriteLine("st:" + startindex);
                startindex++;
            }

            for (int i = 0; i < Index.Count; i++) //หา tag สิ้นสุดทั้งหมด
            {
                var stop = strhtml.IndexOf("</figure>", Index[i].Start);
                //Console.WriteLine(stop);
                if (stop != -1)
                {
                    Index[i].Stop = stop - Index[i].Start;
                }
            }

            var html = strhtml;
            var indexLink = 0;
            foreach (var strIndex in Index)
            {
                var strOldText = strhtml.Substring(strIndex.Start, strIndex.Stop + 9);
                html = html.Replace(strOldText, $"<iframe width=\"auto\" height=\"auto\" src='{linkList[indexLink]}'></iframe>");
                indexLink++;
            }

            return html;
        }
    }

     class IndexLink
    {
        public int Start { get; set; }
        public int Stop { get; set; }
    }
}
