using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Finish : MonoBehaviour
{
    public static Finish instance;

    public int destroyedBall = 0;
    public int score = 0;
    public bool isFinish=false;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (destroyedBall==2)
        {
            isFinish = true;
        }
        if (isFinish)
        {
            finalPanel.SetActive(true);
            scoreText.SetText("Score : " + score);
        }
    }
}
