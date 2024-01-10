using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicaDirector : MonoBehaviour
{
    // [SerializeField] GameObject banana;
    // private Queue<GameObject> bananaPool;
    // [SerializeField] GameObject potato;
    // private Queue<GameObject> potatoPool;
    // [SerializeField] GameObject pumpkin;
    // private Queue<GameObject> pumpkinPool;
    // [SerializeField] GameObject tomato;
    // private Queue<GameObject> tomatoPool;
    // [SerializeField] GameObject peach;
    // private Queue<GameObject> peachPool;
    // [SerializeField] GameObject grape;
    // private Queue<GameObject> grapePool;
    [SerializeField] GameObject[] prefabs;
    private Dictionary<GameObject, Queue<GameObject>> poolDictionary;
    private int poolSize = 3;
    void Start()
    {
        poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();   //poolの辞書型を作成
        foreach (var prefab in prefabs) //prefabsの配列分新しいPoolを作成
        {
            var objectPool = new Queue<GameObject>(poolSize);
            InitialPool(objectPool, prefab);
            poolDictionary.Add(prefab, objectPool); //作ったペアをpoolDictionaryへ
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateUnionObject(GameObject newObject, Vector2 pos1, Vector2 pos2)
    {
        // 新しいGameObjectを取得して表示します。
        GetObject(newObject);
        // 新しいGameObjectの位置を二つのGameObjectの中間点に設定します。
        newObject.transform.position = (pos1 + pos2) / 2;
    }

    public void InitialPool(Queue<GameObject> queue, GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)//プールのサイズだけ作成し不可視にしてQueueへ保存
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }

    public GameObject GetObject(GameObject prefab)
    {//Queueから可視化して取り出す。もし足りなければ生成してそのObjectをreturnする
        if (poolDictionary.TryGetValue(prefab, out var queue))
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
                return newObj;
            }
        }
        return null;
    }

    public void ReturnObject(GameObject obj)
    {//引数のGameObjectを不可視にしてQueueへ戻す
        if (poolDictionary.TryGetValue(obj, out var queue))
        {//objのpollを探して、それがあれば不可視にして戻す。
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }
}
