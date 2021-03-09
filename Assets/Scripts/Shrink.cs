using UnityEngine;

public class Shrink : MonoBehaviour
{
    public float size = 3;
    [SerializeField] private bool isKingNote;
    private const float speed = 2;
    
    
    void Update()
    {
        if (size < 0 && isKingNote) return;
        if (size < 1 && !isKingNote) return;
        size -= Time.deltaTime * speed;
        transform.localScale = new Vector3(size, size, size);
    }
}
