using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace LabelBug.Platforms.iOS
{
    public static class IosHelpers
    {
        public static void AllowMultiLineTruncation()
        {
            static void UpdateMaxLines(Microsoft.Maui.Handlers.LabelHandler handler, ILabel label)
            {
                var textView = handler.PlatformView;
                if (label is Label controlsLabel
                    && textView.LineBreakMode == UILineBreakMode.TailTruncation && controlsLabel.MaxLines != -1)
                {
                    textView.Lines = controlsLabel.MaxLines;
                }
            };

            Label.ControlsLabelMapper.AppendToMapping(
               nameof(Label.LineBreakMode), UpdateMaxLines);

            Label.ControlsLabelMapper.AppendToMapping(
              nameof(Label.MaxLines), UpdateMaxLines);
        }
    }
}
