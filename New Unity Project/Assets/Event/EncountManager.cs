using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EncountManager : MonoBehaviour
{
    [SerializeField] Text ResultText = null;
    int[] resultID = new int[20];
    float[] resultAR = new float[20];    
    
    public void EncountCulc()
    {
        int result;
        int count = 0;
        int[] encount = new int[100];
       
        for (int i = 0; i < 20; i++)
        {
            resultID[i] = i;
        }
        resultAR[0] = 0.08f;
        resultAR[1] = 0.02f;
        resultAR[2] = 0.03f;
        resultAR[3] = 0.07f;
        resultAR[4] = 0.06f;
        resultAR[5] = 0.07f;
        resultAR[6] = 0.03f;
        resultAR[7] = 0.02f;
        resultAR[8] = 0.08f;
        resultAR[9] = 0.09f;
        resultAR[10] = 0.01f;
        resultAR[11] = 0.06f;
        resultAR[12] = 0.04f;
        resultAR[13] = 0.03f;
        resultAR[14] = 0.07f;
        resultAR[15] = 0.02f;
        resultAR[16] = 0.08f;
        resultAR[17] = 0.05f;
        resultAR[18] = 0.05f;
        resultAR[19] = 0.04f;

        
        for (int i = 0; i < encount.Length; i++)
        {
            encount[i] = 0;
        }
        
        for(int i = 0; i < resultID.Length; i++)
        {
            if (resultAR[i] != 0)
            {
                for (int j = 0; j < Mathf.Floor(resultAR[i] * 100); j++)
                {
                    encount[count] = resultID[i];
                    count++;
                }
            }
        }
        
        Random.InitState(System.DateTime.Now.Millisecond);
        
        int randomIndex = Random.Range(0, encount.Length);
        
        result= encount[randomIndex];
       
        if (result == resultID[0])
        {
            ResultText.text = "変異ウイルスの出現";
        }
        else if (result == resultID[1])
        {
            ResultText.text = "暴動";
        }
        else if (result == resultID[2])
        {
            ResultText.text = "対策本部の火災";
        }
        else if (result == resultID[3])
        {
            ResultText.text = "国民からの賞賛";
        }
        else if (result == resultID[4])
        {
            ResultText.text = "助成金の着服";
        }
        else if (result == resultID[5])
        {
            ResultText.text = "Youtuberの感染対策情報発信";
        }
        else if (result == resultID[6])
        {
            ResultText.text = "ワクチンの大量廃棄";
        }
        else if (result == resultID[7])
        {
            ResultText.text = "政治家の集団飲み会";
        }
        else if (result == resultID[8])
        {
            ResultText.text = "誤情報の発信";
        }
        else if (result == resultID[9])
        {
            ResultText.text = "研究所への寄付";
        }
        else if (result == resultID[10])
        {
            ResultText.text = "対策本部の火災";
        }
        else if (result == resultID[11])
        {
            ResultText.text = "地震";
        }
        else if (result == resultID[12])
        {
            ResultText.text = "台風";
        }
        else if (result == resultID[13])
        {
            ResultText.text = "大洪水";
        }
        else if (result == resultID[14])
        {
            ResultText.text = "マスク反対デモ";
        }
        else if (result == resultID[15])
        {
            ResultText.text = "ワクチン反対デモ";
        }
        else if (result == resultID[16])
        {
            ResultText.text = "映画「私感染しないので」が大ヒット";
        }
        else if (result == resultID[17])
        {
            ResultText.text = "医学部生出陣";
        }
        else if (result == resultID[18])
        {
            ResultText.text = "１０万円配布";
        } 
        else if (result == resultID[19])
        {
            ResultText.text = "スマホ版「I.W」が世界的大ヒット";
        }
        else
        {
            ResultText.text = "大谷翔平の活躍";
        }

    }
    
}