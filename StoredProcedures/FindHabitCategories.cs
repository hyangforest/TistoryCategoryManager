using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace TistoryCategoryManager;

public class FindHabitCategories
{
    public static List<spHabitCategory>? FindHabitCategoriesFromSql(AppDbContext context)
    {
        return context?.sp_HabitCategories?.FromSql($"EXEC sp_Get_HabitCategories").ToList();
    }

    // 파라미터 있을거임..추가할거 분명
    //public static List<spHabitCategory>? FindStudentsFromSql(AppDbContext context, string searchFor)
    //{
       // return context?.sp_HabitCategories?.FromSql($"FindStudents {searchFor}").ToList();

        //_context.sp_HabitCategories?.FromSql($"EXEC sp_Get_HabitCategories").ToList();
    //}
}
