using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // ������ �������
    public float spawnInterval = 1f; // ��� ��� ������ �������
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
        // ����� ������ ����
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(Random.Range(-3f, 3f), 5f, 0);

        // ���� ��� �����
        var randomColor = GetRandomColor();

        // ����� ���� �� �������
        var spriteRenderer = cube.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = randomColor.color;
        }

        // ����� ���� �-String ������� ��������
        var cubeCollision = cube.GetComponent<CubeCollision>();
        if (cubeCollision != null)
        {
            cubeCollision.cubeColor = randomColor.name;

        }
    }

    (Color color, string name) GetRandomColor()
    {
        // ����� ��� �����
        int randomIndex = Random.Range(0, 3);
        if (randomIndex == 0) return (Color.red, "Red");
        if (randomIndex == 1) return (Color.blue, "Blue");
        return (Color.yellow, "Yellow");
    }
}