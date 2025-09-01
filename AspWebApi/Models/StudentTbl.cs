using System;
using System.Collections.Generic;

namespace AspWebApi.Models;

public partial class StudentTbl
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public int Standard { get; set; }

    public string FatherName { get; set; } = null!;
}
