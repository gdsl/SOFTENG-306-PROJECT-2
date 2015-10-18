using UnityEngine;
using System.Collections;

public class ExitMultiplayerHook : MonoBehaviour {

    public delegate void CanvasHook();

    public CanvasHook OnStopHook;

    public void UIStop()
    {
        GameObject.Find("SilentNightGame").GetComponent<SilentNightMutilplayerGame>().ExitGame();
        if (OnStopHook != null)
            OnStopHook.Invoke();
    }
}
