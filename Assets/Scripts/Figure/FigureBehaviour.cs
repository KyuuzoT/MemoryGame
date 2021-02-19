using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBehaviour : MonoBehaviour
{
    internal float angle;
    internal Color color;
    internal string form;
    internal bool isDestroyed 
    { 
        get
        {
            return destroyed;
        }
    }

    private bool destroyed;
    private bool wasVisible;


    // Start is called before the first frame update
    void Start()
    {
        wasVisible = false;
        transform.Rotate(Vector3.forward, angle);
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void ColorizeObject(Color c)
    {
        this.color = c;
        gameObject.GetComponent<Material>().color = c;
    }

    private void OnBecameInvisible()
    {
        if(wasVisible)
        {
            destroyed = true;
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnBecameVisible()
    {
        wasVisible = true;
    }
}
