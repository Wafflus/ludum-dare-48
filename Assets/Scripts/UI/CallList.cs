using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    public class CallList : MonoBehaviour
    {
        [field: Header("Calls")]
        [field: SerializeField] public List<Call> Calls { get; set; }

        [Header("Prefabs")]
        [SerializeField] private GameObject callPrefab;

        public void SetCallsList()
        {
            Clear();

            foreach (Call call in Calls)
            {
                CallEntry callEntry = Instantiate(callPrefab, transform).GetComponent<CallEntry>();

                callEntry.Initialize(call);
            }
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}