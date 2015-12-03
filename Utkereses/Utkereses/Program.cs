using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkereses
{
    class Program
    {
        static List<string> dataList = new List<string>();
        static List<MatchCard> cardList = new List<MatchCard>();

        static void Main(string[] args)
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string path = Path.GetFullPath(home + "\\Desktop\\ut.BE");
            string[] input;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    input = sr.ReadToEnd().Split(' ');
                    for (int i = 0; i < input.Length; i++)
                    {
                        dataList.Add(input[i]);
                    }
                    start();
                    sr.Close();
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            
            
        }
        static void start() {
            while (dataList.Count != 0)
            {
                MatchCard tempCard = new MatchCard(dataList[0]);
                tempCard.getMatches(ref dataList);
                cardList.Add(tempCard);
            }
            int imax = MaxKiv();
            for (int i = 0; i < cardList[imax].matches.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Előfordulási száma: "+cardList[imax].matches.Count+"\n\nA szó:");
                    Console.WriteLine(cardList[imax].matches[i]);
                    Console.WriteLine("\nVáltozatai:");
                }
                Console.Write(cardList[imax].matches[i]);
                if (i != cardList[imax].matches.Count - 1) {
                    Console.Write(", ");
                }
            }
            Console.Write("\n\n");
        }
        static int MaxKiv() {
            int imax = 0;
            for (int i = 0; i < cardList.Count; i++)
            {
                if(cardList[i].matches.Count> cardList[imax].matches.Count) {
                    imax = i;
                }
            }
            return imax;
        }
    }
}
