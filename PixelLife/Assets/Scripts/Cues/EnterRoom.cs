using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class EnterRoom : Switch
{
    public string narration_key;

    public override void Activate()
    {
        Destroy(this);
        Narrator.Instance.narrate(narration_key);
    }
}
