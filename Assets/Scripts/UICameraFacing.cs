using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraFacing : MonoBehaviour
{

    Transform m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (m_Camera == null)
        {
            return;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(transform.position - m_Camera.position);
        }

    }
}
