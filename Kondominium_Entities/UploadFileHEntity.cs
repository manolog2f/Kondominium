using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class UploadFileHEntity
    {
        public int UploadFileHId { get; set; }
        public string FileName { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string UserId { get; set; }
        public Nullable<int> Estado { get; set; }
    }
    
}
