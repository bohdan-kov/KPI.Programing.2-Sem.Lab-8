using Labs_8_2_;
using System;

namespace Labs_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = "Gaza war: US bomb delay biggest warning yet for Israel";
            string content = "The United States is the one country that has real leverage over Israel. And yet, throughout the war in Gaza, Israel has chosen to ignore much of the advice of its closest ally.\r\n\r\nThe US government says its support for the war against Hamas is \"ironclad\", but it has repeatedly raised concerns about the failure of the Israeli army to protect civilians and the lack of humanitarian access afforded to the people of Gaza.";
            string category = "Politic";
            string author = "James Landale";

            var id1 = Guid.NewGuid();

            string title2 = "Russia ramps up attacks";
            string content2 = "People in several regions of Ukraine have been experiencing power blackouts after the latest wave of Russian attacks on the country's energy infrastructure.\r\n\r\nPresident Volodymyr Zelensky said there had been missile and drone attacks on critical energy facilities in seven regions.";
            string category2 = "War";
            string author2 = "Olga Robinson";

            var id2 = Guid.NewGuid();


            string pressa = "BBC";


            var articleElect = new ArticleElectronicEdition(title, content, category, author, id1);

            var articleElect2 = new ArticleElectronicEdition(title2, content2, category2, author2, id2);


            Console.WriteLine(articleElect.ViewArticle());
            articleElect.addTag("Gaza");
            articleElect.addTag("War");
            articleElect.ViewArticle();
            articleElect.ViewArticle();
            articleElect.addTag("Israel");

            articleElect.ViewArticle();

            articleElect.ViewArticle();
            Console.WriteLine(articleElect.ViewArticle());


            var articleElect3 = articleElect + articleElect2;

            Console.WriteLine(articleElect3.ViewArticle());

            articleElect3.ToArchive();

            Console.WriteLine(articleElect3.ViewArticle());


            //var articleNewsPaper1 = new ArticleNewspaper(title, content, category, author, pressa);
            //Console.WriteLine(articleNewsPaper1.ReadArticle());

            //articleNewsPaper1.ChangeSubscription(11.99, 3);


            //Console.WriteLine(articleNewsPaper1.SeeCost());
        }
    }
}
