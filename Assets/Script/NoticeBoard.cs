using System.Collections;
using System.Collections.Generic;
using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

[FirestoreData]

public class NoticeBoardData 
{
    [FirestoreProperty]
    public string userMessage { get; set; }
}

public class NoticeBoard: MonoBehaviour
{
    [SerializeField] public TMP_InputField input_text;
    [SerializeField] public Button Submit;
    [SerializeField] public TMP_Text messageText;
    [SerializeField] private List<string> messages = new List<string>();

   void readMessages() {
        FirebaseFirestore.DefaultInstance.Collection("notice-board").GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
        QuerySnapshot allMessagesQuerySnapshot = task.Result;
        foreach (DocumentSnapshot documentSnapshot in allMessagesQuerySnapshot.Documents)
        {
   
            Dictionary<string, object> firebaseMessage = documentSnapshot.ToDictionary();
            foreach (KeyValuePair<string, object> pair in firebaseMessage)
            {
                input_text.text = $"{pair.Value}";
                messages.Add($"{pair.Value}");
            }

   
  }
        upDateMessages();

        });
    }
    void Start()
    {
       readMessages();

       Submit.onClick.AddListener( () =>{
            var noticeBoardData = new NoticeBoardData { userMessage = input_text.text};
            var firestore = FirebaseFirestore.DefaultInstance;
            firestore.Collection("notice-board").AddAsync(noticeBoardData).ContinueWithOnMainThread(task => {
                   DocumentReference addedDocRef = task.Result;
            });
            messages.Add(input_text.text);
            upDateMessages();
        } );
    }

    void upDateMessages() {
        int start = 0;
        if (messages.Count > 25) {start = messages.Count-25;}
        string allMessage = "";
        for (int i=start; i<messages.Count; i++) {
            allMessage += " ";
            allMessage += messages[i];
            allMessage += "\r\n";
        }
        messageText.text = allMessage;
        input_text.text = "";
    }
}