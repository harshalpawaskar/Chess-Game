using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject volumeOn;
    public GameObject volumeOff;
    public AudioSource moveAudio;
    public GameController1 controller;
    public GameObject helperOnButton, helperOffButton;

    public void Awake()//Setting the Volume and Helper based on the PlayerPrefs values stored.
    {
        if(PlayerPrefs.GetString("Volume") == "ON")
        {
            volumeOn.SetActive(true);
            moveAudio.volume = 1f;
        }
        if(PlayerPrefs.GetString("Volume") == "OFF")
        {
            volumeOff.SetActive(true);
            moveAudio.volume = 0f;
        }
        if(PlayerPrefs.GetString("Helper") == "ON")
        {
            Color color = helperOnButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            helperOnButton.GetComponent<UnityEngine.UI.Image>().color = color;
            color = helperOffButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 0.4f;
            helperOffButton.GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if (PlayerPrefs.GetString("Helper") == "OFF")
        {
            Color color = helperOffButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            helperOffButton.GetComponent<UnityEngine.UI.Image>().color = color;
            color = helperOnButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 0.4f;
            helperOnButton.GetComponent<UnityEngine.UI.Image>().color = color;
        }
    }

    //Go back to main menu.Called onClick()
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //Restart the current game level.Called onClick()
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    //Turn ON and OFF the Volume.Called onClick()
    public void Volume()
    {
        if(PlayerPrefs.GetString("Volume")=="ON")
        {
            PlayerPrefs.SetString("Volume", "OFF");
            moveAudio.volume = 0f;
        }
        else if (PlayerPrefs.GetString("Volume") == "OFF")
        {
            PlayerPrefs.SetString("Volume", "ON");
            moveAudio.volume = 1f;
        }
    }

    //Turns ON the Helper.Called onClick()
    public void TurnOnHelper()
    {
        Color color = helperOnButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        helperOnButton.GetComponent<UnityEngine.UI.Image>().color = color;
        color = helperOffButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 0.4f;
        helperOffButton.GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Helper", "ON");
        controller.helper = true;
        foreach (string i in controller.activatedPlanesNames)
        {
            GameObject.Find(i).GetComponent<MeshRenderer>().enabled = true;
        }
    }

    //Turns OFF the Helper.Called onClick()
    public void TurnOffHelper()
    {
        Color color = helperOffButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        helperOffButton.GetComponent<UnityEngine.UI.Image>().color = color;
        color = helperOnButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 0.4f;
        helperOnButton.GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Helper", "OFF");
        controller.helper = false;
        color = new Color(0.137f, 0.737f, 1f, 1f);
        foreach (string i in controller.activatedPlanesNames)
        {
            if (GameObject.Find(i).GetComponent<MeshRenderer>().material.color != color)
                GameObject.Find(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    //Sets the controller.selected to false.Called onClick()
    public void DeactivateSelected()
    {
        controller.selected = false;
    }

    //Stops the Time.Called onClick()
    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    //Resumes the Time.Called onClick()
    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
