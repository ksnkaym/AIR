using System.Collections;
using UnityEngine;

public class Item_Test : MonoBehaviour {

	void OnTriggerEnter(Collider hit) {
        if (hit.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
	}
}
//ssets/Script/Item.cs(7,17): error CS1061: Type `UnityEngine.Collider' does not contain a definition for `CompereTag' and no extension method `CompereTag' of type `UnityEngine.Collider' could be found. Are you missing an assembly reference?
