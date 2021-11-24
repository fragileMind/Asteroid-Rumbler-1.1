using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 clickPosition = new Vector3();
    private UnityEngine.AI.NavMeshAgent nav;
    private static string NPC_tag;
    private Vector3 targetPostion;
    private bool isTargetNPC;
    private bool isLeftClick;
    private NPC targetNPC;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        NPC_tag = "NPC";
        isTargetNPC = false;
        targetPostion = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0)) // Left-click
        {
            TargetDetect(Camera.main.ScreenPointToRay(Input.mousePosition));
            isLeftClick = true;
        }
        if (Input.GetMouseButton(1)) // Right-click
        {
            isLeftClick = false;
        }
        // prepare interaction
        if (isTargetNPC && Vector3.Distance(transform.position, targetPostion) < 2.0f)
        {
            if (isLeftClick)
            {
                Game.DialougeLog.Add(targetNPC.NPCDialouge.DebugText());
                targetNPC.IsTalking = true;
            }
        }
    }

    void TargetDetect(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            clickPosition = hit.point;
            //text.text = clickPosition.ToString();
            Debug.Log(hit.transform.name);
            nav.SetDestination(clickPosition);
            if (hit.transform.tag.Equals(NPC_tag))
            {
                if(targetNPC != null)
                {
                    targetNPC.IsTalking = false;
                }
                targetNPC = hit.transform.GetComponent<NPC>();
                isTargetNPC = true;
                targetPostion = hit.transform.position;
            }
            else
            {
                isTargetNPC = false;
            }
        }
    }
}

