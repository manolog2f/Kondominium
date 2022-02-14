using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities.Utilites
{
    public class MimeTypeEntity
    {
        public string Extension { get; set; }
        public string Type { get; set; }


        public List<MimeTypeEntity> MimeTypeList()
        {
            var lMimeType = new List<MimeTypeEntity>();

            lMimeType.Add(new MimeTypeEntity { Extension = ".aac", Type = "audio/aac" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".abw", Type = "application/x-abiword" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".arc", Type = "application/octet-stream" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".avi", Type = "video/x-msvideo" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".azw", Type = "application/vnd.amazon.ebook" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".bin", Type = "application/octet-stream" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".bz", Type = "application/x-bzip" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".bz2", Type = "application/x-bzip2" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".csh", Type = "application/x-csh" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".css", Type = "text/css" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".csv", Type = "text/csv" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".doc", Type = "application/msword" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".epub", Type = "application/epub+zip" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".gif", Type = "image/gif" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".htm", Type = "text/html" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".html", Type = "text/html" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ico", Type = "image/x-icon" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ics", Type = "text/calendar" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".jar", Type = "application/java-archive" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".jpeg", Type = "image/jpeg" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".jpg", Type = "image/jpeg" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".js", Type = "application/javascript" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".json", Type = "application/json" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".mid", Type = "audio/midi" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".midi", Type = "audio/midi" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".mpeg", Type = "video/mpeg" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".mpkg", Type = "application/vnd.apple.installer+xml" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".odp", Type = "application/vnd.oasis.opendocument.presentation" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ods", Type = "application/vnd.oasis.opendocument.spreadsheet" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".odt", Type = "application/vnd.oasis.opendocument.text" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".oga", Type = "audio/ogg" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ogv", Type = "video/ogg" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ogx", Type = "application/ogg" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".pdf", Type = "application/pdf" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ppt", Type = "application/vnd.ms-powerpoint" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".rar", Type = "application/x-rar-compressed" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".rtf", Type = "application/rtf" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".sh", Type = "application/x-sh" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".svg", Type = "image/svg+xml" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".swf", Type = "application/x-shockwave-flash" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".tar", Type = "application/x-tar" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".tif", Type = "image/tiff" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".tiff", Type = "image/tiff" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".ttf", Type = "font/ttf" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".vsd", Type = "application/vnd.visio" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".wav", Type = "audio/x-wav" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".weba", Type = "audio/webm" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".webm", Type = "video/webm" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".webp", Type = "image/webp" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".woff", Type = "font/woff" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".woff2", Type = "font/woff2" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".xhtml", Type = "application/xhtml+xml" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".xls", Type = "application/vnd.ms-excel" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".xml", Type = "application/xml" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".xul", Type = "application/vnd.mozilla.xul+xml" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".zip", Type = "application/zip" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".3gp", Type = "video/3gpp" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".3g2", Type = "video/3gpp2" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".7z", Type = "application/x-7z-compressed" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".png", Type = "image/png" });
            lMimeType.Add(new MimeTypeEntity { Extension = ".jpeg", Type = "image/jpeg" });

            return lMimeType;
        }

    }


}
