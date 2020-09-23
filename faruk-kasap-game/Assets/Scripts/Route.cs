using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public enum MoveType
    {
        Line
       // Circle
    }
    [Serializable]
    public struct Moves
    {
        public MoveType movetype;
        public Vector2 addition;
    };

    public List<Moves> moves;
    public float speed;

    int move = -1;
    Vector2 startPoint;
    float dx;
    float dy;
    float dist;
    float ratio;

    // Start is called before the first frame update
    void Start()
    {
        nextMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (moves[move].movetype == MoveType.Line)
        {

            transform.position = new Vector3(transform.position.x + dx * ratio * Time.deltaTime
                , transform.position.y + dy * ratio * Time.deltaTime, 0);

            if (distance(new Vector2(transform.position.x, transform.position.y),
                new Vector2(startPoint.x + dx, startPoint.y + dy)) <= speed * Time.deltaTime)
            {
                transform.position = new Vector3(startPoint.x + dx, startPoint.y + dy, 0);
                nextMove();
            }
        }

    }

    public void nextMove()
    {

        move = (move + 1) % moves.Count;
        dx = moves[move].addition.x;
        dy = moves[move].addition.y;
        dist = distance(dx, dy);
        ratio = speed / dist;
        startPoint = new Vector2(transform.position.x, transform.position.y);

    }

    public float distance(float a , float b)
    {
        return Mathf.Sqrt(a*a + b*b);
    }
    public float distance(Vector2 a, Vector2 b)
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
    }
}
