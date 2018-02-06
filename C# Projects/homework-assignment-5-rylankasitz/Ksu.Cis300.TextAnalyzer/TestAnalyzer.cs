using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.Sort;
using System.Text.RegularExpressions;

namespace Ksu.Cis300.TextAnalyzer
{
    static class TestAnalyzer
    {
        /// <summary>
        /// Adds words to the dictionary and returns amount of words added
        /// </summary>
        /// <param name="fileName">File being added</param>
        /// <param name="fileNums">The file number</param>
        /// <param name="dic">Dictionary being added to</param>
        /// <returns>The amount of words added</returns>
        public static int ProcessFile(string fileName, int fileNums, Dictionary<string, WordCount> dic)
        {
            int count = 0;
            using (StreamReader input = new StreamReader(fileName))
            {
                while (!input.EndOfStream)
                {
                    string pattern = "[^abcdefghijklmnopqrstuvwxyz]+";
                    string[] words = Regex.Split(input.ReadLine().ToLower(), pattern);

                    for(int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != "")
                        {
                            WordCount wc;
                            if (dic.TryGetValue(words[i], out wc))
                            {
                                wc.Increment(fileNums);
                            }
                            else
                            {
                                dic.Add(words[i], new WordCount(words[i], 2));
                                dic.TryGetValue(words[i], out wc);
                                wc.Increment(fileNums);
                            }
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Gets a set number of words with the highest frequencies
        /// </summary>
        /// <param name="dic">Dictionary of words</param>
        /// <param name="wInFile">The array of file numbers</param>
        /// <param name="wordsToGet">Amount of words to get</param>
        /// <returns></returns>
        public static MinPriorityQueue<float, WordFrequency> GetMostCommonWords(Dictionary<string, WordCount> dic, int[] wInFile, int wordsToGet)
        {
            MinPriorityQueue<float, WordFrequency> queue = new MinPriorityQueue<float, WordFrequency>();
            foreach (KeyValuePair<string, WordCount> value in dic)
            {
                WordFrequency wf = new WordFrequency(value.Value, wInFile);
                float comf = 0;
                comf += wf[0];
                comf += wf[1];
                queue.Add(comf, wf);
                if(queue.Count > wordsToGet)
                {
                    queue.RemoveMinimumPriority();
                }
            }
            return queue;
        }

        /// <summary>
        /// Gets the word frequency difference
        /// </summary>
        /// <param name="queue">The queue of word frequencies</param>
        /// <returns>The diffence of word frequncies</returns>
        public static float GetDifference(MinPriorityQueue<float, WordFrequency> queue)
        {
            double difSum = 0;
            while (queue.Count > 0) {
                WordFrequency wf = queue.RemoveMinimumPriority();
                float freq1 = wf[0];
                float freq2 = wf[1];
                difSum += (freq1 - freq2) * (freq1 - freq2);
            }
            return (float) (100 *  Math.Sqrt(difSum));
        }
    } 
}
