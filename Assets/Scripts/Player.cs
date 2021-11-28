using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float  downRadius;
    [SerializeField] private Transform down;
    [SerializeField] private LayerMask layerMask;
    

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip clip;

    [SerializeField] private GameObject[] piecesArray = new GameObject[4];
    private GameObject pieces;

    public bool startTimer;
    public float timer;
    public bool isPlayerLive;

    public static float directionX;

    public GameManagment gm;
    private void Awake()
    {
        ColumnOpening.columnNumber = 0;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManagment>();
        audioSource.enabled = false;
        int randomPieces = Random.Range(0, 4);
        pieces = piecesArray[randomPieces];
        pieces = Instantiate(pieces, this.transform.position, Quaternion.identity);
        pieces.transform.SetParent(this.gameObject.transform);
        pieces.SetActive(false);
        isPlayerLive = true;
    }
    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && isPlayerLive)
        {

            rb.velocity = new Vector2(0, speed);
        }

        if(rb.velocity.y < 0)
        {
            rb.gravityScale = 3;
        }
        else
        {
            rb.gravityScale = 2;
        }

        if (Down())
        {
            if(timer > .5f && isPlayerLive)
            {
                GameManagment.playerScore++;
                timer = 0f;
                startTimer = true;
                
            }
            
        }

        if (startTimer)
        {
            timer += Time.deltaTime;
        }


        if (!isPlayerLive)
        {
            gm.deadPanel.SetActive(true);
            //audioSource.enabled = true; sesin düzeltilmesi gerek
            //Camera.main.GetComponent<Animator>().SetTrigger("Shake");
            PlatformMoving.speed = 0;
            pieces.SetActive(true);
            transform.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine("StartLevel");
        }

    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("InGameScene");
    }

    public bool Down()
    {
        return Physics2D.OverlapCircle(down.position, downRadius, layerMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(top.position, topRadius);
        Gizmos.DrawWireSphere(down.position, downRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("RingDead"))
        {
            directionX = transform.position.x - collision.transform.position.x;
            isPlayerLive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("RingPass"))
        {
            collision.gameObject.GetComponentInParent<Ring>().startAlpha = true;
            Debug.Log(collision.transform.name);
        }
    }
}
