using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    Dictionary<int, Dialog> dialogDic;
    public DialogEvent dialogEvent;

    private void Start()
    {
        dialogDic = DatabaseManager.dbManager.GetDialogDic(dialogEvent.fileName);
    }

    public Dialog[] GetDialogs()
    {
        List<Dialog> dialogList = new List<Dialog>();
        int startNum = (int)dialogEvent.line.x;
        int endNum = (int)dialogEvent.line.y;

        for (int i = 0; i < endNum - startNum; ++i)
        {
            dialogList.Add(dialogDic[startNum + i]);
        }

        return dialogList.ToArray();
    }

    //https://www.youtube.com/watch?v=DPWvoUlHbjg
    // 28 : 11
}
