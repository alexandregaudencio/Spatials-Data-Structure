using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Tree { 
    public class TreeUseCase : MonoBehaviour
    {
           private TreeNode<string> treeRoot;
        void Start()
        {
            treeRoot = new TreeNode<string>("Root");

            var childA = treeRoot.AddChild("Child A");
            var childB = treeRoot.AddChild("Child B");

            childA.AddChild("A1");
            childA.AddChild("A2");
            childB.AddChild("B1");

            Debug.Log("TREE USECASE");

            //Visiting nodes de Debuging
            treeRoot.Traverse(OutputNodeValue);

        }

        private void OutputNodeValue(TreeNode<string> node)
        {
            Debug.Log(node.Data);
        }
    }
}