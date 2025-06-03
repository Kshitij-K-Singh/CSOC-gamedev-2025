using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunmovement : MonoBehaviour
{
    public float horizontal;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mouseWorldPos;
    private bool isFacingRight = true;
    // Update is called once per frame
    void Update()
    {
        Flip();
        horizontal = Input.GetAxisRaw("Horizontal");

        mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mouseWorldPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1f;
            transform.localScale = theScale;
        }
    }
}
