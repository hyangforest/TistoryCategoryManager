using System;

namespace TistoryCategoryManager;

public class Utilities
{
    #region Message
    public enum SaveStatus
    {
        INIT,
        RESET,
        SAVE,
        UPDATE,
        DELETE
    }

    public static string GetOKCancelSaveStatusMessage(SaveStatus status)
    {
        switch (status)
        {
            case SaveStatus.RESET:
                return "초기화하시겠습니까?";
            case SaveStatus.SAVE:
                return "저장하시겠습니까?";
            case SaveStatus.UPDATE:
                return "수정하시겠습니까?";
            case SaveStatus.DELETE:
                return "삭제하시겠습니까?";
            default:
                return string.Empty;
        }
    }
    #endregion
}
