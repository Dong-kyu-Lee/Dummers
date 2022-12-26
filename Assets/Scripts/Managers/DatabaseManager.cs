using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager dbManager;
    DialogParser parser;
    [SerializeField] string csv_FileName;

    public static bool isFinish = false; // ���̾�αװ� ���� ������ �Ǿ�����

    private void Awake()
    {
        if (dbManager == null)
        {
            dbManager = this;
        }
        parser = GetComponent<DialogParser>();
    }

    public Dictionary<int, Dialog> GetDialogDic(string csv_File)
    {
        Dictionary<int, Dialog> dialogDic = new Dictionary<int, Dialog>();
        Dialog[] dialogs = parser.Parse(csv_File);
        for (int i = 0; i < dialogs.Length; ++i)
        {
            dialogDic.Add(i + 1, dialogs[i]);
        }
        isFinish = true;
        return dialogDic;
    }

    // n ~ m ��°���� ��ȭ�� �����Ͷ�
    /*public Dialog[] GetDialogs(int startNum, int endNum)
    {
        List<Dialog> dialogList = new List<Dialog>();

        for(int i = 0; i < endNum - startNum; ++i)
        {
            dialogList.Add(GetDialogDic[startNum + i]);
        }

        return dialogList.ToArray();
    }*/
}


