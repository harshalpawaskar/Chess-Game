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
        if(PlayerPrefs.GetString("Volume")=="")//When launcing the game for the first Time
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
        if(PlayerPrefs.GetString("Helper")=="")//When launcing the game for the first Time
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

    //Turns ON the Volume.Called onClick()
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

    //Turns OFF the Volume.Called onClick()
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

    //Turns ON the Helper.Called onClick()
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

    //Turns OFF the Helper.Called onClick()
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

    //Go to the main game
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    //Close the Game
    public void Quit()
    {
        Application.Quit();
    }
}
