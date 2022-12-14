using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    static Audio Instance;
    AudioSource audioSource;
    bool muted = false;



/*    [SerializeField] Image img;
    [SerializeField] Sprite spriteMuted;
    [SerializeField] Sprite sprite;*/
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            muted = !muted;
        }
        if (muted)
        {
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = true;
        }
    }

    
}
