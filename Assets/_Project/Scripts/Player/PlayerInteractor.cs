using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public List<Interactable> detectedInteractables = new List<Interactable>();     // ������ Interactable ����Ʈ
    private Interactable previousNearest = null;                                    // ���� �����ӿ��� ���� ������� Interactable (F Ű ǥ�ÿ�)

    // ��ȣ�ۿ��� �õ��Ѵ�. (PlayerController���� FŰ �Է� ��)
    public void TryInteract()
    {
        // ���� ����� Interactable�� ��ȣ�ۿ�
        Interactable target = GetNearestInteractable();
        if(target != null)
        {
            target.OnInteract();
        }
    }

    // ������ Interactable ��, �÷��̾�� ���� ����� Interactable�� �����Ѵ�. ���� �� null�� ��ȯ�Ѵ�.
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

    // ������Ʈ���� �÷��̾�� �����Ǿ�����, ���� ����� Interactable�� Indicator(F)���� Ȱ��ȭ�Ѵ�.
    private void FixedUpdate()
    {
        // ���� ������ Interactable�� ���ٸ� ����.
        if(detectedInteractables.Count == 0 )
        {
            // ��, ������ ������ Interactable�� Indicator(F)�� �ִٸ� ��Ȱ��ȭ �� ����.
            if( previousNearest != null )
            {
                previousNearest.HideIndicator();
                previousNearest = null;
            }

            return;
        }

        // ���� ����� Interactable
        Interactable currentNearest = GetNearestInteractable();

        // 1. ������ ǥ���� Indicator(F)�� ���� ���
        if(previousNearest == null)
        {
            // currentNearest�� Indicator(F)�� Ȱ��ȭ �� ����.
            currentNearest.ShowIndicator();
            previousNearest = currentNearest;
            return;
        }

        // 2. ������ ���� ǥ���Ϸ��� Indicator(F)�� ���� ���
        if (previousNearest == currentNearest)
        {
            // �׳� ����
            return;
        }

        // 3. ������ ǥ���� Indicator(F)�� ���� ǥ���Ϸ��� Indicator(F)�� �ٸ� ���
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
