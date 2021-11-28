using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    public GameObject platform;
    public GameObject startingPlatform;
    public GameObject currentPlatform;

    public static int platformCounter;
    public static int playerScore;

    [SerializeField] private Text score;
    [SerializeField] private GameObject tapToStart;
    [SerializeField] public  GameObject deadPanel;


    private void Awake()
    {
        Time.timeScale = 0;
        playerScore = 0;
        platformCounter = 0;
        deadPanel.SetActive(false);
    }


    private void Start()
    {
        currentPlatform = Instantiate(startingPlatform, transform.position, Quaternion.identity);
        platformCounter++;
        
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 1;
            tapToStart.SetActive(false);
        }



        PlatformCheck();

        score.text = playerScore.ToString();
    }


    #region Platform Functions
    private void PlatformCheck()
    {
        if (platformCounter < 3)
        {
            SpawnPlatform(currentPlatform.transform.GetChild(0).transform.position);
        }
    }
    private void SpawnPlatform(Vector3 pos)
    {
        currentPlatform = Instantiate(platform, pos, Quaternion.identity);
        platformCounter++;
        
    }
    #endregion
}
