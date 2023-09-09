using System;
using System.ComponentModel;

namespace TistoryCategoryManager;

public class spImprovementCategory 
{
    public int Id { get; set; }
    
    /// <summary>
    /// 카테고리명
    /// </summary>
    public string? ENGCategoryName { get; set; }

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
    public string? Usage { get; set; } 

    /// <summary>
    /// 공개여부
    /// 개인적인 부분이 많아서 초기값 N
    /// </summary>
    public string OpenStatus { get; set; } = "N";

    public string? Open { get; set; }

    /// <summary>
    /// 등록일시
    /// </summary>
    public string? RegistrationDate { get; set; }

    /// <summary>
    /// 수정일시
    /// </summary>
    public string? ModificationDate { get; set; }
}
