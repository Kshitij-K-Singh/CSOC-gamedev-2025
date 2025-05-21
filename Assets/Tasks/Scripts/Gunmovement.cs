using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunmovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mouseWorldPos;
    // Update is called once per frame
    void Update()
    {

        mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mouseWorldPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(rb.position.x, rb.position.y, angle);
    }
}
