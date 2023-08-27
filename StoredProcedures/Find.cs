using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TistoryCategoryManager;

public class Find
{
    public static List<spHabitCategory>? FindStoredProcedureNameFromSql(AppDbContext context, string spName)
    {
        return context?.sp_HabitCategories?.FromSql($"EXEC {spName}").ToList();
    }
}
