using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPassage : MonoBehaviour {

    void OnMouseDown()
    {
        GameManager.Instance.SendMessage("FapWindow");
    }
}
