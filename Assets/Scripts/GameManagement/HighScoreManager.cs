using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RSGPlatformer.Game.Management
{
    /// <summary>
    /// A class to handle loading and saving high scores.
    /// </summary>
    /// <remarks>
    public class HighScoreManager
    {
        // high scores are stored from highest (first) to lowest (last)
        private LinkedList<int> highScores { get; }
        private bool scoresChanged;
        private int numScores;
        private string fileLocation;

        public HighScoreManager(string fileLocation, int numScores)
        {
            if (fileLocation == null || fileLocation == "")
                throw new System.ArgumentNullException(fileLocation, "parameter should not be null or empty!");
            if (numScores <= 0)
                throw new System.ArgumentOutOfRangeException("numScores", "numScores should not be 0 or below!");

            this.fileLocation = fileLocation;
            this.numScores = numScores;

            highScores = new LinkedList<int>();
        }

        public void LoadHighScores()
        {
            StreamReader streamReader = new StreamReader(fileLocation);
            for (int i = 0; i < numScores; i++)
            {
                string line = streamReader.ReadLine();
                int parsedScore = 0;
                bool success = int.TryParse(line, out parsedScore);

                if (success)
                {
                    highScores.AddLast(parsedScore);
                }
            }
            streamReader.Close();
        }

        public void WriteHighScores()
        {
            if (scoresChanged)
            {
                StreamWriter streamWriter = new StreamWriter(fileLocation);
                foreach (int score in highScores)
                {
                    streamWriter.WriteLine(score);
                }
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Attempts to enter a provided score into the list.
        /// Returns whether score was entered or not.
        /// </summary>
        public bool EnterHighScore(int newScore)
        {
            LinkedListNode<int> currentNode = highScores.First;
            while (currentNode != null)
            {
                if (newScore > currentNode.Value)
                {
                    highScores.AddBefore(currentNode, newScore);
                    highScores.RemoveLast();
                    if (!scoresChanged) scoresChanged = true;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public List<int> GetHighScores()
        {
            return highScores.ToList();
        }

    }
}