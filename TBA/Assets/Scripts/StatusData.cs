using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Status_", menuName = "New Status")]
public class StatusData : ScriptableObject
{
    public Status statusType;
    public string statusName;
    public float statusStrength;
    public Sprite statusSprite;
    public string statusDesc;
}
