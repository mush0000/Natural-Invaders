using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 prevPos;
    [SerializeField] float changeScrollDragThreshold = 0.5f;    //ドラッグへ切り替えるしきい値
    private GameObject parentObj;   //親情報取得用
    private bool isSelfDrag = false;    //自分自身がドラッグの対象かどうか

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        prevPos = transform.position;
        // ドラッグ前の親情報を取得しておく
        // parentObj = this.transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ方向の判定
        if (Mathf.Abs(prevPos.y - eventData.position.y) >= changeScrollDragThreshold)
        {
            // ドラッグドロップを有効にする処理
            isSelfDrag = true;
        }

        if (isSelfDrag)
        {
            // 親要素から切り離す
            // this.gameObject.transform.parent = null;
            this.gameObject.transform.SetParent(this.gameObject.transform.root, false);
            this.gameObject.transform.SetAsLastSibling();

        }

        // ドラッグ中は位置を更新する
        // transform.position = eventData.position;
        Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.position = worldPosition;

    }




    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置に戻す
        // transform.position = prevPos;
        // this.transform.SetParent(parentObj.transform);
    }

}
