using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] buttons;
    public float offColor;

    public void Awake()
    {
        if(PlayerPrefs.GetString("Volume")=="")
        {
            PlayerPrefs.SetString("Volume", "ON");
            Color color = buttons[0].GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            buttons[0].GetComponent<UnityEngine.UI.Image>().color = color;
            color = buttons[1].GetComponent<UnityEngine.UI.Image>().color;
            color.a = offColor;
            buttons[1].GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if(PlayerPrefs.GetString("Volume") =="ON")
        {
            Color color = buttons[0].GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            buttons[0].GetComponent<UnityEngine.UI.Image>().color = color;
            color = buttons[1].GetComponent<UnityEngine.UI.Image>().color;
            color.a = offColor;
            buttons[1].GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if(PlayerPrefs.GetString("Volume") == "OFF")
        {
            Color color = buttons[1].GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            buttons[1].GetComponent<UnityEngine.UI.Image>().color = color;
            color = buttons[0].GetComponent<UnityEngine.UI.Image>().color;
            color.a = offColor;
            buttons[0].GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if(PlayerPrefs.GetString("Helper")=="")
        {
            PlayerPrefs.SetString("Helper", "ON");
            Color color = buttons[2].GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            buttons[2].GetComponent<UnityEngine.UI.Image>().color = color;
            color = buttons[3].GetComponent<UnityEngine.UI.Image>().color;
            color.a = offColor;
            buttons[3].GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if (PlayerPrefs.GetString("Helper") == "ON")
        {
            Color color = buttons[2].GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            buttons[2].GetComponent<UnityEngine.UI.Image>().color = color;
            color = buttons[3].GetComponent<UnityEngine.UI.Image>().color;
            color.a = offColor;
            buttons[3].GetComponent<UnityEngine.UI.Image>().color = color;
        }
        if (PlayerPrefs.GetString("Helper") == "OFF")
        {
            Color color = buttons[3].GetComponent<UnityEngine.UI.Image>().color;
            color.a = 1f;
            buttons[3].GetComponent<UnityEngine.UI.Image>().color = color;
            color = buttons[2].GetComponent<UnityEngine.UI.Image>().color;
            color.a = offColor;
            buttons[2].GetComponent<UnityEngine.UI.Image>().color = color;
        }
    }

    public void VolumeON()
    {
        Color color = buttons[0].GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        buttons[0].GetComponent<UnityEngine.UI.Image>().color = color;
        color = buttons[1].GetComponent<UnityEngine.UI.Image>().color;
        color.a = offColor;
        buttons[1].GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Volume", "ON");
    }
    public void VolumeOFF()
    {
        Color color = buttons[1].GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        buttons[1].GetComponent<UnityEngine.UI.Image>().color = color;
        color = buttons[0].GetComponent<UnityEngine.UI.Image>().color;
        color.a = offColor;
        buttons[0].GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Volume", "OFF");
    }

    public void HelperON()
    {
        Color color = buttons[2].GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        buttons[2].GetComponent<UnityEngine.UI.Image>().color = color;
        color = buttons[3].GetComponent<UnityEngine.UI.Image>().color;
        color.a = offColor;
        buttons[3].GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Helper", "ON");
    }
    public void HelperOFF()
    {
        Color color = buttons[3].GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        buttons[3].GetComponent<UnityEngine.UI.Image>().color = color;
        color = buttons[2].GetComponent<UnityEngine.UI.Image>().color;
        color.a = offColor;
        buttons[2].GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Helper", "OFF");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
