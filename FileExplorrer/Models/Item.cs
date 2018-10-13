using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorrer.Models
{
    public class Item : BindingHelper
    {
        private string _absolutePath;
        public string AbsolutePath
        {
            get { return _absolutePath; }
            set
            {
                _absolutePath = value;
                OnPropertyChanged(nameof(AbsolutePath));
            }
        }
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public bool IsDirectory { get; set; }

        private string _resolution;
        public string Resolution
        {
            get { return _resolution; }
            set
            {
                _resolution = value;
                OnPropertyChanged(nameof(Resolution));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        
        public Item()
        {
            Name = "Root";
        }

        public Item(string ap,string ip,bool isDirectory)
        {
            AbsolutePath = ap;
            ImagePath = ip;
            IsDirectory = isDirectory;
            Resolution = ap.Substring(ap.LastIndexOf('.')+1);
            Name = ap.Substring(ap.LastIndexOf('\\') + 1);
        }
        

    }
}
