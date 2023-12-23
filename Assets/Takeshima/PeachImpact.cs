using UnityEngine;

public class PeachImpactScript : MonoBehaviour
{
    public GameObject peachImpact; // アクティブにする prefab をインスペクターから設定

    // AnimationEvent から呼び出すメソッド
    public void ActivatePrefab()
    {
        if (peachImpact != null)
        {
            // prefab をアクティブにする
            peachImpact.SetActive(true);

            // 1秒後に非アクティブにする（適宜調整）
            Invoke("DeactivatePrefab", 1f);
        }
    }

    // アクティブにした prefab を非アクティブにするメソッド
    private void DeactivatePrefab()
    {
        if (peachImpact != null)
        {
            peachImpact.SetActive(false);
        }
    }
}
