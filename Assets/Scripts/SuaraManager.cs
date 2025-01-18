using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuaraManager : MonoBehaviour
{
    public bool storeBool = false;
    public Button musikOn;
    public Button musikOff;
    // Start is called before the first frame update
    void Start()
    {
        musikOn.onClick.AddListener(musik_On);
        musikOff.onClick.AddListener(musik_Off);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBool(bool value)
    {
        storeBool = value;
        MusicManager.instance.VideoMute(value); // Mengirim nilai ke MusicManager
        Debug.Log("Bool di SuaraManager diupdate: " + storeBool);
    }

    public void StoreMute()
    {
        if (storeBool == true)
        {
            UpdateBool(false);
            storeBool = false;
        }        
        else
        {
            UpdateBool(true);
            storeBool = true;
        }


    }

    /*------------------------------*/
    public void musik_On()
    {
        musikOn.interactable = false;
        MusicManager.instance.musicScource.Pause();
    }

    public void musik_Off()
    {
        musikOff.interactable = false;
        MusicManager.instance.musicScource.Play();
    }

}
