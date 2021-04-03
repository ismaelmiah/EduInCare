using System.ComponentModel.DataAnnotations;

namespace Foundation.Library.Enums
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3,
    }
    public enum Religion
    {
        Islam = 1,
        Hinduism = 2,
        Christianity = 3,
        Buddhism = 4,
        Others = 5
    }

    public enum BloodGroup
    {
        [Display(Name = "AB -")]
        AbNegative,
        [Display(Name = "AB +")]
        AbPositive,
        [Display(Name = "B +")]
        BPositive,
        [Display(Name = "B -")]
        BNegative,
        [Display(Name = "O +")]
        OPositive,
        [Display(Name = "O -")]
        ONegative,
        [Display(Name = "A -")]
        ANegative,
        [Display(Name = "A +")]
        APositive
    }
    public enum MaritalStatus
    {
        Married,
        Unmarried,
        Other
    }

    public enum ShiftType
    {
        [Display(Name = "First Shift")]
        FirstShift = 1,
        [Display(Name = "Second Shift")]
        SecondShift = 2
    }

    public enum WorkShift
    {
        Day = 1,
        Night = 2
    }

    public enum ResultType
    {
        Grade = 1,
        [Display(Name = "First Division")]
        FirstDivision = 2,
        [Display(Name = "Second Division")]
        SecondDivision = 3,
        [Display(Name = "Third Division")]
        ThirdDivision = 4,
        Appeared = 5,
        Enrolled = 6,
        Awarded = 7,
        Pass = 8,
        [Display(Name = "Do Not Mention")]
        DoNotMention = 9
    }

    public enum QualificationType
    {
        Ssc,
        Hsc,
        Bsc,
        Ba,
        Ma,
        Msc,
        Phd
    }
}