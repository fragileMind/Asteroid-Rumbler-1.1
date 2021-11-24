using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private static GameObject player;
    private static GameObject dialogueUI;
    private static GameObject uiPanel;
    private static Text dialogueText;
    private static List<string> dialougeLog;
    private System.Text.StringBuilder logText;
    private static Dictionary<string, List<string>> dialougeChoice;
    private static Dictionary<string, Attr> attrDict = new Dictionary<string, Attr>
    {
        { "Affinity", Attr.Affinity },
        { "Bravery", Attr.Bravery },
        { "Sensibility", Attr.Sensibility },
        { "Morality", Attr.Morality },
    };

    public static GameObject Player { get => player; }
    public static GameObject DialogueUI { get => dialogueUI; }
    public static Text DialogueText { get => dialogueText; }
    public static List<string> DialougeLog { get => dialougeLog; }
    public static Dictionary<string, Attr> AttrDict { get => attrDict; }
    public static GameObject UIPanel { get => uiPanel; }

    // Start is called before the first frame update

    void Start()
    {
        // initializing
        player = GameObject.Find("Player");
        dialogueUI = GameObject.Find("Dialogue");
        uiPanel = GameObject.Find("LogPanel");
        dialogueText = Game.DialogueUI.GetComponent<Text>();
        TextAsset headerText = Resources.Load("Header") as TextAsset;
        dialougeLog = new List<string>(headerText.text.Split('\n'));
        
        Debug.Log("Game Activated");

        //GameObject ttf = new GameObject("Abbandon");
        //ttf.transform.parent = uiPanel.transform;
        //Text pdf = ttf.AddComponent<Text>() as Text;
        //RectTransform rectTransform = pdf.GetComponent<RectTransform>();
        //rectTransform.anchorMin = new Vector2(1, 0); // StretchRight
        //rectTransform.anchorMax = new Vector2(1, 1); // StretchRight
        //rectTransform.offsetMin = new Vector2(-400, 0); // Pos X
        //rectTransform.offsetMax = new Vector2(0, 0); // Pos Y
        //rectTransform.pivot = new Vector2(0.5f, 1); // Pivot
        //rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 400);
        //pdf.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font; ;
        //ContentSizeFitter fitter = ttf.AddComponent<ContentSizeFitter>() as ContentSizeFitter;
        //fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        //fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        //pdf.text = "ÑÇ°Í¶Ù";
    }

    // Update is called once per frame
    void Update()
    {
        //logText = new System.Text.StringBuilder();
        //foreach (string item in dialougeLog)
        //{
        //    logText.Append(item).Append("\n");
        //}
        //DialogueText.text = logText.ToString();
    }
}
