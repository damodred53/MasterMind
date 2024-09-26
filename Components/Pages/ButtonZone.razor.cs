using Microsoft.AspNetCore.Components;
using System;

namespace MasterMind.Components.Pages
{
    public partial class ButtonZone
    {
        
        const int numberOfColorToGuess = 5;


        /// <summary>
        /// Liste pour stocker les couleurs jouées précédemment
        /// </summary>
        
        private readonly List<int> previousColors = new();

        public List<int> GenerateRandomNumber(List<int> goodNumbers)
        {
            if (goodNumbers.Count == 0)
            {
                Random random = new(); 

                for (int i = 0; i < numberOfColorToGuess; i++)
                {
                    int randomNumber = random.Next(0, 4);
                    goodNumbers.Add(randomNumber);
                }
            } 
            return goodNumbers;
        }

        /// <summary>
        /// Fonction permettant d'indiquer si une couleur proposée par le joueur est à la bonne place
        /// </summary>
        /// <param name="pickedColor"></param>
        /// <returns></returns>
        public int ColorComparator(List<int> pickedColor)
        {
            int allFoundNumbers = 0;
            
            for (int i = 0; i < pickedColor.Count; i++)
            {
                if (pickedColor[i] == goodNumbers[i])
                {
                    allFoundNumbers++;
                } 
            }

            return allFoundNumbers;
        }

        /// <summary>
        /// Fonction permettant d'indiquer si une couleur proposée par le joueur est présent dans la liste
        /// mais à pas à la bonne place
        /// </summary>
        /// <param name="pickedColor"></param>
        /// <returns></returns>
        public int ContainedColorComparator(List<int> pickedColor)
        {
            int allContainedNumbers = 0;

             List<int> goodNumbersCopy = new List<int>(goodNumbers);

            for (int i = 0; i < pickedColor.Count; i++)
            {
                // Vérifier si la couleur est dans goodNumbers et pas déjà comptée
                if (pickedColor[i] != goodNumbers[i] && goodNumbersCopy.Contains(pickedColor[i]))
                {
                    allContainedNumbers++;
                    // Supprimer la couleur de la copie pour pas la compter plusieurs fois
                    goodNumbersCopy.Remove(pickedColor[i]);
                }
            }

            return allContainedNumbers;
        }

        public bool IsAllNumberFound(int number)
        {
            if (number == 5)
            {
                return true;
            }
            return false;
        }


        public void SavePreviousColors(List<int> pickedColor)
        {
            previousAttemps.Add(new List<int>(pickedColor));
        }
    }
}
