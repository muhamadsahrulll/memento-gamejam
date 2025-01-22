using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SuaraManager : MonoBehaviour
{
    public bool storeBool = false;
    public bool isMusicMute = false;

    public UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        isMusicMute = MusicManager.instance.storeIsMusicMute;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        UIManager.ChangeButtonColor();
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
            //suara dialog akan di unmute
            UpdateBool(false);
            storeBool = false;
            UIManager.popUpNotif();
            UIManager.popUpImage.sprite = UIManager.popUpSprites[1]; //image untuk unmute
        }        
        else
        {
            //Suara dialog akan di mute
            UpdateBool(true);
            storeBool = true;
            UIManager.popUpNotif();
            UIManager.popUpImage.sprite = UIManager.popUpSprites[0]; //image untuk mute
        }


    }

    /*------------------------------*/
    public void StoreToMusik(bool state)
    {
        isMusicMute = state;
        MusicManager.instance.MusicOnOff(state); // Mengirim nilai ke MusicManager
        Debug.Log("Musik di SuaraManager diupdate: " + isMusicMute);
    }

    public void musik_OnOff()
    {
        
        if(isMusicMute == true)
        {
            //musik di unmute
            MusicManager.instance.musicScource.Play();
            isMusicMute = false;
            StoreToMusik(false);
            UIManager.ChangeButtonColor();
        }
        else
        {
            //musik di mute
            MusicManager.instance.musicScource.Pause();
            isMusicMute = true;
            StoreToMusik(true);
            UIManager.ChangeButtonColor();
        }
        
    }
}
