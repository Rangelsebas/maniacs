using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHRotate : MonoBehaviour
{
    [SerializeField] GameObject lhObject;
    [SerializeField] float speed = 0.1f;

    void Update()
    {
        lhObject.transform.Rotate(0.0f, speed, 0.0f, Space.World);
    }
}
