using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Foundation.Library.BaseServices;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IStudentAttendanceService : IBaseService<StudentAttendance>
    {
        (int total, int totalDisplay, IList<StudentAttendance> records) GetListForDataTable(Guid courseId, int pageIndex,
            int pageSize, string searchText, string orderBy);

        StudentAttendance GetAttendance(Expression<Func<StudentAttendance, bool>> filter = null);
    }
}