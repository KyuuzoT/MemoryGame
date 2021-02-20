using System;
using System.Collections.Generic;
using UnityBase.MemoryGame.CommonResources;
using UnityBase.MemoryGame.GameLogic.Figure;
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


        void Start()
        {
            GlobalVars.Similarities = new bool[similarities.Length];

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
            int index = Random.Range(0, figuresToMemorize.Count);
            currentFigure = Instantiate(figuresToMemorize[index]);
            currentFigure.position = figureSpawner.position;
            currentFigure.rotation = Quaternion.identity;
            rightVector = Vector3.right;

            SetInstanceParametrs();
        }

        private void SetInstanceParametrs()
        {
            curBehaviour = currentFigure.GetChild(0).gameObject.AddComponent<FigureBehaviour>();
            curBehaviour.form = curBehaviour.transform.name;
            curBehaviour.angle = SetAngleBasedOnForm(curBehaviour.form);

            curBehaviour.ColorizeObject(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }

        private float SetAngleBasedOnForm(string form)
        {
            if (form.Equals("Sphere"))
            {
                 return 0.0f;
            }
            else
            {
                if (form.Equals("Rect"))
                {
                    return Random.Range(0, 2) * (defaultAngle * 2);
                }
                else
                {
                    return Random.Range(0, 2) * defaultAngle;
                }
            }
        }
    }
}