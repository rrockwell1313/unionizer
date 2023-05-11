using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Petition : ScriptableObject
{
    public int signatures = 0;
    [SerializeField]
    int minNumOfSignatures = 5;

    public bool HasEnoughSignatures()
    {
        return (signatures >= minNumOfSignatures);
    }

    public void Reset()
    {
        signatures = 0;
    }
}
