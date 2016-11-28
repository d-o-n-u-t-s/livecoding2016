using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
    private float StartPositionY = -657f;

    [SerializeField] private NoteManager manager;
    [SerializeField] private SoundManager sound;
    [SerializeField] private Transform[] hitPositions; // 押す位置を参照する用

    public NoteData Data { get; private set; }

    public void SetData(NoteData data)
    {
        Data = data;
        gameObject.SetActive(true);
    }

    void Update()
    {
        var t = (Data.Time - sound.Time);

        // 位置を移動
        var rate = t / NoteManager.DisplayTime; // 出現した瞬間が1、ちょうど押すタイミングで0になる
        var targetPosition = hitPositions[Data.Position].position;
        transform.localPosition = new Vector3(
            targetPosition.x,
            Mathf.Lerp(targetPosition.y, StartPositionY, rate),
            0
        );

        if(t < -NoteManager.MissTime) {
            manager.Evaluate(this, false);
        }

        #if オートプレイ
        if(sound.Time > Data.Time) {
            sound.PlaySE();
            Destroy(gameObject);
        }
        #endif
    }
}
