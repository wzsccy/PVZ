using UnityEngine;
using DG.Tweening;

public class Sun : MonoBehaviour
{
    public float moveDurtion = 1;
    public int point = 50;//收集阳光值

    
    public void LinearTo( Vector3 targetPos)
    {
        transform.DOMove(targetPos,moveDurtion);
    }
    public void JumpTo(Vector3 targePos)
    {
        targePos.z = -1;
        Vector3 centerPos=(transform.position + targePos)/2;
        float distance=Vector3.Distance(transform.position, targePos);
        centerPos.y+=(distance/2);
        transform.DOPath(new Vector3[] {transform.position,centerPos,targePos},moveDurtion,PathType.CatmullRom).SetEase(Ease.OutQuad);//制作阳光抛物线,先快后慢

    }
     void OnMouseDown()
    {
        
        transform.DOMove(SunManager.instance.GetSunPointTextPosition(),moveDurtion).SetEase(Ease.OutQuad).OnComplete(()=> { Destroy(this.gameObject);
        SunManager.instance.AddSun(point);
        });
    }
}
