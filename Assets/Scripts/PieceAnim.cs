using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceAnim : MonoBehaviour
{
    Rigidbody2D rb;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        float x = Player.directionX;
        int xForceNegative = Random.Range(-1, -150);
        int xForcePositive = Random.Range(1, 150);
        if (x < -0.5f)
        {
            //Debug.Log("d��ar� sol");
            rb.AddForce(new Vector2(xForceNegative, -50f));
        }
        else if (x < 0 && x > -0.5f)
        {
            //Debug.Log("i�eri sol");
            rb.AddForce(new Vector2(xForcePositive, -50f));
        }
        else if (x > 0 && x < 0.5f)
        {
            //Debug.Log("i�eri sa�");
            rb.AddForce(new Vector2(-xForceNegative, -50f));
        }
        else if(x > 0.5f)
        {
            //Debug.Log("d��ar� sa�");
            rb.AddForce(new Vector2(xForcePositive, -50f));
        }
    }

}
