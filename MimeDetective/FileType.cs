using System;
using System.Linq;

namespace MimeDetective
{
    /// <summary>
    /// Little data structure to hold information about file types. 
    /// Holds information about binary header at the start of the file
    /// </summary>
    public class FileType
    {
        /*internal byte?[] Header { get; set; }    // most of the times we only need first 8 bytes, but sometimes extend for 16
        internal int HeaderOffset { get; set; }
        internal string Extension { get; set; }
        internal string Mime { get; set; }*/

        public byte?[] Header { get; set; }
        public int HeaderOffset { get; set; }
        public string Extension { get; set; }
        public string Mime { get; set; }
        public string[] AlternateExtensions = new string[0];

        public FileType()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> class.
        /// Default construction with the header offset being set to zero by default
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        public FileType(byte?[] header, string extension, string mime)
        {
            Header = header;
            Extension = extension;
            Mime = mime;
            HeaderOffset = 0;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> struct.
        /// Takes the details of offset for the header
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        /// <param name="alternateExtensions">Other valid extensions (ex: jpeg in addition to jpg, tiff in addition to tif)</param>
        public FileType(byte?[] header, string extension, string mime, string[] alternateExtensions)
        {
            this.Header = null;
            this.Header = header;
            this.Extension = extension;
            this.Mime = mime;
            this.AlternateExtensions = alternateExtensions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> struct.
        /// Takes the details of offset for the header
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="offset">The header offset - how far into the file we need to read the header</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        public FileType(byte?[] header, int offset, string extension, string mime)
        {
            this.Header = null;
            this.Header = header;
            this.HeaderOffset = offset;
            this.Extension = extension;
            this.Mime = mime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> struct.
        /// Takes the details of offset for the header
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="offset">The header offset - how far into the file we need to read the header</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        /// <param name="alternateExtensions">Other valid extensions (ex: jpeg in addition to jpg, tiff in addition to tif)</param>
        public FileType(byte?[] header, int offset, string extension, string mime, string[] alternateExtensions)
        {
            this.Header = null;
            this.Header = header;
            this.HeaderOffset = offset;
            this.Extension = extension;
            this.Mime = mime;
            this.AlternateExtensions = alternateExtensions;
        }

        public override bool Equals(object other)
        {
            if (!(other is FileType)) return false;

            FileType otherType = (FileType)other;

            if (this.Extension == otherType.Extension && this.Mime == otherType.Mime) return true;

            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Extension;
        }

        public string[] ValidExtensions()
        {
            return new string[] {Extension}.Concat(AlternateExtensions).ToArray();
        }

        /// <summary>
        /// Is the extension of this file type what we are looking for?
        /// </summary>
        /// <param name="expectedExtension"></param>
        /// <returns></returns>
        public bool IsValidExtension(string expectedExtension)
        {
            expectedExtension = expectedExtension.ToLower().Replace(".", "");
            return ValidExtensions().Contains(expectedExtension);
        }
    }
}
