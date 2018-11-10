using FileExplorerCmd.TreeDataStructure;
using FileExplorrer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorrer.TreeDataStructure
{
    public static class TreeHelper
    {

        public static TreeNode<Item> Root { get; set; } = new TreeNode<Item>(new Item(),null);
        public static TreeNode<Item> CurrentPostition { get; set; }

        static TreeHelper()
        {
            foreach (var item in Directory.GetLogicalDrives())
            {
                Item temp = new Item(item, "/Images/hard-drive.png", true);
                string[] arr = item.Split('\\');
                temp.Name = string.Format("Local Disk({0})", arr[arr.Length - 2]);
                Root.Add(temp);
            }
            CurrentPostition = Root;
        }

        public static ObservableCollection<Item> ChangePositionTo(Item goTo)
        {
            TreeNode<Item> node = CurrentPostition.GetChildByValue(goTo);
            if (node != null)
            {
                if (node.Children.Count == 0)
                {
                    try
                    {
                        foreach (var item in Directory.GetDirectories(goTo.AbsolutePath))
                        {
                            node.Add(new Item(item, "/Images/folder_closed.png", true));
                        }
                        foreach (var item in Directory.GetFiles(goTo.AbsolutePath))
                        {
                            node.Add(new Item(item/*, "/Images/exe_file.png"*/, false));
                        }
                    }
                    catch { }
                }
                CurrentPostition = node;
            }
            return GetItems();
        }

        public static ObservableCollection<Item> BackToAboveFolder()
        {
            if (CurrentPostition.Parent != null)
            {
                CurrentPostition = CurrentPostition.Parent;
            }
            return GetItems();
        }

        public static ObservableCollection<Item> GetItems()
        {
            ObservableCollection<Item> temp = new ObservableCollection<Item>();

            foreach (var item in CurrentPostition.Children)
            {
                temp.Add(item.Value);
            }

            return temp;
        }

    }
}
