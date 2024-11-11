using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/BlasterConfig")]
public class BlasterConfiguration : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public float FireRate;
    public float InitialDelay;
    public int MaxShots; 
}
