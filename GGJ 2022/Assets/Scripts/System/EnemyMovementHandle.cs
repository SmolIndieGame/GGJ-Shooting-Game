using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHandle : MonoBehaviour
{
    public static EnemyMovementHandle I;

    public GameObject oldman;
    public GameObject child;

    public float distanceAggroFactor = 3;
    public float distanceAggroMax = 33;

    List<(GameObject, float)> aggroPoint;
    List<float> tempAggro = new List<float>();

    private void Awake()
    {
        I = this;

        aggroPoint = new List<(GameObject, float)>
        {
            ( oldman, 10 ),
            ( child, 20 )
        };
    }

    public GameObject GetTarget(GameObject enemy)
    {
        float totalAggro = 0;
        Vector3 pos = enemy.transform.position;
        int i = 0;
        foreach (var item in aggroPoint)
        {
            if (i >= tempAggro.Count)
                tempAggro.Add(item.Item2);
            else
                tempAggro[i] = item.Item2;
            tempAggro[i] += Mathf.Max(0, distanceAggroMax - Vector2.Distance(pos, item.Item1.transform.position) * distanceAggroFactor);
            totalAggro += tempAggro[i];
            i++;
        }

        float ranVal = Random.Range(0, totalAggro);
        for (i = 0; i < aggroPoint.Count; i++)
        {
            if (ranVal <= tempAggro[i])
                return aggroPoint[i].Item1;
            ranVal -= tempAggro[i];
        }

        return aggroPoint[aggroPoint.Count - 1].Item1;
    }
}
