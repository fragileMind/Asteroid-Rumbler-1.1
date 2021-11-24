using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialougeData
{
    private static TextAsset universalText;
    private TextAsset innerText;
    private Dictionary<string, QuestionItem> dialouges;

    private const string QUESTION_TAG = "q";
    private const string ANSWER_TAG = "a";
    private const string GREATER_THAN = ">";
    private const string LESS_THAN = "<";
    private const string END = "end";
    private const string TAG_HEADER = "tag_";

    public DialougeData(string filename)
    {
        Debug.Log(filename);
        if(universalText == null)
        {
            universalText = Resources.Load("NPC-Universal") as TextAsset;
        }
        innerText = Resources.Load(filename) as TextAsset;
        if (innerText == null)
        {
            innerText = universalText;
        }
        dialouges = new Dictionary<string, QuestionItem>();
        processRawData();
        int z = 0;
    }

    // 处理格式
    private void processRawData()
    {
        string[] lines = innerText.text.Split('\n');
        string pattern = @"^(\d*)(\w)(\d*): \[(.*?)\]([^→]*)→*(.*)$";
        string headerPattern = @"^@([^=]*) = (.*)$"; // Temp
        foreach (string s in lines)
        {
            foreach (Match match in Regex.Matches(s, pattern))
            {
                string p = match.Groups[2].Value;
                if (match.Groups[2].Value.Equals(QUESTION_TAG))
                {
                    QuestionItem item = new QuestionItem(match.Groups[1].Value + match.Groups[2].Value, match.Groups[5].Value);
                    dialouges.Add(match.Groups[1].Value, item);
                }
                else if (match.Groups[2].Value.Equals(ANSWER_TAG))
                {
                    bool check = true;
                    string next = null;
                    string tag = null;
                    // 检定
                    if (match.Groups[4].Value.Length > 0)
                    {
                        string checkPattern = @"^(\S*)\s*([><])\s*(.*)$";
                        MatchCollection matches = Regex.Matches(match.Groups[4].Value, checkPattern);
                        Match checkMatch = matches[0];
                        Debug.Log(checkMatch.Groups[0]);
                        int.TryParse(checkMatch.Groups[3].Value, out int value);
                        if (checkMatch.Groups[2].Value.Equals(GREATER_THAN))
                        {
                            check = Game.Player.GetComponent<Player>().getAttr(Game.AttrDict[checkMatch.Groups[1].Value]) >= value;
                        }
                        else if (checkMatch.Groups[2].Value.Equals(LESS_THAN))
                        {
                            check = Game.Player.GetComponent<Player>().getAttr(Game.AttrDict[checkMatch.Groups[1].Value]) <= value;
                        }
                    }

                    // 后续
                    if (match.Groups[6].Value.Length > 0)
                    {
                        string[] allTags = match.Groups[6].Value.Replace(" ", string.Empty).Split('&');
                        foreach (string str in allTags)
                        {
                            // to next && end && tags
                            if (str.Equals(END))
                            {
                                next = null;
                            }
                            else if (str.Contains(TAG_HEADER))
                            {
                                tag = str;
                            }
                            else
                            {
                                next = str;
                            }
                        }
                    }
                    AnswerItem item = new AnswerItem(match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value, match.Groups[5].Value, next, check, tag);
                    if (dialouges.ContainsKey(match.Groups[1].Value))
                    {
                        dialouges[match.Groups[1].Value].Answers.Add(item);
                    }
                    else
                    {
                        Debug.Log("DialougeAnswerWarning: " + match.Groups[1].Value + " not found");
                    }
                }
                //Debug.Log(
                //    "全部" + (match.Groups[0].Success ? match.Groups[0].Value : "Empty") 
                //    + "\n序列：" + (match.Groups[1].Success ? match.Groups[1].Value : "Empty")
                //    + "\n类型：" + (match.Groups[2].Success ? match.Groups[2].Value : "Empty")
                //    + "\n代号：" + (match.Groups[3].Success ? match.Groups[3].Value : "Empty")
                //    + "\n检定：" + (match.Groups[4].Success ? match.Groups[4].Value : "Empty")
                //    + "\n内容：" + (match.Groups[5].Success ? match.Groups[5].Value : "Empty")
                //    + "\n后续：" + (match.Groups[6].Success ? match.Groups[6].Value : "Empty")
                //    );
            }
        }
    }

    public string getTextByID(string key)
    {
        dialouges.TryGetValue(key, out QuestionItem item);
        string value = "";// item.ToString();
        return value;
    }

    public string DebugText() { return "啊";  }
    //public string DebugText { get => innerText.text; }
}
