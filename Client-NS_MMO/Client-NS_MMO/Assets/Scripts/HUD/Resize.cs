using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resize : MonoBehaviour
{
    public GameObject window;
    private const int speed = 20;
    private const int minWidth = 260;
    private const int maxWidth = 1170;
    private const int minHeight = 250;
    private const int maxHeight = 600;
    private RectTransform rt;

    public void Start()
    {
        rt = window.GetComponent<RectTransform>();
    }
    public void resize()
    {
        float moveX = 0;
        if(Input.GetAxis("Mouse X") > 0 && rt.rect.width < maxWidth)
        {
            moveX = Input.GetAxis("Mouse X");
        }
        else if (Input.GetAxis("Mouse X") < 0 && rt.rect.width > minWidth)
        {
            moveX = Input.GetAxis("Mouse X");
        }

        float moveY = 0;
        if (Input.GetAxis("Mouse Y") < 0 && rt.rect.height < maxHeight)
        {
            moveY = -Input.GetAxis("Mouse Y");
        }
        else if (Input.GetAxis("Mouse Y") > 0 && rt.rect.height > minHeight)
        {
            moveY = -Input.GetAxis("Mouse Y");
        }

        rt.sizeDelta += new Vector2(moveX, moveY) * speed;

        if (rt.sizeDelta.x > maxWidth)
            rt.sizeDelta = new Vector2(maxWidth, rt.sizeDelta.y);
        else if (rt.sizeDelta.x < minWidth)
            rt.sizeDelta = new Vector2(minWidth, rt.sizeDelta.y);

        if (rt.sizeDelta.y > maxHeight)
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, maxHeight);
        else if (rt.sizeDelta.y < minHeight)
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, minHeight);


    }
}
