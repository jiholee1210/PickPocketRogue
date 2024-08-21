using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 nextStage;
    private Vector3 startStage;

    private float atkSpeed = 8000f;
    private float moveSpeed = 10000f;
    private float stealSpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(450, -30, 0);
        nextStage = new Vector3(1100, 0, 0);
        startStage = new Vector3(-1100, 0 , 0);
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

    public IEnumerator ClearStageOrSteal() {
        while(Vector3.Distance(transform.position, nextStage) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, nextStage, moveSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        transform.position = startStage;

        while(Vector3.Distance(transform.position, startPosition) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = startPosition;
    }

    public IEnumerator GoToEnemy() {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, atkSpeed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 대기
        }
    }

    public IEnumerator BackToPos() {
        while (Vector3.Distance(transform.position, startPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, atkSpeed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 대기
        }
        transform.position = startPosition;
    }

    public IEnumerator TrySteal() {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, stealSpeed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 대기
        }
    }
}
