using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Painter
    {
        [Key]
        public int painterId { get; set; }
        public string painter { get; set; }
        public string aboutPainter { get; set; }
        public string movement { get; set; }
    }
}
