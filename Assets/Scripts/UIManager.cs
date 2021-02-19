using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityBase.MemoryGame.UI
{
    public class UIManager : MonoBehaviour
    {
        private Transform currentLayout;
        private Handlers.ButtonClickHandler btnHandler;
        [SerializeField] TMPro.TextMeshProUGUI wrongAnswer;
        [SerializeField] TMPro.TextMeshProUGUI rightAnswer;


        // Start is called before the first frame update
        void Start()
        {
            btnHandler = new Handlers.ButtonClickHandler();
        }

        // Update is called once per frame
        void Update()
        {
            SetButtonsBehaviour(GetButtons(currentLayout));
        }

        private List<Button> GetButtons(Transform currentLayout)
        {
            List<Button> btns = new List<Button>();
            btns.AddRange(currentLayout.GetComponentsInChildren<Button>());

            return btns;
        }

        private void SetButtonsBehaviour(List<Button> buttons)
        {
            List<Button> btns = new List<Button>(buttons);

            foreach (var item in btns)
            {
                item.onClick.RemoveAllListeners();

                item.onClick
                    .AddListener(
                                    delegate 
                                    {
                                        btnHandler.ButtonClicked(item.name);
                                    });
            }
        }
    }

}
