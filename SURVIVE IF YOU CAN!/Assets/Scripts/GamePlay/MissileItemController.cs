using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileItemController : MonoBehaviour
{
    [SerializeField] private MissileItemBehaviour behaviour = new MissileItemBehaviour();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().ChangeHP(behaviour.value);
            Destroy(this.gameObject);
        }else if(other.tag == "ItemDestructor")
        {
            Destroy(this.gameObject);
        }
    }
}
[System.Serializable]
class MissileItemBehaviour
{
    public MissileTypes _missileType;
    public int value;
}

public enum MissileTypes
{
    heal,
    damage
}