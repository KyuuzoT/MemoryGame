using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GamingTime : MonoBehaviour
{
    private Stopwatch watch;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;

    private void OnEnable()
    {
        watch = new Stopwatch();
        watch.Start();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        watch.Stop();
        timeText.text = $"{watch.Elapsed:hh\\:mm\\:ss}";
        watch.Start();
    }
}
