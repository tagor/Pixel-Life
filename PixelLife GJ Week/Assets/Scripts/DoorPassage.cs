using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPassage : MonoBehaviour
{

    public Vector3 EnterPos;
    public Vector3 ExitPos;
    public string message;
    private bool OnExitPos;

    void OnMouseDown()
    {
        GameObject player = GameObject.FindWithTag("Player");  
        if (!OnExitPos)
        {
            player.transform.position = ExitPos;
            OnExitPos = true;

            GameManager.Instance.SendMessage(message);
        }
        else if (OnExitPos)
        {
            player.transform.position = EnterPos;
            OnExitPos = false;
        }
    }
}
