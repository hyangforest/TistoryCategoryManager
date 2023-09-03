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

    public static string GetOKCancelSaveStatusMessage(SaveStatus status, string message)
    {
        switch (status)
        {
            case SaveStatus.RESET:
                return string.Format("{0} 초기화하시겠습니까?", message);
            case SaveStatus.SAVE:
                return string.Format("{0} 저장하시겠습니까?", message);
            case SaveStatus.UPDATE:                          
                return string.Format("{0} 수정하시겠습니까?", message);
            case SaveStatus.DELETE:                          
                return string.Format("{0} 삭제하시겠습니까?", message);
            default:
                return message;
        }
    }
    #endregion
}
