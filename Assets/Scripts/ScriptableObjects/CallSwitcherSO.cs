using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewCallSwitcher", menuName = "Artistas/Call Switcher/New Call Switcher")]
    public class CallSwitcherSO : ScriptableObject
    {
        public List<string> numbers;
        public List<Call> calls;

        public void SwitchCall(Call newCall)
        {
            string number = newCall.callerName == "You" ? newCall.receiverNumber : newCall.callerNumber;

            int numberIndex = numbers.IndexOf(number);

            if (numberIndex == -1)
            {
                return;
            }

            calls[numberIndex] = newCall;
        }

        public Call GetCall(string number)
        {
            int numberIndex = numbers.IndexOf(number);

            if (numberIndex == -1)
            {
                return null;
            }

            return calls[numberIndex];
        }

        public void RemoveCall(Call call)
        {
            string number = call.callerName == "You" ? call.receiverNumber : call.callerNumber;

            int numberIndex = numbers.IndexOf(number);

            if (numberIndex == -1)
            {
                return;
            }

            calls[numberIndex] = null;
        }
    }
}