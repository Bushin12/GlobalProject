using UnityEngine;

public class UsePlayerObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    public bool UseNow { private set; get; }
    public virtual void Reise()
    {
        UseNow = true;
    }
    public virtual void Put()
    {
        UseNow = false;
    }
    public void SetGraviryDirection()
    {
        _rigidbody.gravityScale *= -1;
        transform.localScale = new Vector3(1, _rigidbody.gravityScale, 1);
    }
}
