using System;

namespace TistoryCategoryManager;

public class HabitCategory
{
    public int Id { get; set; }

    /// <summary>
    /// 한글명
    /// </summary>
    public string? KORCategoryName { get; set; }
    
    /// <summary>
    /// 설명
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 정렬순서
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// 사용여부 
    /// </summary>
    public string UsageStatus { get; set; } = "Y";

    /// <summary>
    /// 공개여부
    /// 개인적인 부분이 많아서 초기값 N
    /// </summary>
    public string OpenStatus { get; set; } = "N"; 

    /// <summary>
    /// 등록일시
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// 수정일시
    /// </summary>
    public DateTime? ModificationDate { get; set; }
}
