using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WindowsBarBehaviour : MonoBehaviour
{

    public Sprite displayLogo;
    public string displayTitle;

    public Image anchoredWindowLogo;
    public Text anchoredWindowTitle;
    public GameObject anchoredWindowContent;

    public GameObject windowRoot;

    public int speed = 20;

    void Start()
    {
        anchoredWindowTitle.text = displayTitle;
        anchoredWindowLogo.sprite = displayLogo;
    }


    public void btnCloseWindow()
    {
        gameObject.SetActive(false);
        anchoredWindowContent.SetActive(false);
    }

    public void moveWindow()
    {
        //windowRoot.transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * speed;
        Vector3 mousePos = Input.mousePosition;
        //Vector3 windowPos = windowRoot.transform.position;
        windowRoot.transform.position = mousePos;
        //float deltaX = Input.mousePosition.x - windowRoot.transform.position.x;
        //float deltaY = Input.mousePosition.y - windowRoot.transform.position.y;
        //windowRoot.transform.position = new Vector3(deltaX, deltaY, 0);

        //Debug.Log(windowRoot.transform.position.ToString());
    }

}
