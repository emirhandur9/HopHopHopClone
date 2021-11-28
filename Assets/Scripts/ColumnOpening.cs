using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnOpening : MonoBehaviour
{
    public static int columnNumber;
    [SerializeField] private float speed;
    
    private void Start()
    {
        columnNumber++;
        this.gameObject.name = columnNumber.ToString();
    }

    void Update()
    {
        if (GameManagment.playerScore == int.Parse(this.gameObject.name))
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.transform.GetChild(0).transform.Translate(0, speed * Time.deltaTime, 0);
            gameObject.transform.GetChild(1).transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
