using System.Collections;
using UnityEngine;

public class EnemySlotArrayControl : AbstractSlotArrayControl
{

    [SerializeField] int numRandomSelections = 1;
    [SerializeField] float timeBetweenRandomSelections = 0;

    public override void MakeSelection()
    {
        StartCoroutine(RandomSelection());
    }

    private IEnumerator RandomSelection()
    {
        yield return StartCoroutine(AnimateRandomSelection());

        base.SubmitSlots();
    }

    private IEnumerator AnimateRandomSelection()
    {
        int selections = 0;
        WaitForSeconds waitTimeBetweenRandomSelections = new WaitForSeconds(timeBetweenRandomSelections);

        while (selections < numRandomSelections)
        {
            foreach (SlotState slotState in base.SlotStates)
            {
                slotState.Random(allowEmptyAction: false);
            }
            selections++;
            yield return waitTimeBetweenRandomSelections;
        }
    }

}
