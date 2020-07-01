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
    public GameObject onButton, OffButton;
    //public GameObject[] UIPanels;

    public void Awake()
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
            Color color = onButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            onButton.GetComponent<UnityEngine.UI.Image>().color = color;
            color = OffButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 0.4f;
            OffButton.GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if (PlayerPrefs.GetString("Helper") == "OFF")
        {
            Color color = OffButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            OffButton.GetComponent<UnityEngine.UI.Image>().color = color;
            color = onButton.GetComponent<UnityEngine.UI.Image>().color;
            color.a = 0.4f;
            onButton.GetComponent<UnityEngine.UI.Image>().color = color;
        }
    }

    public void Update()
    {
        //foreach (GameObject i in UIPanels)
        //{
        //    if (i.activeSelf)
        //    {
      //          controller.touchEnabled = false;
      //          break;
      //      }
      //  }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

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

    public void TurnOnHelper()
    {
        Color color = onButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        onButton.GetComponent<UnityEngine.UI.Image>().color = color;
        color = OffButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 0.4f;
        OffButton.GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Helper", "ON");
        controller.helper = true;
        foreach (string i in controller.activatedPlanesNames)
        {
            GameObject.Find(i).GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void TurnOffHelper()
    {
        Color color = OffButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        OffButton.GetComponent<UnityEngine.UI.Image>().color = color;
        color = onButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 0.4f;
        onButton.GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Helper", "OFF");
        controller.helper = false;
        color = new Color(0.137f, 0.737f, 1f, 1f);
        foreach (string i in controller.activatedPlanesNames)
        {
            if (GameObject.Find(i).GetComponent<MeshRenderer>().material.color != color)
                GameObject.Find(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void DeactivateSelected()
    {
        controller.selected = false;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
