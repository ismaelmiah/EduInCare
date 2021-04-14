﻿using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IExamRuleRuleService
    {
        void AddExamRule(ExamRules examRule);
        (int total, int totalDisplay, IList<ExamRules> records) GetExamRuleList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        ExamRules GetExamRule(Guid id);
        void Update(ExamRules examRule);
        IList<ExamRules> GetExamRules();
    }
}