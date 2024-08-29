using System;

namespace SimplePopupManager
{
    public interface IPopup : IPopupInitializationService
    {
        event Action<string> OnCloseButtonClick;
        string PopupName { get; }
    }
}