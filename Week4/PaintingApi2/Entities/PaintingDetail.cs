using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PaintingDetail
    {
        [Key]
        public int detailid { get; set; }
        public string paintingDate { get; set; }
        public string paintingTechnique { get; set; }
    }
}
