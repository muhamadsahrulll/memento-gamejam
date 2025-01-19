using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Sprite[] UIKalah;
    [SerializeField] public Sprite[] popUpSprites;
    public bool isRestarted = false;

    public MusicManager MusicManager;
    public Button buttonRestart;

    public Image anak_GameOver;
    public Image popUpImage;

    public Animation pop_up;



    // Start is called before the first frame update
    void Start()
    {
        MusicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isRestart()
    {
        if (buttonRestart == true)
        {
            isRestarted = true;

            if (isRestarted)
            {
                MusicManager.vo_kalah_menang.Stop();
            }
        }
    }

    public void popUpNotif()
    {
        pop_up.PlayQueued("pop_up");
        /*        StartCoroutine(WaitForAnimationToEnd("AnimationName", () =>
                {
                    // Kode ini akan dijalankan setelah animasi selesai
                    Debug.Log("Animasi selesai! Eksekusi kode berikutnya.");
                }));
                popUpGameObject.SetActive(false);
                popUp.SetBool("isClicked", false);*/
    }

/*    private IEnumerator WaitForAnimationToEnd(string pop_up, System.Action callback)
    {
        // Mendapatkan informasi tentang animasi
        AnimatorStateInfo stateInfo = popUp.GetCurrentAnimatorStateInfo(0);

        // Memainkan animasi
        popUp.SetBool("isClicked", true);

        // Menunggu hingga animasi selesai
        while (stateInfo.IsName(pop_up) && stateInfo.normalizedTime < 1f)
        {
            stateInfo = popUp.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        // Callback setelah animasi selesai
        callback?.Invoke();
    }*/
}
