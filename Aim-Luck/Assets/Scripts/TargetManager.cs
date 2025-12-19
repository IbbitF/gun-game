using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class TargetManager : MonoBehaviour
{
    public GameObject target;
    public GameObject wall;

    public float timer = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(target, GetRandomSpawnPosition(wall), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int num = Random.Range(1, 6);
        if (timer <= 0f)
        {
            GameObject tag = Instantiate(target, GetRandomSpawnPosition(wall), Quaternion.identity);
            TargetScript spawn = tag.GetComponent<TargetScript>();

            if (num == 1)
                spawn.SetMovement(Vector3.right);
            else if (num == 2)
                spawn.SetMovement(Vector3.left);
            else if (num == 3)
                spawn.SetMovement(Vector3.up);
            else if (num == 4)
                spawn.SetMovement(Vector3.down);
            else
            {
                int num2 = Random.Range(1, 3);
                spawn.SetCircularMovement(num2, num2);
            }
            timer = 3f;
        }
    }

    private Vector3 GetRandomSpawnPosition(GameObject wall)   //random origin
    {
        float x = (float)(Random.Range(0f, 1f) * wall.transform.localScale.x - wall.transform.localScale.x / 2f);
        float y = (float)(Random.Range(0f, 1f) * wall.transform.localScale.y - wall.transform.localScale.y / 2f);    //prevents offset going outside of wall

        return wall.transform.position + new Vector3(x, y, -1);  //only x and y are needing to change
    }
}
