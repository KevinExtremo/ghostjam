using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public AudioClip clip;

    private float startTime;

    public virtual void performTrigger(GameObject gm) {
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
