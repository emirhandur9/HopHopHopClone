using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private SpriteRenderer spriteUp;
    private SpriteRenderer spriteBelow;

    public float timer;

    public bool startAlpha;

    private GameObject dead;
    private GameObject pass;


    private void Start()
    {
        SetRingPosition();
        spriteUp = transform.GetChild(0).GetChild(0).transform.GetComponent<SpriteRenderer>();
        spriteBelow = transform.GetChild(0).GetChild(1).transform.GetComponent<SpriteRenderer>();
        dead = transform.GetChild(1).gameObject;
        pass = transform.GetChild(2).gameObject;
        timer = 1;
    }
    private void Update()
    {
        if (startAlpha)
        {
            ChangeTheAlpha();
            dead.SetActive(false);
            pass.SetActive(false);
        }
        
    }

    public void ChangeTheAlpha()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            spriteUp.color = new Color(1, 1, 1, timer);
            spriteBelow.color = new Color(1, 1, 1,timer);
            //Debug.Log("timer is workin");
        }
        else
        {
            //Debug.Log("destroy");
            startAlpha = false;
            Destroy(gameObject);
        }
        
    }

    private void SetRingPosition()
    {
        //int i = Random.Range(-2, 2);
        float i = Random.Range(-2f, 2f);
        transform.position = new Vector3(transform.position.x, i, transform.position.z);
    }

}
