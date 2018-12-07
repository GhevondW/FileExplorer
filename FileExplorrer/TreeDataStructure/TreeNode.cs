using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerCmd.TreeDataStructure
{
    public class TreeNode<T>
    {
        public T Value { get; private set; }
        public TreeNode<T> Parent { get; private set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value,TreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
            Children = new List<TreeNode<T>>();
        }

        public TreeNode<T> Add(T value)
        {
            TreeNode<T> node = new TreeNode<T>(value,this);
            Children.Add(node);
            return node;
        }

        public TreeNode<T> GetChildByValue(T value)
        {
            foreach (var item in Children)
            {
                if (item.Value.Equals(value))
                {
                    return item;
                }
            }
            return null;
        }

        public TreeNode<T> GetNodeByValue(T value)
        {
            TreeNode<T> node = null;
            node = this.GetChildByValue(value);
            if (node != null)
            {
                return node;
            }
            foreach (var item in Children)
            {
                node = item.GetChildByValue(value);
                if (node != null)
                {
                    return node;
                }
            }
            return null;
        }

        public void TraverseTreeNode(Action<T> action)
        {
            action(Value);
            foreach (var item in Children)
            {
                item.TraverseTreeNode(action);
            }
        }

        

    }
}
