using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkPlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    // Start is called before the first frame update
    public GameObject avatar;
    public Transform playerGlobal;
    public Transform playerLocal;


    private PhotonView _photonview;
    void Start()
    {
        Debug.Log("I am ok");
        _photonview = GetComponent<PhotonView>();
        if (_photonview.IsMine)
        {
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");

            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;
            
            // avatar.SetActive(false);
        }
        
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if (stream.IsWriting){
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.localPosition);
            stream.SendNext(playerLocal.localRotation);
        }
        else {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            Debug.Log(avatar.transform.localPosition);
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
