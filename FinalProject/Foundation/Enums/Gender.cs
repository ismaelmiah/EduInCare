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

    public enum MaritalStatus
    {
        Married,
        Unmarried,
        Other
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

}