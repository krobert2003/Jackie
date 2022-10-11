using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jackie
{
    class Program
    {
        public static List<Versenyzo> adatok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            Beolvasas();
            F3MO();
            F4MO();
            F5MO();
            F6MO();
            Console.ReadLine();
        }
        private static void Beolvasas()
        {
            StreamReader Olvas = new StreamReader("jackie.txt", Encoding.UTF8);
            string fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                adatok.Add(new Versenyzo(Olvas.ReadLine()));
            }
        }
        private static void F3MO() => Console.WriteLine($"3. feladat: {adatok.Count}");
        private static void F4MO() => Console.WriteLine($"4. feladat: {adatok.OrderBy(x => x.Verseny).Last().Ev}");
        private static void F5MO()
        {
            Console.WriteLine("5. feladat:");
            Console.WriteLine($"\t70-es évek: {adatok.Where(x => x.Ev >= 1970 && x.Ev < 1980).Sum(y => y.Nyert)} megnyert verseny");
            Console.WriteLine($"\t60-es évek: {adatok.Where(x => x.Ev >= 1960 && x.Ev < 1970).Sum(y => y.Nyert)} megnyert verseny");
        }
        private static void F6MO()
        {
            try
            {
                List<Versenyzo> sorbarendezett = adatok.OrderByDescending(x => x.Ev).ToList();
                StreamWriter Iro = new StreamWriter("jackie.html", false, Encoding.UTF8);
                Iro.WriteLine("<!doctype html>");
                Iro.WriteLine("<html>");
                Iro.WriteLine("<head></head>");
                Iro.WriteLine("<style> td{ border:1px solid black;}</style>");
                Iro.WriteLine("<body>");
                Iro.WriteLine("<h1>Jackie Stewart</h1>");
                Iro.WriteLine("<table>");
                for (int i = 0; i < sorbarendezett.Count; i++)
                {
                    Iro.WriteLine($"<tr><td>{sorbarendezett[i].Ev}</td><td>{sorbarendezett[i].Verseny}</td><td>{sorbarendezett[i].Nyert}</td></tr>");
                }
                Iro.WriteLine("</table>");
                Iro.WriteLine("</body>");
                Iro.WriteLine("</html>");
                Iro.Close();
                Console.WriteLine("6. feladat: jackie.html");
            }
            catch (Exception)
            {
                Console.WriteLine("Nem sikerült a jackie.html létrehozása!");
            }
        }
    }
    class Versenyzo
    {
        public Versenyzo(string Sor)
        {
            string[] sorelemek = Sor.Split('\t');
            this.Ev = Convert.ToInt32(sorelemek[0]);
            this.Verseny = Convert.ToInt32(sorelemek[1]);
            this.Nyert = Convert.ToInt32(sorelemek[2]);
            this.Dobogos = Convert.ToInt32(sorelemek[3]);
            this.Elso_helyrol = Convert.ToInt32(sorelemek[4]);
            this.Leggyorsabb = Convert.ToInt32(sorelemek[5]);
        }
        public int Ev { get; set; }
        public int Verseny { get; set; }
        public int Nyert { get; set; }
        public int Dobogos { get; set; }
        public int Elso_helyrol { get; set; }
        public int Leggyorsabb { get; set; }
    }
}
