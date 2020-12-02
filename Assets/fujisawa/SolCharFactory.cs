using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolCharFactory : MonoBehaviour
{
    [SerializeField]
    private Transform TEdgeSolution=null;
    [SerializeField]
    private Transform TCornerSolution=null;

    private List<Text> edgeTexts= new List<Text>();
    private List<Text> cornerTexts = new List<Text>();

    private Color normal = Color.black;
    private Color highlight = Color.red;

    public void CreateSolutionText()
    {
        if (edgeTexts.Count != 0 || cornerTexts.Count != 0) return;
        SolDisp(true);
        SolDisp(false);
        Debug.Log($"max e:{edgeTexts.Count} c:{cornerTexts.Count}");

    }

    public void ChangeSolCharColor(int index,bool IsEdge) {
        Debug.Log("colorChanege"+index);
        if (IsEdge == true)
        {
            if (edgeTexts[index].color == normal) edgeTexts[index].color = highlight;
            else edgeTexts[index].color = normal;
        }
        else {
            index -= edgeTexts.Count;
            if (cornerTexts[index].color == normal) cornerTexts[index].color = highlight;
            else cornerTexts[index].color = normal;
        }
    }

    private void SolDisp(bool IsEdge) {
        GameObject obj = (GameObject)Resources.Load("chars/SolChar");
        List<int> solution = new List<int>();
        if(IsEdge)solution = StaticCubeInfo.s.GetEdgeSolution();
        else solution = StaticCubeInfo.s.GetCornerSolution();
        foreach (int id in solution)
        {
            string s = StaticCubeInfo.cd.GetPixelNameFromId(id);
            GameObject UIText = null;
            if(IsEdge)UIText = (GameObject)Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, TEdgeSolution);
            else UIText = (GameObject)Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, TCornerSolution);
            Text text = UIText.GetComponent<Text>();
            text.text = s;
            if (IsEdge) edgeTexts.Add(text);
            else cornerTexts.Add(text);
        }
    }


}
