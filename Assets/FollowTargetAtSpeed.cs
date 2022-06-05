using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAtSpeed : MonoBehaviour
{
    public GameObject myObject;
    public GameObject targetObject;
    public float max_s = 5;
    public float accel = 5;
    public float trigger_rad;


    private Vector3 initialOffset;
    private Vector3 cur_v;

    // Start is called before the first frame update
    void Start()
    {
        initialOffset = targetObject.transform.position - myObject.transform.position;
        cur_v = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = targetObject.transform.position - myObject.transform.position - initialOffset;

        float curdist = toTarget.magnitude;
        float target_s = curdist > trigger_rad? max_s : 0;

        cur_v += accel * toTarget.normalized;
        if (cur_v.magnitude > target_s) {
            cur_v = cur_v.normalized * target_s;
        }
        myObject.transform.Translate(cur_v * Time.deltaTime);
    }
}
