using System;

namespace AnagramTask
{
    public class Anagram
    {
        private readonly string toAnagram;
        private readonly string sourceWord;

        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            if (sourceWord is null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException("source word is empty.", nameof(sourceWord));
            }

            this.sourceWord = sourceWord;
            char[] ch = sourceWord.ToUpperInvariant().ToCharArray();
            Array.Sort(ch);
            this.toAnagram = new string(ch);
        }

        public string GetAnagram()
        {
            return this.toAnagram;
        }

        public string GetSourceWord()
        {
            return this.sourceWord;
        }

        public string GetSourceWordToUpperInvariant()
        {
            return this.sourceWord.ToUpperInvariant();
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            string[] findAnagrams = Array.Empty<string>();
            Anagram anagram = new Anagram(this.sourceWord);
            for (int i = 0; i < candidates.Length; i++)
            {
                Anagram candidate = new Anagram(candidates[i]);
                if (anagram.GetAnagram() == candidate.GetAnagram() && anagram.GetSourceWordToUpperInvariant() != candidate.GetSourceWordToUpperInvariant())
                {
                    Array.Resize(ref findAnagrams, findAnagrams.Length + 1);
                    findAnagrams[^1] = candidate.GetSourceWord();
                }
            }

            return findAnagrams;
        }
    }
}
