using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // החיבור לקובייה
    public float spawnInterval = 1f; // זמן בין קובייה לקובייה
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    void SpawnCube()
    {
        // יצירת קובייה חדשה
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(Random.Range(-3f, 3f), 5f, 0);

        // קבלת צבע אקראי
        var randomColor = GetRandomColor();

        // הגדרת הצבע של הקובייה
        var spriteRenderer = cube.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = randomColor.color;
        }

        // הגדרת הצבע כ-String בקוביית ההתנגשות
        var cubeCollision = cube.GetComponent<CubeCollision>();
        if (cubeCollision != null)
        {
            cubeCollision.cubeColor = randomColor.name;

        }
    }

    (Color color, string name) GetRandomColor()
    {
        // בחירת צבע אקראי
        int randomIndex = Random.Range(0, 3);
        if (randomIndex == 0) return (Color.red, "Red");
        if (randomIndex == 1) return (Color.blue, "Blue");
        return (Color.yellow, "Yellow");
    }
}