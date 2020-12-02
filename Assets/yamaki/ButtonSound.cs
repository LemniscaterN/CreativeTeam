using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{//ボタンの効果音

    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void Click()
    {
        sound.PlayOneShot(sound.clip);
    }
}
