using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : Result
{
    public GameObject collider;

    public override void Execute(params float[] parameters)
    {
        collider.SetActive(false);
        Destroy(this);
    }
}
