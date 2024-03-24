using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BOTF3D_Core;
//using BOTF3D_Combat;
//using Assets.Script;

namespace Assets.Core
{

    public class DropLineMovable: MonoBehaviour
    {                 
        private LineRenderer lineRenderer;
        private Transform[] points;

        private void Awake()
        {

            lineRenderer = GetComponent<LineRenderer>();
        }
        //public GalaxyDropLine(LineRenderer lineRender)
        //{
        //    if (lineRender == null)
        //    lineRenderer = lineRender;
        //}
        public void SetUpLine(Transform[] points)
        {
            lineRenderer.positionCount = points.Length;
            this.points = points;
        }
        private void Update()
        {
            if (lineRenderer != null && points != null)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    lineRenderer.SetPosition(i, points[i].position);
                }
            }
        }
    }
}
