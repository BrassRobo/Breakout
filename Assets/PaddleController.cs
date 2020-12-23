using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        var newX = Mathf.Clamp(mousePosition.x, (screenBounds.x * -1) + objectWidth, screenBounds.x - objectWidth);
        transform.position = new Vector3(newX, transform.position.y);
    }
}
