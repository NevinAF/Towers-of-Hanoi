using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveTowers : MonoBehaviour
{
    private static readonly float paddingX = 0.2f, paddingY = 0.2f;
    private Post[] posts;
    public GameObject DiskPrefab;

    private Queue<Vector2Int> moves;
    private Transform UI;
    private float postHeight;
    private float diskHeight;

    // Use this for initialization
    void Start()
    {
        posts = new Post[3]
            {
                GameObject.Find("Post_1").GetComponent<Post>(),
                GameObject.Find("Post_2").GetComponent<Post>(),
                GameObject.Find("Post_3").GetComponent<Post>()
            };

        postHeight = posts[0].transform.Find("poll_graphic").localScale.y * 2;
        UI = GameObject.Find("Canvas").transform.Find("UI");
        Ring.SolveTowers = this;

    }

    public void SetUp()
    {
        foreach(Post post in posts)
        {
            while(post.disks.Count > 0)
                GameObject.Destroy(post.disks.Pop());
        }
        int diskCount = UI.Find("Counter: Disks").GetComponent<DiskCounter>().GetDisks();
        diskHeight = (postHeight - paddingY) / (diskCount);
        float minScale = posts[0].transform.Find("poll_graphic").localScale.x + paddingX;
        float maxScale = posts[0].transform.Find("base_graphic").localScale.x - paddingX;

        float scaleDif = (maxScale - minScale) / (diskCount + 2);

        for (int i = 0; i < diskCount; i++)
        {
            GameObject d = Instantiate(DiskPrefab);
            d.transform.position = new Vector3(
                posts[0].transform.position.x,
                diskHeight * i,
                posts[0].transform.position.z
                );
            d.transform.localScale = new Vector3(
                1,
                diskHeight,
                1
                );

            d.transform.Find("hole_graphic").localScale = new Vector3(
                d.transform.Find("hole_graphic").localScale.x,
                d.transform.Find("hole_graphic").localScale.y + (.01f / diskHeight),
                d.transform.Find("hole_graphic").localScale.z
                );
            d.transform.Find("disk_graphic").localScale = new Vector3(
                maxScale - (scaleDif * (i + 1)),
                0.5f,
                maxScale - (scaleDif * (i + 1))
                );

            
            posts[0].disks.Push(d);
        }
    }

    public void Solve()
    {
        TowersOfHanoi towers = new TowersOfHanoi(posts[0].disks.Count);
        moves = towers.Solve();
        
        MoveNext();
    }

    public void MoveNext()
    {
        Vector2Int move = moves.Dequeue();
        GameObject disk = posts[move.x].disks.Pop();

        Queue<Vector3> targets = new Queue<Vector3>();
        if (Ring.speed < 200)
        {
            targets.Enqueue(
                new Vector3(
                    posts[move.x].transform.position.x,
                    postHeight + 1,
                    posts[move.x].transform.position.z
                    ));
            targets.Enqueue(
                new Vector3(
                    posts[move.y].transform.position.x,
                    postHeight + 1,
                    posts[move.y].transform.position.z
                    ));
        }
        targets.Enqueue(
            new Vector3(
                posts[move.y].transform.position.x,
                posts[move.y].disks.Count * diskHeight,
                posts[move.y].transform.position.z
                ));
        
        disk.GetComponent<Ring>().MoveTo(targets);
        posts[move.y].disks.Push(disk);
    }

    public void Speed_upd()
    {
        Ring.speed = UI.Find("Counter: Speed").GetComponent<Speed>().GetSpeed();
    }
}
