// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Chest : TrapController
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

    
    void Awake() {
        Reset();
    }
    

    public void Open(){
        this.isOpen = true;
    }

    public void Close(){
        this.isOpen = false;
    }

    public override void Reset(){
        this.isOpen = false;
    }

}
