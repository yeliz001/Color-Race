using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject selectedBall;
    [SerializeField] private Vector3 firstPos;
    public BallColor color;

    private void Start()
    {
        firstPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedBall == null)
            {
                RaycastHit hit = RayCast();

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Ball") == false)
                    {
                        return;
                    }
                    selectedBall = hit.collider.gameObject;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedBall = null;
        }
        
        if (selectedBall != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedBall.transform.position).z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
            selectedBall.transform.position = new Vector3(worldPos.x, 2f, worldPos.z);
        }

        if (Timer.instance.period)
        {
            transform.position = firstPos;
        }
    }

    private RaycastHit RayCast()
    {
        RaycastHit hit;
        Vector3 mousePos=Input.mousePosition;

        Vector3 screenMousePosFar = new Vector3(mousePos.x, mousePos.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
