using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float atkSpeed = 70f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator AtkMovement() {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, atkSpeed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 대기
        }

        while (Vector3.Distance(transform.position, startPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, atkSpeed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 대기
        }
        transform.position = startPosition;
    }
}
