using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGround : MonoBehaviour
{
    public static RandomGround instance;

    [SerializeField] private Renderer ground1;
    [SerializeField] private Renderer ground2;
    [SerializeField] private Renderer ground3;
    [SerializeField] private Renderer ground4;

    [SerializeField] private Material[] colors;

    private int index;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Timer.instance.period)
        {
            index = UnityEngine.Random.Range(0, colors.Length);

            ground1.material = colors[index];
            ground2.material = colors[(index + 1) % colors.Length];
            ground3.material = colors[(index + 2) % colors.Length];
            ground4.material = colors[(index + 3) % colors.Length];
            
            ground1.transform.GetComponent<DestroyBall>().planeColor = (BallColor)(index % colors.Length);
            ground2.transform.GetComponent<DestroyBall>().planeColor = (BallColor)((index+1) % colors.Length);
            ground3.transform.GetComponent<DestroyBall>().planeColor = (BallColor)((index+2) % colors.Length);
            ground4.transform.GetComponent<DestroyBall>().planeColor = (BallColor)((index+3) % colors.Length);
        }
    }
    
}
