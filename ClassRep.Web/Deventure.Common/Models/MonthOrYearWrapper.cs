using System;
using Deventure.Common.Interfaces;

namespace Deventure.Common.Models
{
    public class MonthOrYearWrapper : IDeventurePickerDialogDisplay, ISinglePkModel
    {
        private string mText;

        public MonthOrYearWrapper(string text)
        {
            Id = Guid.NewGuid();
            mText = text;
        }

        public string DisplayName { get { return mText; } set { mText = value; } }

        public Guid Id { get ; set ; }
    }
}
