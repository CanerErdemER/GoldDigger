using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeRenderer : MonoBehaviour
{
    LineRenderer LineRenderer;

    float lineWidth = 0.05f;
    [SerializeField]
    Transform startTransform;
    private void Awake()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.enabled=false;
        LineRenderer.startWidth=lineWidth;
    }
    public void showRopeFNC(Vector3 targetPosition,bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!LineRenderer.enabled)//Linerenderer kapal�ysa a�
            {
                LineRenderer.enabled = true;
            }
            LineRenderer.positionCount = 2;//de�eri 2 default ata
        }
        else
        {
            LineRenderer.positionCount = 0;
            if (LineRenderer.enabled)
            {
                LineRenderer.enabled = false;//line renderer a��ksa kapat
            }
        }
        if (enableRenderer)//ip g�z�kmeye ba�lad�sa
        {
            Vector3 temp = startTransform.position;
            temp.z = -3;
            startTransform.position = temp;

            temp = targetPosition;
            temp.z = 0;
            targetPosition=temp;

            LineRenderer.SetPosition(0, startTransform.position);
            LineRenderer.SetPosition(1, targetPosition);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
