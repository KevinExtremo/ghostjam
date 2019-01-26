using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    public AudioClip clip;

    private float startTime;

    public virtual void performAction(GameObject gm) {
        if (this.clip != null) {
            AudioSource audio = gm.AddComponent<AudioSource>();
            audio.clip = this.clip;
            audio.Play();
        }
        this.startTime = Time.time;
    }

    public float getTime() {
        return startTime;
    }
}
