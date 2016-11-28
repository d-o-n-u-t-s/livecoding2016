using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NoteManager : MonoBehaviour
{
    public const int BPM = 137;
    public const float BeatTime = 60f / BPM / 4f;
    public const float DisplayTime = 1;
    public const float StartTime = 4.411f;
    public const float MissTime = 0.1f;

    public const int PositionMax = 4;

    [SerializeField] private ComboManager combo;
    [SerializeField] private SoundManager sound;
    [SerializeField] private TextAsset data;
    [SerializeField] private Note noteBase;
    [SerializeField] private KeyCode[] keys;
    [SerializeField] private Animation[] animations;

    private Queue<NoteData> noteDatas = new Queue<NoteData>();
    private List<Note> notes = new List<Note>();

    void Start()
    {
        // 譜面読み込み
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
        // 譜面生成
        if(noteDatas.Count != 0 && noteDatas.Peek().Time - DisplayTime < sound.Time) {
            var note = Instantiate(noteBase);
            var data = noteDatas.Dequeue();
            note.transform.SetParent(transform);
            note.SetData(data);
            notes.Add(note);
        }

        // 判定
        for(int i = 0; i < PositionMax; i++) {
            if(Input.GetKeyDown(keys[i])) {
                var note = notes.FirstOrDefault(n => n.Data.Position == i);
                if(note == null) {
                    continue;
                }

                if(Mathf.Abs(note.Data.Time - sound.Time) < MissTime) {
                    // パーフェクトの処理
                    Evaluate(note, true);
                }
            }
        }
    }

    public void Evaluate(Note note, bool isPerfect)
    {
        if(isPerfect) {
            sound.PlaySE();
            combo.AddScore();
            animations[note.Data.Position].Play();
        } else {
            combo.Reset();
        }

        notes.Remove(note);
        Destroy(note.gameObject);
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