using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class Artwork
    {
        /// <summary>
        /// The average background color of the image.
        /// </summary>
        [BsonElement("bgColor")]
        public string BgColor { get; set; }

        /// <summary>
        /// The maximum height available for the image.
        /// </summary>
        [BsonElement("height")]
        [Required]
        public int Height { get; set; }

        /// <summary>
        /// The maximum width available for the image.
        /// </summary>
        [BsonElement("width")]
        [Required]
        public int Width { get; set; }

        /// <summary>
        /// The primary text color that may be used if the background color is displayed.
        /// </summary>
        [BsonElement("textColor1")]
        public string TextColor1 { get; set; }

        /// <summary>
        /// The secondary text color that may be used if the background color is displayed.
        /// </summary>
        [BsonElement("textColor2")]
        public string TextColor2 { get; set; }

        /// <summary>
        /// The URL to request the image asset. The image filename must be preceded by {w}x{h}, as placeholders for the width and height values as described above (for example, {w}x{h}bb.jpeg).
        /// </summary>
        [BsonElement("url")]
        [Required]
        public string Url { get; set; }
    }
}