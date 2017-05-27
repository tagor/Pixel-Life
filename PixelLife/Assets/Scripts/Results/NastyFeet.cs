using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NastyFeet : Result
{
    public string narration_key;
    public string soundeffect_key;
    public Camera cam;
    public float nastyTime;
    public Act sexAct;


    private bool goNastyTime;
    private Animator camAnimator;
    private float nastyTimer;
    private Vector3 oldCamPos;
    public float oldCamFieldOfView;

    private float[] sexActParameters;

    void Awake()
    {
        camAnimator = cam.GetComponent<Animator>();
    }

    public override void Execute(params float [] parameters)
    {

        //Used for chain acting
        sexActParameters = parameters;

        //Booleans true
        goNastyTime = true;
        camAnimator.enabled = true;

        //Stores old variables
        oldCamPos = cam.transform.position;
        oldCamFieldOfView = cam.fieldOfView;

        //Sounds
        Narrator.Instance.narrate(narration_key);
        SoundEffector.Instance.play(soundeffect_key, 1.0f);
    }

    void Update()
    {
        if (goNastyTime)
        {
            nastyTimer += Time.deltaTime;
            if (nastyTimer >= nastyTime)
            {
                //Booleans false
                goNastyTime = false;
                camAnimator.enabled = false;
          
                //Returns old values
                cam.transform.position = oldCamPos;
                cam.fieldOfView = oldCamFieldOfView;

                //Resume Act
                sexAct.player.transform.position = new Vector2(sexActParameters[0], sexActParameters[1]);
                sexAct.camera.transform.position = new Vector3(sexActParameters[2], sexActParameters[3], sexActParameters[4]);
                sexAct.camera.fieldOfView = sexActParameters[5];
                sexAct.Run();
                Destroy(this);
            }
        }
    }
}
