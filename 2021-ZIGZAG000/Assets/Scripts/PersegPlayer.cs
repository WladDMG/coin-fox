using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersegPlayer : MonoBehaviour
{
    [SerializeField] private Transform rapoza;
    [SerializeField] Vector3 dist;
    [SerializeField] private float lerpVal;
    [SerializeField] private Vector3 pos, alvoPos;
    // Start is called before the first frame update
    void Start()
    {
        dist = rapoza.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        PersegueFunc();
    }

    void PersegueFunc()
    {
        pos = transform.position;
        alvoPos = rapoza.position - dist;
        pos = Vector3.Lerp(pos, alvoPos, lerpVal);
        transform.position = pos;
    }
}
