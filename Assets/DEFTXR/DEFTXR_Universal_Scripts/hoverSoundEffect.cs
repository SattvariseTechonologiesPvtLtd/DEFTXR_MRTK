using UnityEngine;
using System.Collections;

public class hoverSoundEffect : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverTickSound;

    // Use this for initialization
    void Start()
    {

    }

    public void OnHoverFx()
    {
        myFx.PlayOneShot(hoverTickSound);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
