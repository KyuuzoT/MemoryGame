using System.Collections;
using System.Collections.Generic;
using UnityBase.MemoryGame.CommonResources;
using UnityEngine;

namespace UnityBase.MemoryGame.UI.Handlers
{
    public class ButtonClickHandler
    {
        internal bool[] similarities;
        internal static int similaritiesCount { get; set; } = 0;

        internal void ButtonClicked(string btnName)
        {
            foreach (var item in GlobalVars.Similarities)
            {
                Debug.Log($"Similarities: {item}");
                if(item)
                {
                    similaritiesCount++;
                }
            }

            Debug.Log($"Count: {similaritiesCount}");
            switch (btnName)
            {
                case "Yes":
                    if (similaritiesCount >= 3)
                    {
                        GlobalVars.RIGHT_ANSWERS++;
                    }
                    else
                    {
                        GlobalVars.WRONG_ANSWERS++;
                    }
                    break;
                case "Similar":
                    if (similaritiesCount >= 1 && similaritiesCount < 3)
                    {
                        GlobalVars.RIGHT_ANSWERS++;
                    }
                    else if (similaritiesCount >= 3)
                    {
                        GlobalVars.WRONG_ANSWERS++;
                    }
                    else if (similaritiesCount < 1)
                    {
                        GlobalVars.WRONG_ANSWERS++;
                    }
                    break;
                case "No":
                    if (similaritiesCount == 0)
                    {
                        GlobalVars.RIGHT_ANSWERS++;
                    }
                    else
                    {
                        GlobalVars.WRONG_ANSWERS++;
                    }
                    break;
                default:
                    break;
            }

            similaritiesCount = 0;
        }
    }
}
