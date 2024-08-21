using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 targetPos;
    private Vector3 enemyPos;
    private Vector3 atkPos;

    private float atkSpeed = 8000f;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(650, 30, 0);
        enemyPos = transform.position;
        atkPos = new Vector3(150, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FailSteal() {
        while(Vector3.Distance(transform.position, targetPos) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1000f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        while(Vector3.Distance(transform.position, enemyPos) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, enemyPos, 1000f * Time.deltaTime);
            yield return null;
        }
        transform.position = enemyPos;

        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator EnemyAtk() {
        while(Vector3.Distance(transform.position, atkPos) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, atkPos, atkSpeed * Time.deltaTime);
            yield return null;
        }

        while(Vector3.Distance(transform.position, enemyPos) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, enemyPos, atkSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = enemyPos;
    }

    public IEnumerator GoToPlayer() {
        while(Vector3.Distance(transform.position, atkPos) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, atkPos, atkSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator BackToPos() {
        while(Vector3.Distance(transform.position, enemyPos) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, enemyPos, atkSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = enemyPos;
    }
}
