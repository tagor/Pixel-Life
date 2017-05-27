using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Switch : MonoBehaviour
{
    public string scene;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Activate();
    }

    public virtual void Activate()
    {

        SceneManager.LoadScene(scene);
    }
}
