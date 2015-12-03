using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkereses
{
    class MatchCard
    {
        public List<string> marker = new List<string>();
        public List<string> matches = new List<string>();

        public MatchCard(string data) {
            marker.Add(data);
            marker.Add(reverse(data));
            for (int i = 0; i < data.Length; i++)
            {
                move(ref data);
                marker.Add(data);
                marker.Add(reverse(data));
            }
        }
        public void getMatches(ref List<string> list) {
            int i = 0;
            while (i < list.Count) {
                if (marker.Contains(list[i]))
                {
                    matches.Add(list[i]);
                    list.RemoveAt(i);
                }
                else {
                    i++;
                }
            }
        }
        private void move(ref string word) {
            char firstLetter = word.ToCharArray()[0];
            char[] chWord = word.ToCharArray();
            for (int i = 0; i < chWord.Length-1; i++)
            {
                chWord[i] = chWord[i + 1];
            }
            chWord[chWord.Length - 1] = firstLetter;
            word = new string(chWord);
        }
        private string reverse(string word) {
            char[] chWord = word.ToCharArray();
            int j = chWord.Length - 1;
            for (int i = 0; i < chWord.Length/2; i++)
            {
                char temp = chWord[i];
                chWord[i] = chWord[j];
                chWord[j] = temp;
                j--;
            }
            return new string(chWord);
        }
        
    }
}
