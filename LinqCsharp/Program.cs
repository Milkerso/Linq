using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LinqCsharp
{
    class Program
    {
        private XDocument xdoc;

        Program()
        {
            this.xdoc= XDocument.Load(@"C:\\Users\\Dawid\\source\\Repozy\\LinqCsharp\\XMLFile1.xml");
        }
        public XDocument Xdoc { get => xdoc; set => xdoc = value; }

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Biblioteka");
                Console.WriteLine("1 Wyswietl wszystkie ksiazki");
                Console.WriteLine("2 Wyswietl ksiazke szukajac po autorze");
                Console.WriteLine("3 Wyswietl ksiazke szukajac po tytule");
                Console.WriteLine("4 Wyswietl ksiazke szukajac po latach podaj przedzial");
                Console.WriteLine("5 Wyswietl ksiazke szukajac po tytule i autorze");
                String choice = Console.ReadLine();
                int choiceInt = Int32.Parse(choice);

                Program program = new Program();
                switch (choiceInt)
                {
                    case 1:
                        program.displayAllBooks();
                        break;
                    case 2:
                        Console.WriteLine("Podaj Autora");
                        String authorName = Console.ReadLine();
                        program.displayByAuthor(authorName);
                        break;
                    case 3:
                        Console.WriteLine("Podaj Tytul");
                        String titleName = Console.ReadLine();
                        program.displayBytitle(titleName);
                        break;
                    case 4:
                        Console.WriteLine("Od roku");
                        int forYear = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Do roku");
                        int toYear= Int32.Parse(Console.ReadLine());
                        program.displayByYear(forYear,toYear);
                        break;
                    case 5:
                        Console.WriteLine("Podaj Autora");
                        authorName = Console.ReadLine();
                        Console.WriteLine("Podaj Tytul");
                        titleName = Console.ReadLine();
                        program.displayByAuthorAndTitle(authorName, titleName);
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

                Console.ReadLine();
            }
            }

        private void displayByAuthorAndTitle(string authorName, string titleName)
        {
            var title = from XElement ele in xdoc.Element("books").Elements("book")
                        where (string)ele.Element("Author") == authorName &&
                         (string)ele.Element("title") == titleName
                        select ele;

            title = title.OrderBy(item => item.Element("title").Value);
            if (title.Count() == 0)
            {
                Console.WriteLine("Pusta");
            }
            foreach (XElement top in title)
            {
                Console.WriteLine("Author: " + top.Element("Author").Value);
                Console.WriteLine("title: " + top.Element("title").Value);
                Console.WriteLine("Year: " + top.Element("Year").Value + "\n");
            }
        }

        public void displayByAuthor(String authorName)
        {

            var title = from XElement ele in xdoc.Element("books").Elements("book")
                           where (string)ele.Element("Author")==authorName
                        select ele;

            title = title.OrderBy(item => item.Element("title").Value);
            if (title.Count() == 0)
            {
                Console.WriteLine("Pusta");
            }
            foreach (XElement top in title)
            {
                Console.WriteLine("Author: " + top.Element("Author").Value);
                Console.WriteLine("title: " + top.Element("title").Value);
                Console.WriteLine("Year: " + top.Element("Year").Value + "\n");
            }


        }

        public void displayBytitle(String titleName)
        {

            var title = from XElement ele in xdoc.Element("books").Elements("book")
                        where (string)ele.Element("title") == titleName
                        select ele;

            title = title.OrderBy(item => item.Element("title").Value);
            if (title.Count() == 0)
            {
                Console.WriteLine("Pusta");
            }
            foreach (XElement top in title)
            {
                Console.WriteLine("Author: " + top.Element("Author").Value);
                Console.WriteLine("title: " + top.Element("title").Value);
                Console.WriteLine("Year: " + top.Element("Year").Value + "\n");
            }


        }
        public void displayByYear(int forauthorYear, int toauthorYear)
        {

            var title = from XElement ele in xdoc.Element("books").Elements("book")
                        where (int)ele.Element("Year") >forauthorYear&&
                        (int)ele.Element("Year") < toauthorYear
                        select ele;

            title = title.OrderBy(item => item.Element("Year").Value);
            if (title.Count() == 0)
            {
                Console.WriteLine("Pusta");
            }
            foreach (XElement top in title)
            {
                Console.WriteLine("Author: " + top.Element("Author").Value);
                Console.WriteLine("title: " + top.Element("title").Value);
                Console.WriteLine("Year: " + top.Element("Year").Value+"\n");
            }


        }
        public void displayAllBooks()
        {
          
            XDocument xdoc = XDocument.Load(@"C:\\Users\\Dawid\\source\\Repozy\\LinqCsharp\\XMLFile1.xml");



            var title = from XElement ele in xdoc.Element("books").Elements("book")
                        // where (string)ele.Attribute("id")=="1"
                        select ele;
            if(title.Count()==0)
            {
                Console.WriteLine("Pusta");
            }
             foreach(XElement top in title)
            {
                Console.WriteLine("Author: "+top.Element("Author").Value);
                Console.WriteLine("title: "+top.Element("title").Value);
                Console.WriteLine("Year: " + top.Element("Year").Value + "\n");
            }
            
          
        }
    }

}
