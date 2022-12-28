using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MobilePhone.Helpers.Enums;

public enum Provider : int
{
    [Display(Name = "Bakcell")]
    Bakcell = 055,

    [Display(Name = "Bakcell")]
    Bakcell2 = 099,

    [Display(Name = "Nar")]
    Nar = 077,

    [Display(Name = "Nar")]
    Nar2 = 077,

    [Display(Name = "Naxtel")]
    NaxTel = 060,

    [Display(Name = "Azercell")]
    AzerCell = 050,

    [Display(Name = "Azercell")]
    AzerCell2 = 051

}
