using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteManager : MonoBehaviour
{
    public const int BPM = 137;
    public const float BeatTime = 60f / BPM / 4f;
    public const float DisplayTime = 1;
    public const float StartTime = 4.411f;

    public const int PositionMax = 4;

    [SerializeField] private SoundManager sound;
    [SerializeField] private TextAsset data;
    [SerializeField] private Note noteBase;

    private Queue<NoteData> noteDatas = new Queue<NoteData>();

    void Start()
    {
        float time = StartTime;
        foreach(var s in data.text.Split(',')) {
            foreach(var c in s) {
                var pos = c - '0';
                if(pos >= 0 && pos < PositionMax) {
                    noteDatas.Enqueue(new NoteData(pos, time));
                }
            }
            time += BeatTime;
        }
    }

    void Update()
    {
        if(noteDatas.Count != 0 && noteDatas.Peek().Time - DisplayTime < sound.Time) {
            var note = Instantiate(noteBase);
            var data = noteDatas.Dequeue();
            note.transform.SetParent(transform);
            note.SetData(data);
        }
    }
}

public class NoteData
{
    public int Position { get; private set; }
    public float Time { get; private set; }

    public NoteData(int pos, float time)
    {
        Position = pos;
        Time = time;
    }
}