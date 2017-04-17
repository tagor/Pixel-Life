using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPassage : MonoBehaviour {


    void OnMouseDown()
    {
       GameManager.Instance.SendMessage("DoneTasks");
    }
}
