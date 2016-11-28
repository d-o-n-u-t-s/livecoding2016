using UnityEngine;
using System.Collections;

public class Otaku : MonoBehaviour {

    [SerializeField] private Animation animation;

    private Vector2 initPosition;

	void Awake () {
        initPosition = new Vector2(transform.position.x, transform.position.y);
	}

    public void SetAnimation(int count) {
        if(count == 0) {
            stop();
        } else if(count == 10){
            play();
        }
    }

    private void play() {
        animation.Play();
    }

    private void stop() {
        animation.Stop();
        transform.position = initPosition;
        transform.localScale = Vector3.one;
    }
}
