using FileExplorerCmd.TreeDataStructure;
using FileExplorrer.Models;
using FileExplorrer.TreeDataStructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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


        public MainWindowViewModel()
        {
            CurrentItems = TreeHelper.GetItems();           
        }

        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ?? (_openCommand = new RelayCommand(obj => {
                    CurrentItems = TreeHelper.ChangePositionTo(SelectedItem);                    
                },
                obj => {
                    if (SelectedItem == null || !SelectedItem.IsDirectory) { return false; } return true; }
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

    }
}
