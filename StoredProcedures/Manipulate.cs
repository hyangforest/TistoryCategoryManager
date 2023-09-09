using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using static TistoryCategoryManager.Utilities;

namespace TistoryCategoryManager;

public class Manipulate
{
    /// <summary>
    /// 카테고리 중복된 정렬순서이면 삽입 정렬해서 저장하기
    /// </summary>
    /// <param name="context"></param>
    /// <param name="habitCategory"></param>
    public static void InsertWithParametersAndUpdateSortOrder(AppDbContext context, HabitCategory habitCategory)
    {
        if (context != null)
        {
            var Id = new SqlParameter("@Id", habitCategory.Id);
            var KORCategoryName = new SqlParameter("@KORCategoryName", habitCategory.KORCategoryName);
            var Description = new SqlParameter("@Description", habitCategory.Description);
            var SortOrder = new SqlParameter("@SortOrder", habitCategory.SortOrder);
            var UsageStatus = new SqlParameter("@UsageStatus", habitCategory.UsageStatus);
            var OpenStatus = new SqlParameter("@OpenStatus", habitCategory.OpenStatus);

            context.Database.ExecuteSqlRaw($"EXEC sp_SaveChange_HabitCategory @Id, @KORCategoryName, @Description, @SortOrder, @UsageStatus, @OpenStatus"
                                                                  , Id
                                                                  , KORCategoryName
                                                                  , Description
                                                                  , SortOrder
                                                                  , UsageStatus
                                                                  , OpenStatus);
        }
    }
}
