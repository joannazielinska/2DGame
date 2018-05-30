using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayMenu : MonoBehaviour {

    public GameObject delayMenuUI;


    public void StartDelayMenu()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0f;
        float delay = Time.realtimeSinceStartup + 10f;
        while(Time.realtimeSinceStartup < delay)
        {
            yield return 0;
        }

        delayMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }


}
