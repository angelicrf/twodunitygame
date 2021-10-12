using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector3 playerChange;
    //private CameraMovement cam; 
    public bool textNeeded;
    public string replaceText;
    public Text placeText;
    public GameObject newTextObj;
    //private Rigidbody2D mvRigid;
    private PlayerMouvment playerMouvement;
    public Vector3 dspMins;
    private Camera camera2;
    private Vector2 camPos;
    private int countPool = 0;


    void Start()
    {
        playerMouvement = GameObject.Find("Player").GetComponent<PlayerMouvment>();
    }

    void FixedUpdate()
    {
        ChangeStats();
    }
    private void ChangeStats()
    {

        camera2 = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (textNeeded)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                StartCoroutine(AreaChangeMSG());
            }
        }
    }
    private IEnumerator DisplayText()
    {
        camera2 = GameObject.Find("Main Camera").GetComponent<Camera>();
        camPos = camera2.transform.position;
        newTextObj.SetActive(true);
        if (camPos.x >= 6)
        {
            replaceText = "Pool Area";
            placeText.text = replaceText;

            if (countPool == 0)
            {
                yield return new WaitForSeconds(4f);
                newTextObj.SetActive(false);
                textNeeded = true;
            }
            else
            {
                textNeeded = true;
                yield return new WaitForSeconds(4f);
                newTextObj.SetActive(false);
            }

        }
        else
        {
            placeText.text = "Home Area";
            yield return new WaitForSeconds(4f);
            newTextObj.SetActive(false);
        }
    }
    private IEnumerator AreaChangeMSG()
    {

        newTextObj.SetActive(true);
        ChangeAllPos();
        ChooseOptions();
        yield return new WaitForSeconds(4f);
        newTextObj.SetActive(false);
    }
    private void ChooseOptions()
    {
        if (textNeeded)
        {
            placeText.text = replaceText;
            switch (replaceText)
            {
                case "Pool Area":
                    ChangeColor(255, 0, 0, 1);
                    break;
                case "Home Area":
                    ChangeColor(0, 0, 128, 1);
                    break;
                case "HomeStead":
                    ChangeColor(0, 255, 255, 1);
                    break;
                case "BackYard":
                    ChangeColor(128, 128, 128, 1);
                    break;
                default:
                    ChangeColor(255, 255, 0, 1);
                    break;
            }
        }

    }
    private void ChangeColor(byte a, byte b, byte c, byte d)
    {
        placeText.color = new Color(a, b, c, d);
    }
    private void ChangeAllPos()
    {
        camera2.transform.position = dspMins;
        playerMouvement.plRigid.transform.position = playerChange;
    }

}
