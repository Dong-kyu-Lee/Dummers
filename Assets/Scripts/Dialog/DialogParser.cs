using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogParser : MonoBehaviour
{
    public Dialog[] Parse(string _CSVFileName)
    {
        // ��� ����Ʈ ����
        List<Dialog> dialogList = new List<Dialog>();
        //CSV ���� ������
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        // '\n' ������ �ɰ� --> �� �پ� �ɰ��� ����
        string[] data = csvData.text.Split(new char[] { '\n' });
        
        for(int i = 1; i < data.Length;)
        {
            // ',' ������ �ɰ��� row�� ����
            string[] row = data[i].Split(new char[] { ',' });

            Dialog dialog = new Dialog(); // ��� ����Ʈ ����
            
            dialog.name = row[1];

            // dialog.contexts�� string[] �̱� ������
            // ũ�Ⱑ ���������� �����Ƿ� contexts = row[2] �̷� ������ �ȵ�
            //List<string> contextList = new List<string>();
            List<Sentence> contextList = new List<Sentence>();
            
            do //���� ������ ȭ�� name�� �����̸� �Ʊ� ���� ȭ�ڶ� �����Ƿ� ���� �߰�
            {
                int result = 0;
                bool parsable = int.TryParse(row[3], out result);
                if (parsable) contextList.Add(new Sentence(row[2], int.Parse(row[3])));
                else contextList.Add(new Sentence(row[2], -1));
                /*if (row[3] == "\r") contextList.Add(new Sentence(row[2], "0"));
                else contextList.Add(new Sentence(row[2], row[3]));*/
                
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else break;
            } while (row[0].ToString() == "");

            dialog.contexts = contextList.ToArray();

            dialogList.Add(dialog);
        }
        return dialogList.ToArray();
    }
}
