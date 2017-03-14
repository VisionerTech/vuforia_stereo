using UnityEngine;
using System.Collections;

public class AdjustVirtualTransparent : MonoBehaviour
{

    Vector2 targetScale;
    float rate = 6.2f;


	void Start () {
        targetScale = new Vector2();
	}


	void Update () {
        targetScale.x = 96.0f * rate;
        targetScale.y = 108.0f * rate;
        transform.localScale = new Vector3(targetScale.x, transform.localScale.y, targetScale.y);
	}
}
