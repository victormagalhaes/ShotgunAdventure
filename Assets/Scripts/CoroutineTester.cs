using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTester : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        // proper way to call a coroutine
        // StartCoroutine(PrintOnDelay());
        Invoke("StartSlowMo", 5);
    }

    void StartSlowMo()
    {
        StartCoroutine(SlowMo());
    }

    IEnumerator SlowMo()
    {
        // 20% slow mo
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }

    IEnumerator PrintOnDelay()
    {
        print("Start: " + Time.time);

        // keyword. you're expecting a enumerator but im returning null. wait for the next frame then i'll return a enumerator
        yield return null;
        print("After 1 frame: " + Time.time);

        // after 3 seconds
        yield return new WaitForSeconds(3);
        print("End:" + Time.time);
    }
}
