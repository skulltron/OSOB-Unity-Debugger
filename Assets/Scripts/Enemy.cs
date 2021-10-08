using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static void DieAll()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }

}
