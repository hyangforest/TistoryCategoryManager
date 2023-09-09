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
    /// 습관 카테고리 중복된 정렬순서이면 삽입 정렬해서 저장/수정하기
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

    /// <summary>
    /// 습관 카테고리 삭제 및 정렬순서 정렬
    /// </summary>
    /// <param name="context"></param>
    /// <param name="habitCategory"></param>
    public static void DeleteWithParametersAndUpdateSortOrder(AppDbContext context, HabitCategory habitCategory)
    {
        if (context != null)
        {
            var Id = new SqlParameter("@Id", habitCategory.Id);
            
            context.Database.ExecuteSqlRaw($"EXEC sp_Delete_HabitCategory @Id", Id);
        }
    }

    /// <summary>
    /// 개발 카테고리 중복된 정렬순서이면 삽입 정렬해서 저장/수정하기
    /// </summary>
    /// <param name="context"></param>
    /// <param name="habitCategory"></param>
    public static void InsertWithParametersAndUpdateSortOrder(AppDbContext context, ImprovementCategory improvementCategory)
    {
        if (context != null)
        {
            var Id = new SqlParameter("@Id", improvementCategory.Id);
            var ENGCategoryName = new SqlParameter("@ENGCategoryName", improvementCategory.ENGCategoryName);
            var KORCategoryName = new SqlParameter("@KORCategoryName", improvementCategory.KORCategoryName);
            var Description = new SqlParameter("@Description", improvementCategory.Description);
            var SortOrder = new SqlParameter("@SortOrder", improvementCategory.SortOrder);
            var UsageStatus = new SqlParameter("@UsageStatus", improvementCategory.UsageStatus);
            var OpenStatus = new SqlParameter("@OpenStatus", improvementCategory.OpenStatus);

            context.Database.ExecuteSqlRaw($"EXEC sp_SaveChange_ImprovementCategory @Id, @ENGCategoryName, @KORCategoryName, @Description, @SortOrder, @UsageStatus, @OpenStatus"
                                                                  , Id
                                                                  , ENGCategoryName
                                                                  , KORCategoryName
                                                                  , Description
                                                                  , SortOrder
                                                                  , UsageStatus
                                                                  , OpenStatus);
        }
    }

    /// <summary>
    /// 개발 카테고리 삭제 및 정렬순서 정렬
    /// </summary>
    /// <param name="context"></param>
    /// <param name="habitCategory"></param>
    public static void DeleteWithParametersAndUpdateSortOrder(AppDbContext context, ImprovementCategory improvementCategory)
    {
        if (context != null)
        {
            var Id = new SqlParameter("@Id", improvementCategory.Id);

            context.Database.ExecuteSqlRaw($"EXEC sp_Delete_ImprovementCategory @Id", Id);
        }
    }
}
