using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocisk_hit : MonoBehaviour
{
    public Enemy_shot me;
    bool trafienie=false;
    Vector3 pozycja;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        me = GetComponent<Enemy_shot>();
        if (me.czekaj - me.odlicz >= 0.1 && trafienie)
        {
            GameObject.FindWithTag("Player").GetComponent<HP_Player>().otrzymaneobrażenia(20);
            trafienie = false;
        }
    }

    public void hit()
    {
        float x = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);
        if (Random.Range(1, 10)*2/x > 0.4f)
        trafienie = true;
    }
}
