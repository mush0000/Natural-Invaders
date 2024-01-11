using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicaDirector : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    private int poolSize = 3;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();   //poolの辞書型を作成
        foreach (var prefab in prefabs) //prefabsの配列分新しいPoolを作成
        {
            var objectPool = new Queue<GameObject>(poolSize);
            InitialPool(objectPool, prefab);
            poolDictionary.Add(prefab.name, objectPool); //作ったペアをpoolDictionaryへ
        }

        StartCoroutine(MainLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitialPool(Queue<GameObject> queue, GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)//プールのサイズだけ作成し不可視にしてQueueへ保存
        {
            GameObject obj = Instantiate(prefab);
            obj.name = prefab.name;
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }

    public void CreateUnionObject(GameObject prefab, Vector2 pos1, Vector2 pos2)
    {
        // 新しいGameObjectを取得して表示します。
        GameObject obj = GetObject(prefab);
        // 新しいGameObjectの位置を二つのGameObjectの中間点に設定します。
        obj.transform.position = (pos1 + pos2) / 2;
        SuicaParent objScript = obj.GetComponent<SuicaParent>();
        objScript.isGameOverTrigger = true;
    }

    public GameObject GetObject(GameObject prefab)
    {//Queueから可視化して取り出す。もし足りなければ生成してそのObjectをreturnする
        if (poolDictionary.TryGetValue(prefab.name, out var queue))
        {//引数のGameObjectからPoolのqueueを取得、なければnull
            if (queue.Count > 0)
            {
                GameObject obj = queue.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                GameObject newObj = Instantiate(prefab);
                newObj.name = prefab.name;
                return newObj;
            }
        }
        return null;
    }

    public void ReturnObject(GameObject obj)
    {//引数のGameObjectを不可視にしてQueueへ戻す
        Debug.Log(obj.name);
        if (poolDictionary.TryGetValue(obj.name, out var queue))
        {//objのpollを探して、それがあれば不可視にして戻す。
            obj.SetActive(false);
            queue.Enqueue(obj);
            Debug.Log("return");
        }
    }

    IEnumerator MainLoop()
    {   //メインループ、オブジェクトの作成と配置を繰り返す
        yield return null;
    }
}
