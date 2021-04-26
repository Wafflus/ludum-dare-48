using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    public class CallList : MonoBehaviour
    {
        [Header("Calls")]
        [SerializeField] private List<Call> calls;

        [Header("Prefabs")]
        [SerializeField] private GameObject callPrefab;

        public void SetCallsList()
        {
            Clear();

            for (int i = calls.Count - 1; i >= 0; --i)
            {
                CallEntry callEntry = Instantiate(callPrefab, transform).GetComponent<CallEntry>();

                callEntry.Initialize(calls[i]);
            }
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void AddToList(Call call)
        {
            calls.Add(call);
        }
    }
}