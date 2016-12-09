using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CustomNetworkManager : NetworkManager {

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject proxyPlayer = (GameObject)Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        NetworkServer.AddPlayerForConnection(conn, proxyPlayer, playerControllerId);
    }
}
