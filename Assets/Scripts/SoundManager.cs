using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioClip se;

    public float Time { get { return bgm.time; } }

    public void PlaySE()
    {
        bgm.PlayOneShot(se);
    }
}
