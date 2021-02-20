using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBase.MemoryGame.GameLogic.Figure
{
    public class FigureBehaviour : MonoBehaviour
    {
        internal float angle;
        internal Color color;
        internal string form;

        private bool wasVisible;

        void Start()
        {
            wasVisible = false;
            transform.Rotate(Vector3.forward, angle);
        }

        void Update()
        {
        }

        internal void ColorizeObject(Color c)
        {
            this.color = c;
            gameObject.GetComponent<Renderer>().material.color = c;
        }

        private void OnBecameInvisible()
        {
            if (wasVisible)
            {
                Destroy(transform.parent.gameObject);
            }
        }

        private void OnBecameVisible()
        {
            wasVisible = true;
        }
    }

}