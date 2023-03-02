using UnityEngine;
using Photon.Pun;


public class Launcher : MonoBehaviour
{
    #region Private Serializable Fields
    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private GameObject progressLabel;
    #endregion

    #region Private Fields

    /// &lt;summary&gt;
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// &lt;/summary&gt;
    string gameVersion = "1";

    #endregion

    #region MonoBehaviour CallBacks

    /// &lt;summary&gt;
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// &lt;/summary&gt;
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    /// &lt;summary&gt;
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// &lt;/summary&gt;
    void Start()
    {
        // Connect();
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    #endregion


    #region Public Methods

    /// &lt;summary&gt;
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// &lt;/summary&gt;
    public void Connect()
    {
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion

}


