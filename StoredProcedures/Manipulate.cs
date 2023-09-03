using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TistoryCategoryManager;

public class Manipulate
{
    public static void InsertWithParametersAndUpdateSortOrder(AppDbContext context, string spName, HabitCategory parameters)
    {

        //context?.sp_HabitCategories?.FromSql($"EXEC {spName}").ToList();

    }
}
