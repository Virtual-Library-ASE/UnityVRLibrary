using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
    private string _room = "test";
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        // RoomOptions roomOptions = new RoomOptions();
        // PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Joined Lobby"); ;
        RoomOptions roomOptions = new RoomOptions();
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("instantiate");
        PhotonNetwork.Instantiate("networkPlayer", Vector3.zero, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
