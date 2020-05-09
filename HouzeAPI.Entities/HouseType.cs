using System;
using System.ComponentModel.DataAnnotations;

namespace HouzeAPI.Entities
{
    public enum HouseType
    {
        Flat,

        [Display(Name = "Self Contain")]
        SelfContain,

        [Display(Name = "One Room")]
        OneRoom,

        Other

    }
}
