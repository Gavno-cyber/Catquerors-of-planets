using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource effectBtn;
    public AudioClip clickFx;

    public void ClickButton()
    {
        effectBtn.PlayOneShot(clickFx);
    }
}
