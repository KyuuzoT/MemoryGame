using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;


namespace UnityBase.MemoryGame.GameLogic
{
    public class GameProcess : MonoBehaviour
    {
        [SerializeField] private Transform figureSpawner;
        [SerializeField][Range(-15.0f, -0.1f)] private float speed = -5.0f;
        [SerializeField] private List<Transform> figuresToMemorize;
        private Transform currentFigure;
        private Transform prevFigure;

        private Vector3 rightVector;
        private int figuresCount;
        private FigureBehaviour curBehaviour;
        private FigureBehaviour prevBehaviour;

        internal bool[] similarities = new bool[3];

        private UI.Handlers.ButtonClickHandler btnHandler;

        void Start()
        {
            btnHandler = new UI.Handlers.ButtonClickHandler();
            for (int i = 0; i < similarities.Length; i++)
            {
                similarities[i] = false;
            }

            FigureInstantiation();
            figuresCount++;
        }

        void Update()
        {
            if(currentFigure.GetComponent<FigureBehaviour>().isDestroyed)
            {
                prevBehaviour = curBehaviour;
                prevFigure = currentFigure;
                FigureInstantiation();
                figuresCount++;
            }

            if(figuresCount > 1)
            {
                if (curBehaviour.form.Equals(prevBehaviour.form))
                {
                    similarities[0] = true;
                }
                if(curBehaviour.color.Equals(prevBehaviour.color))
                {
                    similarities[1] = true;
                }
                if (curBehaviour.angle.Equals(prevBehaviour.angle))
                {
                    similarities[2] = true;
                }
            }

            btnHandler.similarities = this.similarities;
        }

        private void FigureInstantiation()
        {
            currentFigure = Instantiate(figuresToMemorize.First());
            currentFigure.position = figureSpawner.position;
            currentFigure.rotation = Quaternion.identity;
            rightVector = Vector3.right;

            curBehaviour = currentFigure.GetChild(0).gameObject.AddComponent<FigureBehaviour>();
            curBehaviour.angle = 45;
            curBehaviour.ColorizeObject(Color.red);
            curBehaviour.form = curBehaviour.transform.name;
        }
    }
}