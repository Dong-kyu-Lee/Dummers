using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogParser : MonoBehaviour
{
    public Dialog[] Parse(string _CSVFileName)
    {
        // 대사 리스트 생성
        List<Dialog> dialogList = new List<Dialog>();
        //CSV 파일 가져옴
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        // '\n' 단위로 쪼갬 --> 한 줄씩 쪼개서 넣음
        string[] data = csvData.text.Split(new char[] { '\n' });
        
        for(int i = 1; i < data.Length;)
        {
            // ',' 단위로 쪼개서 row에 넣음
            string[] row = data[i].Split(new char[] { ',' });

            Dialog dialog = new Dialog(); // 대사 리스트 생성
            
            dialog.name = row[1];
            
            // dialog.contexts는 string[] 이기 때문에
            // 크기가 정해져있지 않으므로 contexts = row[2] 이런 식으로 안됨
            List<string> contextList = new List<string>();
            
            do //다음 문장의 화자 name이 여백이면 아까 말한 화자랑 같으므로 문장 추가
            {
                contextList.Add(row[2]);
                
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
