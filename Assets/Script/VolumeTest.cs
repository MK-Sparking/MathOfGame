
    
    //【InverseLerp】随着距离靠近，声音变小

    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;

    public class VolumeTest : MonoBehaviour
    {

        [Range(0f, 10f)] public float innerRadius = 1f;
        [Range(0f, 10f)] public float outerRadius = 2f;

        [Range(0, 1)] public float volume = 0f;
        void OnDrawGizmos()
        {
            Vector3 playerPos = transform.position;
            //简单起见，以原点为中心画两个同心圆
            Handles.DrawWireDisc(Vector3.zero, Vector3.up,innerRadius );
            Handles.DrawWireDisc(Vector3.zero, Vector3.up, outerRadius);
           
            Gizmos.DrawSphere(playerPos,0.05f);//画个球代表玩家
            
            float distToPlayer = Vector3.Distance(playerPos, Vector3.zero);//计算玩家离原点距离(米）

             volume = Mathf.InverseLerp(outerRadius, innerRadius, distToPlayer);
                
             Gizmos.DrawLine(playerPos,playerPos+Vector3.up*volume);//在玩家上方绘制"音量"大小
        }
    }
