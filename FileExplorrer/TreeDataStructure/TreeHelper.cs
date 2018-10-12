using FileExplorerCmd.TreeDataStructure;
using FileExplorrer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorrer.TreeDataStructure
{
    public static class TreeHelper
    {

        public static TreeNode<string> Root { get; set; } = new TreeNode<string>("PC",null);
        public static TreeNode<string> CurrentPostition { get; set; }

        static TreeHelper()
        {
            foreach (var item in Directory.GetLogicalDrives())
            {
                Root.Add(item.ToString());
            }
            CurrentPostition = Root;
        }

        public static void ChangePositionTo(string path)
        {
            TreeNode<string> node = CurrentPostition.GetChildByValue(path);
            if (node != null)
            {
                if (node.Children.Count == 0)
                {
                    foreach (var item in Directory.GetDirectories(node.Value))
                    {
                        node.Add(item);
                    }
                }
                CurrentPostition = node;
            }          
        }

        public static void BackToAboveFolder()
        {
            if (CurrentPostition.Parent != null)
            {
                CurrentPostition = CurrentPostition.Parent;
            }
        }

        public static ObservableCollection<Item> GetItems()
        {
            ObservableCollection<Item> temp = new ObservableCollection<Item>();

            foreach (var item in CurrentPostition.Children)
            {
                temp.Add(new Item(item.Value,@"/Images/exe_file.png"));
            }

            return temp;
        }

    }
}
