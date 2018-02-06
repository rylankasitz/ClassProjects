using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    class WordFrequency
    {
        private string _word;
        private float[] _frequencies;

        /// <summary>
        /// initializes the word and frequencies
        /// </summary>
        /// <param name="o">Word object</param>
        /// <param name="wc">Array of file counts</param>
        public WordFrequency(WordCount o, int[] wc)
        {
            _word = o.Word;
            _frequencies = new float[wc.Length];
            if(o.NumberOfFiles.Length != wc.Length)
            {
                throw new ArgumentException();
            }
            for(int i = 0; i < _frequencies.Length; i++)
            {
                _frequencies[i] = (float) o.NumberOfFiles[i] / wc[i];
            }
        }

        /// <summary>
        /// Gets the private _word variable
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }

        /// <summary>
        /// Gets the frequecy of a give file number 
        /// </summary>
        /// <param name="n">File Number</param>
        /// <returns>Frequency coresponding to a file number</returns>
        public float this[int n]
        {
            get
            {
                if (n < _frequencies.Length)
                {
                    return _frequencies[n];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
