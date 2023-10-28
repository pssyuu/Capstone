using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Option", menuName = "Scriptable Object/OptionDate")]

public class OptionData : ScriptableObject
{

    [Header("# Main Info")]
    public string optionName;
    public int optionId;
    public int nextimageId;
    [TextArea]
    public string optionEx;
    public int nextOptionId;

}
