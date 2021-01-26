using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{//ボタンの効果音

    [SerializeField]
    private AudioSource sound = null;
    [SerializeField]
    private AudioClip se = null;
    // Update is called once per frame
    public void Click()
    {
        sound.Stop();
        sound.clip = se;
        sound.Play();
    }
}
