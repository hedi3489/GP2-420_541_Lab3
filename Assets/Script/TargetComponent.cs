using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();

            // Hide target after 5 seconds
            Invoke("HideTarget", 5f);

            Renderer parentRenderer = transform.parent.GetComponent<Renderer>();
            if (parentRenderer != null)
            {
                parentRenderer.material.color = Color.green;
                Invoke("ChangeColorBack", 5f); // Change color back after 5 seconds
            }
        }
    }

    void ChangeColorBack()
    {
        Renderer parentRenderer = transform.parent.GetComponent<Renderer>();
        if (parentRenderer != null)
        {
            parentRenderer.material.color = Color.red;
        }
    }

    public void HideTarget()
    {
        gameObject.SetActive(false);
    }
}