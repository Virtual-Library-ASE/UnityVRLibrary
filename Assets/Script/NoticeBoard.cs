using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBoard : MonoBehaviour
{
    //public InputField input_text;

    // Start is called before the first frame update
    void Start()
    {
        //input_text.onValueChanged.AddListener(Input_OnChanged);
        //input_text.onEndEdit.AddListener(Input_End);
    }

    void Input_OnChanged (string context) {

    }

    void Input_End () {
        // Debug.Log(input_text.text);
        // // length limitation
        // if (match_input.text.Length > 100)
        // {
        //     match_input.text = match_input.text.Substring(0, 100);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
