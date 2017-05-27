using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateClick : Result
{
    public GameObject ClickGameObject;
    public override void Execute(params float[] parameters)
    {
        ClickGameObject.SetActive(true);
        Destroy(this);
    }
}
