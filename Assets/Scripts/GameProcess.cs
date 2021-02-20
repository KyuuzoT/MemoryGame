using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityBase.MemoryGame.CommonResources;
using UnityEngine;
using Random = UnityEngine.Random;


namespace UnityBase.MemoryGame.GameLogic
{
    public class GameProcess : MonoBehaviour
    {
        [SerializeField] private Transform figureSpawner;
        [SerializeField] [Range(-15.0f, -0.1f)] private float speed = -5.0f;
        [SerializeField] private List<Transform> figuresToMemorize;
        private Transform currentFigure;
        private Transform prevFigure;

        private Vector3 rightVector;
        private int figuresCount;
        private FigureBehaviour curBehaviour;
        private FigureBehaviour prevBehaviour;

        private float defaultAngle = 45.0f;

        internal bool[] similarities = new bool[3];

        private UI.Handlers.ButtonClickHandler btnHandler;

        void Start()
        {
            GlobalVars.Similarities = new bool[similarities.Length];

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
            if (currentFigure.Equals(null))
            {
                prevBehaviour = curBehaviour;
                //prevFigure = currentFigure;
                FigureInstantiation();
                figuresCount++;
            }
            else
            {
                currentFigure.Translate(rightVector * speed);
            }

            if (figuresCount > 1)
            {
                if (curBehaviour.form.Equals(prevBehaviour.form))
                {
                    similarities[0] = true;
                }
                if (curBehaviour.color.Equals(prevBehaviour.color))
                {
                    similarities[1] = true;
                }
                if (curBehaviour.angle.Equals(prevBehaviour.angle))
                {
                    similarities[2] = true;
                }
            }

            Array.Copy(similarities, GlobalVars.Similarities, similarities.Length);
        }

        private void FigureInstantiation()
        {
            currentFigure = Instantiate(figuresToMemorize.First());
            currentFigure.position = figureSpawner.position;
            currentFigure.rotation = Quaternion.identity;
            rightVector = Vector3.right;

            curBehaviour = currentFigure.GetChild(0).gameObject.AddComponent<FigureBehaviour>();
            curBehaviour.form = curBehaviour.transform.name;

            if (curBehaviour.form.Equals("Sphere"))
            {
                curBehaviour.angle = 0;
            }
            else
            {
                curBehaviour.angle = Random.Range(0, 2) * defaultAngle;
            }

            curBehaviour.ColorizeObject(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }
    }
}