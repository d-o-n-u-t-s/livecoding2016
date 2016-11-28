using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
    [SerializeField] private SoundManager sound;

    public NoteData Data { get; private set; }

    public void SetData(NoteData data)
    {
        Data = data;
    }

    void Update()
    {
        if(sound.Time > Data.Time) {
            sound.PlaySE();
            Destroy(gameObject);
        }
    }
}
