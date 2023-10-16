using Android.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelBug.Platforms.Android
{
    public static class AndroidHelpers
    {
        public static void AllowMultiLineTruncation()
        {
            static void UpdateMaxLines(Microsoft.Maui.Handlers.LabelHandler handler, ILabel label)
            {
                var textView = handler.PlatformView;
                if (label is Label controlsLabel
                    && textView.Ellipsize == TextUtils.TruncateAt.End && controlsLabel.MaxLines != -1)
                {
                    textView.SetMaxLines(controlsLabel.MaxLines);
                }
            };

            Label.ControlsLabelMapper.AppendToMapping(
               nameof(Label.LineBreakMode), UpdateMaxLines);

            Label.ControlsLabelMapper.AppendToMapping(
              nameof(Label.MaxLines), UpdateMaxLines);
        }
    }
}
