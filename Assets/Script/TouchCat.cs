using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCat : MonoBehaviour
{
    //bool isTouched = false;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TouchTheCat() {
        ani.enabled = !ani.enabled;
    }
}
