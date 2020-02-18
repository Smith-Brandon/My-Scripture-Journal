using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace My_Scripture_Journal.Model
{
    public class ScriptureModel
    {
        public int ID { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public String dateAdded = DateTime.Now.ToString("MM/dd/yyyy");


    }
}
