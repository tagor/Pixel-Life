using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    FirstRoom,
    EnteredLivingRoom,
    LivingRoom,
    TasksDone,
    NastyFeet,
    MollyRestOfConvo,
    BeforeFapWindow,
    FapWindow
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text Message;
    public bool inDialog;
    public string[] Messages;
    public AudioClip[] audioClips;
    public int limit_EnteredLivingRoom = 3;
    public int nasty_feet = 6;
    public int beforeFapWindow = 12;
    public int messageIndex = 0;

    private bool mouseButtonWasDown;
    private Vector3 oldCamPos;
    private float nastyFeetLerpTimer;
    public float nastfeetLerpTime;
    public float nastyFeetZoom;
    private bool camChanged = false;
    private GameState gameState = GameState.FirstRoom;
    private AudioSource audio;

    void Awake()
    {
        ApplySingleton();
        audio = GetComponent<AudioSource>();
    }

    void ApplySingleton()
    {
        //Singleton 
        if (Instance == null)
            Instance = this;
        if (this != Instance)
        {
            Debug.Log("This was not null (Singleton)");
            //Destroy(gameObject);
        }
    }

    public void SendMessage(string message)
    {
        if (message == "LivingRoom")
        {
            Invoke("EntersLivingRoom", 0.5f);
        }
        else if (message == "DoneTasks")
        {
            Invoke("TasksDone", 0.5f);
        }
        else if (message == "FapWindow")
        {
            Invoke("FapWindow", 0.5f);
        }
    }

    void EntersLivingRoom()
    {
        if (gameState == GameState.FirstRoom)
        {
            gameState = GameState.EnteredLivingRoom;
            inDialog = true;

            Message.text = Messages[messageIndex];
            audio.clip = audioClips[messageIndex];
            audio.Play();
            messageIndex++;

        }
    }

    void TasksDone()
    {
        if (gameState == GameState.LivingRoom)
        {
            gameState = GameState.TasksDone;
            GameObject.FindWithTag("Player").transform.position = new Vector3(0.93f, -2.51f, 0f);
            inDialog = true;
            audio.clip = audioClips[messageIndex];
            audio.Play();
            Message.text = Messages[messageIndex];
            messageIndex++;

        }
    }

    void FapWindow()
    {
        if (gameState == GameState.BeforeFapWindow)
        {
            gameState = GameState.FapWindow;
            GameObject.FindWithTag("Player").transform.position = new Vector3(2.15f, -0.51f, 0f);
            inDialog = true;
            audio.clip = audioClips[messageIndex];
            audio.Play();
            Message.text = Messages[messageIndex];
        }
    }

    void Update()
    {
        if (audio.isPlaying)
        {
            return;
        }
        if (gameState == GameState.EnteredLivingRoom)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseButtonWasDown = true;
            }

            if (mouseButtonWasDown && Input.GetMouseButtonUp(0))
            {
                audio.clip = audioClips[messageIndex];
                audio.Play();
                Message.text = Messages[messageIndex];
                messageIndex++;

                if (messageIndex >= limit_EnteredLivingRoom)
                {
                    mouseButtonWasDown = false;
                    Message.text = "";
                    inDialog = false;
                    gameState = GameState.LivingRoom;
                }
            }
        }


        else if (gameState == GameState.TasksDone)
        {
            if (Input.GetMouseButtonDown(0))
            {
                {
                    mouseButtonWasDown = true;
                }
            }

            if (mouseButtonWasDown && Input.GetMouseButtonUp(0))
            {
                audio.clip = audioClips[messageIndex];
                audio.Play();
                Message.text = Messages[messageIndex];
                messageIndex++;

                if (messageIndex >= nasty_feet)
                {
                    mouseButtonWasDown = false;
                    gameState = GameState.NastyFeet; ;
                }
            }
        }

        else if (gameState == GameState.NastyFeet)
        {
            if (!camChanged)
            {
                oldCamPos = Camera.main.transform.position;
                Camera.main.transform.position += new Vector3(0.16f, -3.1f, -15.03f);
                camChanged = true;
            }

            //Zoom
            nastyFeetLerpTimer += Time.deltaTime / nastfeetLerpTime;
            float camZoom = Mathf.Lerp(-15.03f, -15.03f + nastyFeetZoom, nastyFeetLerpTimer);
            Vector3 curCamPos = Camera.main.transform.position;
            curCamPos.z = camZoom;
            Camera.main.transform.position = curCamPos;

            if (nastyFeetLerpTimer >= nastfeetLerpTime)
            {
                Camera.main.transform.position = oldCamPos;
                gameState = GameState.MollyRestOfConvo;
            }
        }

        else if (gameState == GameState.MollyRestOfConvo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                {
                    mouseButtonWasDown = true;
                }
            }

            if (mouseButtonWasDown && Input.GetMouseButtonUp(0))
            {
                audio.clip = audioClips[messageIndex];
                audio.Play();
                Message.text = Messages[messageIndex];
                messageIndex++;

                if (messageIndex >= beforeFapWindow)
                {
                    Message.text = "";
                    inDialog = false;
                    mouseButtonWasDown = false;
                    gameState = GameState.BeforeFapWindow;
                }
            }
        }
    }

    void StopAudios()
    {
        audio.Stop();
    }
}

