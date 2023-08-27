using System;
using System.ComponentModel;

namespace TistoryCategoryManager;

public class spHabitCategory : INotifyPropertyChanged
{
    public int Id { get; set; }

    //private int _Id;

    //public int Id
    //{
    //    get { return _Id; }
    //    set
    //    {
    //        if (_Id != value)
    //        {
    //            _Id = value;
    //            OnPropertyChanged(nameof(Id));
    //        }
    //    }
    //}

    /// <summary>
    /// 한글명
    /// </summary>
    public string? KORCategoryName { get; set; }
    //public string? _KORCategoryName { get; set; }
    //public string? KORCategoryName
    //{
    //    get { return _KORCategoryName; }
    //    set
    //    {
    //        if (_KORCategoryName != value)
    //        {
    //            _KORCategoryName = value;
    //            OnPropertyChanged(nameof(KORCategoryName));
    //        }
    //    }
    //}

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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
