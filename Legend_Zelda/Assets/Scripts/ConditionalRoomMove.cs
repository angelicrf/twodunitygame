using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ConditionalRoomMove : MonoBehaviour
{
    public Vector3 playerChange;
    public bool textNeeded;
    public string replaceText;
    public Text placeText;
    public GameObject newTextObj;
    private PlayerMouvment playerMouvement;
    public Rigidbody2D mvRigid;
    public Signal roomChangeSignal;
    public Signal roomThreeSignal;
    private DungRoomThree dngThree;
    private DungDoor dngGeneral;
    private bool isInRoomThree = false;
    private bool isEnteredRThree = false;


    void Start()
    {
        playerMouvement = GameObject.Find("Player").GetComponent<PlayerMouvment>();
        mvRigid = playerMouvement.plRigid;
        dngThree = DungRoomThree.Instance();
        dngGeneral = DungDoor.Instance();
        if (dngThree.dungLogsSignal != null)
        {
            dngThree.dungLogsSignal.hasSignal = false;
            dngThree.getAllCounts = 0;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("attack"))
        {
            if (roomThreeSignal != null)
            {
                isInRoomThree = (roomThreeSignal.countSignals >= 3);
                if (isInRoomThree)
                {
                    Debug.Log("isInRoomThree " + isInRoomThree);
                    mvRigid.isKinematic = true;
                }

            }
        }
        isEnteredRThree = dngThree.isEntered;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (textNeeded)
        {
            StartCoroutine(LastStep());
        }
    }

    private void ExecSomeConds()
    {
        bool roomTwoApproval = dngGeneral.doorTwoSignal.hasSignal;
        bool roomOneApproval = dngGeneral.doorOneSignal.hasSignal;
        bool roomFourApproval = dngGeneral.doorFourSignal.hasSignal;

        if (roomOneApproval || roomTwoApproval || isInRoomThree || roomFourApproval)
        {
            PartTwoSteps();
        }
    }
    private void PartTwoSteps()
    {
        newTextObj.SetActive(true);
        ChangeAllPos();
        ChooseOptions();
    }
    private bool AreaChangeRooms()
    {
        bool hlSignal = false;
        roomChangeSignal.ReadSignals();
        roomChangeSignal.hasSignal = true;
        hlSignal = roomChangeSignal.hasSignal;
        return hlSignal;
    }
    private IEnumerator LastStep()
    {
        bool resultSignalConds = AreaChangeRooms();

        if (resultSignalConds)
        {
            ExecSomeConds();
            yield return new WaitForSeconds(2f);
            newTextObj.SetActive(false);
            roomChangeSignal.hasSignal = false;
            roomChangeSignal.countSignals = 0;

            if (roomThreeSignal != null)
            {
                roomThreeSignal.hasSignal = false;
                roomThreeSignal.countSignals = 0;
            }
        }

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
        playerMouvement.plRigid.transform.position = playerChange;
        if (!isEnteredRThree)
        {
            playerMouvement.plRigid.isKinematic = true;
        }
        else
        {
            playerMouvement.plRigid.isKinematic = false;
        }
    }
}
