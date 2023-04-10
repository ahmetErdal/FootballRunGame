using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInPool : MonoBehaviour
{

    [SerializeField] private Transform playerPoint;

    [SerializeField] private ObjectPooling poolObject;

    [SerializeField] private int poolChunkSize;

    Queue<GameObject> friends = new Queue<GameObject>();

    Queue<GameObject> enemies = new Queue<GameObject>();

    Queue<GameObject> chunks = new Queue<GameObject>();

    Queue<GameObject> chunkEnd = new Queue<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(Friend), 0f, 1f);
        InvokeRepeating(nameof(Enemy), 0f, .8f);
        InvokeRepeating(nameof(FriendHide), 5, 3);
        InvokeRepeating(nameof(EnemyHide), 5.5f, 1.5f);
        InvokeRepeating(nameof(ChunkHide), 2.5f, 1.5f);
        for (int i = 0; i < poolChunkSize; i++)
        {
            GameObject chunk = poolObject.GetPoolObject(2);
            chunk.transform.transform.position = new Vector3(0, 0, 10 * i);
            chunks.Enqueue(chunk);
        }

        GameObject chunkEnd = poolObject.GetPoolObject(3);
        chunkEnd.transform.transform.position = new Vector3(0, 0, 10 * poolChunkSize);
        this.chunkEnd.Enqueue(chunkEnd);
    }
    void Friend()
    {
        GameObject friend = poolObject.GetPoolObject(0);
        friend.transform.transform.position = new Vector3(1, 0, playerPoint.position.z + 20);
        friends.Enqueue(friend);
    }
    void Enemy()
    {
        GameObject enemy = poolObject.GetPoolObject(1);
        enemy.transform.transform.position = new Vector3(-1, 0, playerPoint.position.z + 40);
        enemies.Enqueue(enemy);
    }
    void FriendHide()
    {
        if (friends.Count == 0) return;
        GameObject friend = friends.Dequeue();
        poolObject.SetPoolObject(friend, 0);
    }
    void EnemyHide()
    {
        if (enemies.Count == 0) return;
        GameObject enemy = enemies.Dequeue();
        poolObject.SetPoolObject(enemy, 1);
    }
    void ChunkHide()
    {
        if (chunks.Count == 0) return;
        GameObject chunk = chunks.Dequeue();
        poolObject.SetPoolObject(chunk, 3);
    }
}
