using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection; 

namespace ULaw.ApplicationProcessor.Enums
{
    public enum DegreeGradeEnum : int
    {
        [DescriptionAttribute("1st")]
        first,
        [DescriptionAttribute("2:1")]
        twoOne,
        [DescriptionAttribute("2:2")]
        twoTwo,
        [DescriptionAttribute("3rd")]
        third
    }
    
    public enum DegreeSubjectEnum : int
    {
        [DescriptionAttribute("Law")]
        law,
        [DescriptionAttribute("Law and Business")]
        lawAndBusiness,
        [DescriptionAttribute("Maths")]
        maths,
        [DescriptionAttribute("English")]
        English
    }

}
