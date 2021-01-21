using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
namespace FRIA
{

    public class PoolEditor
    {
        [MenuItem("GameObject/CreatePoolForThisItem/1")]
        public static void CreatePool_1()
        {
            CreatePool(1);
        }

        [MenuItem("GameObject/CreatePoolForThisItem/10")]
        public static void CreatePool_10()
        {
            CreatePool(10);
        }

        [MenuItem("GameObject/CreatePoolForThisItem/25")]
        public static void CreatePool_25()
        {
            CreatePool(25);
        }
        [MenuItem("GameObject/CreatePoolForThisItem/50")]
        public static void CreatePool_50()
        {
            CreatePool(50);
        }
        public static void CreatePool(int count)
        {
            GameObject sample = Selection.activeGameObject;
            if (sample == null)
            {
                Debug.LogError("You must select an item to create a Pool!");
                return;
            }
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            GameObject pkeep = GameObject.Find("PoolKeeper");
            if (!pkeep)
            {
                pkeep = new GameObject("PoolKeeper");
            }


            GameObject currentPool = GameObject.Find(string.Format("Pool : {0}",sample.name));
            if (!currentPool)
            {
                currentPool = new GameObject(string.Format("Pool : {0}", sample.name));
                currentPool.transform.SetParent(pkeep.transform);
            }

            for (int i = 0; i < count; i++)
            {
                PooledItem pi = GameObject.Instantiate(sample,currentPool.transform).AddComponent<PooledItem>();
                pi.gameObject.name = string.Format("{0}-{1}",sample.name, currentPool.transform.childCount);
                pi.alive = false;
                pi.original = sample;
            }
        }
    }
}