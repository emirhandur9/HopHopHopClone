using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public static float speed;

    private void Start()
    {
        speed = 1;
    }
    private void Update()
    {
        Move();

        if(transform.position.x < -15f)
        {
            GameManagment.platformCounter--;
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
