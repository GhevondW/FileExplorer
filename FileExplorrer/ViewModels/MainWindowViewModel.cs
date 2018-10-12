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

        public ObservableCollection<Item> CurrentItems { get; set; } = new ObservableCollection<Item>();
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
                    
                    MessageBox.Show("Hello Open");
                    SelectedItem = null;
                },
                obj => { if (SelectedItem == null) { return false; } return true; }
                ));
            }
        }

        private RelayCommand _backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(obj => {
                    MessageBox.Show("Hello back");
                    SelectedItem = null;
                }));
            }
        }

    }
}
