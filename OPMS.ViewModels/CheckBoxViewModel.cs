using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class CheckBoxViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
    }
}
