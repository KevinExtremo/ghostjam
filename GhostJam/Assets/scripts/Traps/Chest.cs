// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject spriteOpen, spriteClosed;
    
    [SerializeField]
    public bool isOpen{
        get {
            if (spriteOpen != null){
                return spriteOpen.activeSelf;
            } else {
                return false;
            }
        }
        set {
            if (spriteOpen) {spriteOpen.SetActive(value); }
            if (spriteClosed) {spriteClosed.SetActive(!value); }
            if (shine) {shine.gameObject.SetActive(value); }
        }
    }
    public Light shine;

    /*
    void Awake() {

    }
    */

    public void open(){
        this.isOpen = true;
    }

    public void close(){
        this.isOpen = false;
    }

    public void reset(){
        this.isOpen = false;
    }

}
