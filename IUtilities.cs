using System;

namespace TistoryCategoryManager;

interface IUtilities
{
    #region DB
    void Save();
    void Update();
    void Delete();

    #endregion

    #region UI : CONTROL
    void ResetControl();
    void CheckControl(out bool isValid);

    void ReloadControl();
    #endregion
}


