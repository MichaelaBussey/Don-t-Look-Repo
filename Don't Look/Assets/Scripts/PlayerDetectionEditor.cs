using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(DetectionCircle))]
public class PlayerDetectionEditor : Editor
{
    void OnSceneGUI()
    {
        DetectionCircle player = (DetectionCircle)target;

        //Draws view reach
        Handles.color = Color.white;
        Handles.DrawWireArc(player.transform.position, Vector3.forward, Vector3.up, 360, player.viewRadius);

        Handles.DrawWireArc(player.transform.position, Vector3.forward, Vector3.up, 360, player.viewRadius + player.lightmodifier);

        


    }
}
