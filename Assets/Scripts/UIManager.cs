using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    public void PlayButton()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void XButton()
    {
        settingsPanel.SetActive(false);
    }
}
