using SweetGame.CodeBase.Game.Spawner;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DestructorMarker))]
public class DestructorMarkerEditor : Editor
{
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(DestructorMarker destructor, GizmoType type)
    {
        Gizmos.color = Color.green;
        var position = destructor.transform.position;
        Gizmos.DrawSphere(position, 0.5f);
        position = new Vector3(position.x, 
            position.y,
            0);
        destructor.transform.position = position;
    }
}