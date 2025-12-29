using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InfluenceUpgrade", menuName = "Scriptable Objects/InfluenceUpgrade")]
public class InfluenceUpgrade : ScriptableObject
{
    public string upgradeName;
    public int upgradeTier;
    public int influenceCost;
    public int influenceUpgrade;
    public int muxUpgrade;
    public List<InfluenceUpgrade> prereqs;
}