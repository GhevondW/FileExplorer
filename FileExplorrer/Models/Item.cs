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

        public Item(string ap,bool isDirectory)
        {
            AbsolutePath = ap;
            IsDirectory = isDirectory;
            Resolution = ap.Substring(ap.LastIndexOf('.') + 1);
            Name = ap.Substring(ap.LastIndexOf('\\') + 1);
            SetImagePath();
        }
        
        private void SetImagePath()
        {
            if (Resolution == "pdf")
            {
                ImagePath = @"/Images/pdf.png";
            }
            else if (Resolution == "txt")
            {
                ImagePath = @"/Images/text.png";
            }
            else if (Resolution == "png" || Resolution == "jpg" || Resolution == "gif" || Resolution == "jpeg")
            {
                ImagePath = @"/Images/image.png";
            }
            else if (Resolution == "docx")
            {
                ImagePath = @"/Images/word.png";
            }
            else if (Resolution == "exe")
            {
                ImagePath = @"/Images/exe_file.png";
            }
            else if (Resolution == "mp3" || Resolution == "3gp" || Resolution == "m4p")
            {
                ImagePath = @"/Images/music.png";
            }
            else if (Resolution == "rar" || Resolution == "zip")
            {
                ImagePath = @"/Images/zip.png";
            }
            else if (Resolution == "dll")
            {
                ImagePath = @"/Images/dll.png";
            }
            else if (Resolution == "sys")
            {
                ImagePath = @"/Images/sys.png";
            }
            else if (Resolution == "css")
            {
                ImagePath = @"/Images/css.png";
            }
            else if (Resolution == "json")
            {
                ImagePath = @"/Images/json-file.png";
            }
            else if (Resolution == "js")
            {
                ImagePath = @"/Images/javascript.png";
            }
            else if (Resolution == "xml")
            {
                ImagePath = @"/Images/xml.png";
            }
            else
            {
                ImagePath = @"/Images/search.png";
            }
        }

    }
}
