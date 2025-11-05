using System;

namespace QuanLyNganSach
{
    public class ComboBoxItem
    {
        public string DisplayText { get; set; }
        public string Value { get; set; }
        public bool IsTongQuat { get; set; }

        public ComboBoxItem(string displayText, string value, bool isTongQuat = false)
        {
            DisplayText = displayText;
            Value = value;
            IsTongQuat = isTongQuat;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}