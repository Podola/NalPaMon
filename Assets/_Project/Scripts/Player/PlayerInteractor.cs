using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public List<Interactable> detectedInteractables = new List<Interactable>();     // 감지된 Interactable 리스트
    private Interactable previousNearest = null;                                    // 이전 프레임에서 가장 가까웠던 Interactable (F 키 표시용)

    // 상호작용을 시도한다. (PlayerController에서 F키 입력 시)
    public void TryInteract()
    {
        // 가장 가까운 Interactable과 상호작용
        Interactable target = GetNearestInteractable();
        if(target != null)
        {
            target.OnInteract();
        }
    }

    // 감지된 Interactable 중, 플레이어와 가장 가까운 Interactable을 리턴한다. 없을 시 null을 반환한다.
    public Interactable GetNearestInteractable()
    {
        if(detectedInteractables.Count  == 0)
        {
            return null;
        }

        Interactable nearest = null;
        float nearestDistance = float.MaxValue;
        Vector2 playerPos = transform.position;

        foreach(var  interactable in detectedInteractables)
        {
            float distance = Vector2.Distance(playerPos, interactable.transform.position);
            if(distance < nearestDistance )
            {
                nearestDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }

    // 업데이트마다 플레이어에게 감지되었으며, 가장 가까운 Interactable의 Indicator(F)만을 활성화한다.
    private void FixedUpdate()
    {
        // 현재 감지된 Interactable이 없다면 리턴.
        if(detectedInteractables.Count == 0 )
        {
            // 단, 이전에 감지한 Interactable의 Indicator(F)가 있다면 비활성화 후 리턴.
            if( previousNearest != null )
            {
                previousNearest.HideIndicator();
                previousNearest = null;
            }

            return;
        }

        // 가장 가까운 Interactable
        Interactable currentNearest = GetNearestInteractable();

        // 1. 이전에 표시한 Indicator(F)가 없는 경우
        if(previousNearest == null)
        {
            // currentNearest의 Indicator(F)를 활성화 후 리턴.
            currentNearest.ShowIndicator();
            previousNearest = currentNearest;
            return;
        }

        // 2. 이전과 현재 표시하려는 Indicator(F)가 같은 경우
        if (previousNearest == currentNearest)
        {
            // 그냥 리턴
            return;
        }

        // 3. 이전에 표시한 Indicator(F)와 현재 표시하려는 Indicator(F)가 다른 경우
        previousNearest.HideIndicator();
        currentNearest.ShowIndicator();
        previousNearest = currentNearest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<Interactable>();
        if( interactable != null )
        {
            if (!detectedInteractables.Contains(interactable))
            {
                detectedInteractables.Add(interactable);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<Interactable>();
        if( interactable != null )
        {
            if(detectedInteractables.Contains(interactable))
            {
                detectedInteractables.Remove(interactable);
            }
        }
    }

}
