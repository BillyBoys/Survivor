using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(2,2);

    public Vector2 direction = new Vector2(-1,0);

    public bool isLinkedCamera = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if(isLinkedCamera)
        {
            Camera.main.transform.Translate(movement);
        }
    }
}
