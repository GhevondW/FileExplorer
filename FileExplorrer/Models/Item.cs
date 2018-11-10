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
            if (Resolution == "pdf" || Resolution == "PDF")
            {
                ImagePath = @"/Images/pdf.png";
            }
            else if (Resolution == "txt" || Resolution == "TXT")
            {
                ImagePath = @"/Images/text.png";
            }
            else if (Resolution == "png" || Resolution == "jpg" || Resolution == "gif" || Resolution == "jpeg" ||
                Resolution == "PNG" || Resolution == "JPG" || Resolution == "GIF" || Resolution == "JPEG")
            {
                ImagePath = @"/Images/image.png";
            }
            else if (Resolution == "doc" || Resolution == "DOC" || Resolution == "DOCX" || Resolution == "docx")
            {
                ImagePath = @"/Images/word.png";
            }
            else if (Resolution == "exe" || Resolution == "EXE")
            {
                ImagePath = @"/Images/exe_file.png";
            }
            else if (Resolution == "mp3" || Resolution == "3gp" || Resolution == "m4p" ||
                Resolution == "MP3" || Resolution == "3GP" || Resolution == "M4P")
            {
                ImagePath = @"/Images/music.png";
            }
            else if (Resolution == "rar" || Resolution == "zip" ||
                Resolution == "RAR" || Resolution == "ZIP")
            {
                ImagePath = @"/Images/zip.png";
            }
            else if (Resolution == "dll" || Resolution == "DLL")
            {
                ImagePath = @"/Images/dll.png";
            }
            else if (Resolution == "sys" || Resolution == "SYS")
            {
                ImagePath = @"/Images/sys.png";
            }
            else if (Resolution == "css" || Resolution == "CSS")
            {
                ImagePath = @"/Images/css.png";
            }
            else if (Resolution == "json" || Resolution == "JSON")
            {
                ImagePath = @"/Images/json-file.png";
            }
            else if (Resolution == "js" || Resolution == "JS")
            {
                ImagePath = @"/Images/javascript.png";
            }
            else if (Resolution == "xml" || Resolution == "XML")
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
