using ClipboardDB.Models;
using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Context
{
    public class SerializationContext : BaseContext, IDisposable
    {
        private SharpSerializer _serializer;
        public List<ClipboardItem> ClipBoardItems;


        public SerializationContext()
        {
            this.ClipBoardItems = new List<ClipboardItem>();
            var isEncryptionEnabled = true;
            var encryptionConfig = ConfigurationManager.AppSettings[Constants.DB.DB_Encryption_Enabled];
            if(encryptionConfig != null)
            {
                bool.TryParse(encryptionConfig, out isEncryptionEnabled);
            }
            this._serializer = new SharpSerializer(isEncryptionEnabled);

            GetAllItems();
        }

        private void GetAllItems()
        {
            
            //Load Clipboard Items
            using (var fs = new FileStream(GetFilePath(), FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    this.ClipBoardItems = (List<ClipboardItem>)_serializer.Deserialize(fs);
                }
            }
        }

        private string GetFilePath()
        {
            var value = ConfigurationManager.AppSettings[Constants.DB.DB_File_Path];
            value = value.Replace("%AppData%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            if (value == null) { return "LocalDB.Default.xml"; }
            if (!File.Exists(value))
            {
                var foldersOnly = value.Substring(0, value.LastIndexOf(@"\"));
                Directory.CreateDirectory(foldersOnly);
            }
            return value;
        }

        public string FilePath(string name) { return $"{name}s.DB.xml"; }

        public void Dispose()
        {
            this.Dispose();
        }

        public override bool SaveChanges()
        {
            using (var fs = new FileStream(GetFilePath(), FileMode.Create))
            {
                _serializer.Serialize(ClipBoardItems, fs);
            }

            return true;
        }
    }
}
