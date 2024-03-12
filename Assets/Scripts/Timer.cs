using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public int delay;
    private float timer;
    public bool period=false;
    
    [SerializeField] private TMP_Text timeText;
    

    private void Awake()
    {
        instance = this;
        timer = delay;
    }

    void Update()
    {
        if (timer > 0 )
        {
            timer -= Time.deltaTime;
            timeText.SetText("Time : " + (int)timer);
            period = false;
        }
        if (timer <= 0 && Finish.instance.isFinish == false)
        {
            timer = delay;
            period = true;
            StartCoroutine(PeriodCoroutine());
        }

        if (Finish.instance.isFinish == true)
        {
            timer = 0;
        }
    }

    private IEnumerator PeriodCoroutine()
    {
        yield return new WaitForSeconds(3);
    }
}
