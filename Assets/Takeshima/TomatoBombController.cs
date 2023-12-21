using UnityEngine;

public class TomatoBombController : MonoBehaviour
{
    public GameObject ExplosionEffect;
    public GameObject ExplosionSpark;
    private Vector3 originalPosition;
    private bool hasExploded = false;
    private Quaternion initialRotation;

    void Start()
    {
        originalPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!hasExploded)
            {
                ContactPoint contact = collision.contacts[0];
                Vector3 enemyCenter = contact.point;
                Instantiate(ExplosionEffect, enemyCenter, Quaternion.identity);
                Instantiate(ExplosionSpark, enemyCenter, Quaternion.identity);

                if (!collision.gameObject.CompareTag("TomatoBomb"))
                {
                    // キネマティックモードを無効にする前に初期位置に戻す
                    transform.position = originalPosition;

                    // キネマティックモードを無効にする
                    GetComponent<Rigidbody>().isKinematic = false;
                }

                hasExploded = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // クリック時にhasExplodedをリセット
            hasExploded = false;

            // TomatoBombの位置からRayを飛ばす
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 目標地点を元の位置から引いて、方向ベクトルを得る
                Vector3 shootDirection = hit.point - originalPosition;

                // Enemyの位置に応じて力を自動調整する
                AdjustForce(hit.collider, shootDirection);
            }
        }
    }

    void AdjustForce(Collider enemyCollider, Vector3 shootDirection)
    {
        // Enemyの位置に応じて力を計算する
        float distanceToEnemy = Vector3.Distance(originalPosition, enemyCollider.bounds.center);
        float upwardForce = CalculateUpwardForce(distanceToEnemy);
        float rotationSpeed = CalculateRotationSpeed(distanceToEnemy);

        // Shootメソッドを呼び出して物体を飛ばす
        Shoot(shootDirection.normalized * 2500f, upwardForce, rotationSpeed);
        hasExploded = false;
    }

    public float CalculateUpwardForce(float distanceToEnemy)
    {
        // 距離が近いほど上向きの力を増やす
        return Mathf.Max(150f, 600f - distanceToEnemy * 10f);
    }

    public float CalculateRotationSpeed(float distanceToEnemy)
    {
        // 距離が遠いほど回転速度を増やす
        return Mathf.Min(200f, distanceToEnemy * 5f);
    }

    public void Shoot(Vector3 dir, float upwardForce, float rotationSpeed)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // 回転のリセット
        rb.rotation = initialRotation;

        rb.AddTorque(new Vector3(1, 1, 1) * rotationSpeed, ForceMode.Impulse);
        rb.AddForce(Vector3.up * upwardForce);
        rb.AddForce(dir);
    }
}
