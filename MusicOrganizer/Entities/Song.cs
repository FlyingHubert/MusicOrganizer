using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.Entities
{
    public class Song
    {
        public int SongId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Interpret { get; set; }

        [MaxLength(200)]
        public string Album { get; set; }

        public int? LP { get; set; }

        public int? single { get; set; }

        public string Art { get; set; }

        
        public int? CD { get; set; }

        public int? Jahr { get; set; }

        [MaxLength(200)]
        public string Komponist { get; set; }

        public string Bemerkungen { get; set; }
    }
}
