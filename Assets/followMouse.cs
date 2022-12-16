
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class followMouse : MonoBehaviour
{


    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {

        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {


        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);


    }
}

