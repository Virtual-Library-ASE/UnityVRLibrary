using System.Collections;
using System.Collections.Generic;
using Firebase.Firestore;

using UnityEngine.UI;
using TMPro;
using UnityEngine;

[FirestoreData]

public class NoticeBoardData 
{
    
    [FirestoreProperty]

    public string messageText1 { get; set; }
    // Start is called before the first frame update
    

    // void submitText () {
    //     Debug.Log(input_text.text);
    //     // show message
    //     if (input_text.text.Length > 0)
    //     {
    //         messages.Add(input_text.text);
    //         freshMessages();
    //     }

    // }

    // void freshMessages() {
    //     int start = 0;
    //     if (messages.Count > 25) {start = messages.Count-25;}
    //     string allMessage = "";
    //     for (int i=start; i<messages.Count; i++) {
    //         allMessage += " ";
    //         allMessage += messages[i];
    //         allMessage += "\r\n";
    //     }
    //     messageText.text = allMessage;
    //     input_text.text = "";
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}

public class NoticeBoard: MonoBehaviour
{
    [SerializeField] private string _messagePath = "notice-board/messages/";
    
    [SerializeField] public TMP_InputField input_text;
    [SerializeField] public Button Submit;
    [SerializeField] public TMP_Text messageText;
    [SerializeField] private List<string> messages = new List<string>();

    void Start()
    {
        Submit.onClick.AddListener(() =>{
            var noticeBoardData = new NoticeBoardData {
                messageText1 = input_text.text
            };

            var firestore = FirebaseFirestore.DefaultInstance;
            firestore.Document(_messagePath).SetAsync(noticeBoardData);
        });
        // freshMessages();
    }

}