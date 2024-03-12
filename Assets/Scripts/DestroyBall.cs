using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    public static DestroyBall instance;

    public BallColor ballColor;
    public BallColor planeColor;

    [SerializeField] private GameObject ball;
    public int score=0;

    private void Awake()
    {
        instance = this;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ball = collision.gameObject;
            ballColor = collision.gameObject.GetComponent<DragAndDrop>().color;

            //print(string.Format("{0} {1}", ballMaterial.GetInstanceID(), planeMaterial.GetInstanceID()));

            if (ballColor != planeColor /*&& Timer.instance.period*/)
            {
                Destroy(ball);
                Finish.instance.destroyedBall++;
            }
            else
            {
                Finish.instance.score++;
            }
        }
    }

    public void ChangeColor(int index)
    {
        //color = colors[index];
        
        planeColor = (BallColor)index;
    }

}
