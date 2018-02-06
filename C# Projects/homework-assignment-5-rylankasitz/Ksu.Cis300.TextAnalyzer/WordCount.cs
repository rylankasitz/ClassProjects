using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    class WordCount
    {
        string _word;
        int[] _count;

        /// <summary>
        /// Initializes words and count
        /// </summary>
        /// <param name="w">The string word</param>
        /// <param name="c">The array of couns</param>
        public WordCount(string w, int c)
        {
            _word = w;
            _count = new int[c];
        }

        /// <summary>
        /// Gets the _word variable
        /// </summary>
        public string Word
        {
            get 
            {
                return _word;
            }

        }

        /// <summary>
        /// Gets the _count variable
        /// </summary>
        public int[] NumberOfFiles
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Returns a specific file number after given a file number
        /// </summary>
        /// <param name="k">File number given</param>
        /// <returns>The file count at the file number</returns>
        public int this[int n]
        {
            get
            {
                if(n < _count.Length - 1)
                {
                    return _count[n];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Increments a given file number if it exists.
        /// </summary>
        /// <param name="fn">The file number given</param>
        public void Increment(int fn)
        {
            if(fn < _count.Length)
            {
                _count[fn]++;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }  
}
