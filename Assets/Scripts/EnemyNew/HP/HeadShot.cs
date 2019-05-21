using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    EnemyHP parent;
    // Use this for initialization
    void Start()
    {
        parent = transform.GetComponentInParent<EnemyHP>();
    }

    public void execute()
    {
        parent.damage(1000, 1);
    }
}
