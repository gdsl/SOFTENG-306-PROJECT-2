using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerCookieSync : NetworkBehaviour {

    void FixedUpdate()
    {
        TransmitCookie();
    }

    [Command]
    void CmdProvideCookieCountToServer(long count)
    {
        gameObject.GetComponent<PlayerInventory>().SetCookieCount(count);
    }

    [ClientCallback]
    void TransmitCookie()
    {
        if (isLocalPlayer)
        {
            CmdProvideCookieCountToServer(gameObject.GetComponent<PlayerInventory>().GetCookieCount());
        }
    }

}
