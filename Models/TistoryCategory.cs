using System;

namespace TistoryCategoryManager;

public class TistoryCategory
{
    public int Id { get; set; }

    // 한글명
    public string? KORCategoryName { get; set; }
    // 영어명
    public string? ENGCategoryName { get; set; }    
    
    // 설명
    public string? Description { get; set; }

    // 정렬순서
    public int SortOrder { get; set; }

    // 사용여부
    public string UsageStatus { get; set; } = "N";

    // 등록일시
    public DateTime RegistrationDate { get; set;}

    // 수정일시
    public DateTime? ModificationDate { get; set;}

}
