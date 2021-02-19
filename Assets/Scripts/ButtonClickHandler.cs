using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBase.MemoryGame.UI.Handlers
{
    public class ButtonClickHandler
    {
        private int similaritiesCount = 0;
        internal bool[] similarities;
        internal void ButtonClicked(string btnName)
        {
            foreach (var item in similarities)
            {
                if (item)
                {
                    similaritiesCount++;
                }
            }
            switch (btnName)
            {
                case "Yes":
                    if (similaritiesCount >= 3)
                    {
                        ///
                    }
                    break;
                case "Similar":
                    if (similaritiesCount >= 1 && similaritiesCount < 3)
                    {
                        ///
                    }
                    break;
                case "No":
                    if (similaritiesCount == 0)
                    {
                        ///
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
