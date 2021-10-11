using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEvents : MonoBehaviour
{
    public Text muteText;

    private void Start()
    {
        if (GameManager.mute)
            muteText.text = "/";
        else
            muteText.text = "";
    }

    public void ToggleMute()
    {
        if(GameManager.mute)
        {
            GameManager.mute = false;
            muteText.text = "";
        } 
        else
        {
            GameManager.mute = true;
            muteText.text = "/";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited!!");
    }
}
