using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAudioController : MonoBehaviour
{
    public AudioSource onHoverSFX;
    public AudioSource onClickSFX;

    public void OnHover()
    {
        onHoverSFX.Play();
    }

    public void OnClick()
    {
        onClickSFX.Play();
    }
}
