using FileExplorerCmd.TreeDataStructure;
using FileExplorrer.Models;
using FileExplorrer.TreeDataStructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorrer.ViewModels
{
    class MainWindowViewModel:BindingHelper
    {

        private ObservableCollection<Item> _currentItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> CurrentItems
        {
            get { return _currentItems; }
            set
            {
                _currentItems = value;
                OnPropertyChanged(nameof(CurrentItems));
            }
        }
        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private string _folderName;
        public string FolderName
        {
            get { return _folderName; }
            set
            {
                _folderName = value;
                OnPropertyChanged(nameof(FolderName));
            }
        }


        public MainWindowViewModel()
        {
            CurrentItems = TreeHelper.GetItems();
            FolderName = string.Empty;
        }

        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ?? (_openCommand = new RelayCommand(obj => {
                    if (SelectedItem.IsDirectory)
                    {
                        CurrentItems = TreeHelper.ChangePositionTo(SelectedItem);
                    }
                    else
                    {
                        try
                        {
                            Process.Start(SelectedItem.AbsolutePath);
                        }
                        catch { }
                    }
                },
                obj => {
                    if (SelectedItem == null /*|| !SelectedItem.IsDirectory*/) { return false; } return true; }
                ));
            }
        }

        private RelayCommand _backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(obj => {
                    TreeHelper.BackToAboveFolder();
                    CurrentItems = TreeHelper.GetItems();
                }));
            }
        }

        private RelayCommand _createFolderCommand;
        public RelayCommand CreateFolderCommand
        {
            get
            {
                return _createFolderCommand ?? (_createFolderCommand = new RelayCommand(obj => {
                    string newFolderPath = TreeHelper.CurrentPostition.Value.AbsolutePath + "/" + FolderName;
                    Directory.CreateDirectory(newFolderPath);
                    CurrentItems = TreeHelper.UpdateData();
                    FolderName = string.Empty;
                },
                obj => {
                if (string.IsNullOrEmpty(FolderName)){ return false; } return true;
                }));
            }
        }

        private RelayCommand _deleteFolderCommand;
        public RelayCommand DeleteFolderCommand
        {
            get
            {
                return _deleteFolderCommand ?? (_deleteFolderCommand = new RelayCommand(obj => {
                    if (SelectedItem.IsDirectory)
                    {
                        DirectoryInfo dir = new DirectoryInfo(SelectedItem.AbsolutePath);
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo di in dir.GetDirectories())
                        {
                            di.Delete(true);
                        }
                        dir.Delete();
                    }
                    else
                    {
                        FileInfo file = new FileInfo(SelectedItem.AbsolutePath);
                        file.Delete();
                    }
                    CurrentItems = TreeHelper.UpdateData();
                },
                obj => {
                    if (SelectedItem == null || TreeHelper.CurrentPostition.Parent == null) { return false; }
                    return true;
                }));
            }
        }

    }
}
