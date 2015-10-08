using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerMovementSync : NetworkBehaviour {

    [SyncVar] //server automatically apply to all client
    private Vector3 pos;

    [SerializeField]Transform myTransform;
    [SerializeField]float lerpRate = 15;

    void FixedUpdate()
    {
        TransmitPosition();
        LerpPosition();
    }

    void LerpPosition()
    {
        if (!isLocalPlayer)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, pos,Time.deltaTime*lerpRate);
        }
    }

    [Command]
    void CmdProvidePositionToServer(Vector3 pos)
    {
        this.pos = pos;
    }

    [ClientCallback]
    void TransmitPosition()
    {
        if (isLocalPlayer)
        {
            CmdProvidePositionToServer(myTransform.position);

        }
    }
}
