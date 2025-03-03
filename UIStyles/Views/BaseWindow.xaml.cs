using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UIStyles.UsercontrolApp;

namespace UIStyles.Themes
{
    /// <summary>
    /// Interaction logic for BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        // DependencyProperty cho TitleBarContent
        public static readonly DependencyProperty TitleBarContentProperty =
            DependencyProperty.Register("TitleBarContent", typeof(object), typeof(BaseWindow), new PropertyMetadata(null));

        public object TitleBarContent
        {
            get { return GetValue(TitleBarContentProperty); }
            set { SetValue(TitleBarContentProperty, value); }
        }
        public BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));

            if (TitleBarContent == null)
            {
                TitleBarContent = new TitlebarUC(); // Title bar mặc định
            }
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Thumb thumb = sender as Thumb;
            if (thumb == null) return;

            // Tính toán kích thước và vị trí mới
            double newWidth = Width;
            double newHeight = Height;
            double newLeft = Left;
            double newTop = Top;

            // Xử lý kéo các cạnh
            if (thumb.Name.Contains("Left"))
            {
                newWidth = Width - e.HorizontalChange;
                newLeft = Left + e.HorizontalChange;
            }
            if (thumb.Name.Contains("Right"))
            {
                newWidth = Width + e.HorizontalChange;
            }
            if (thumb.Name.Contains("Top"))
            {
                newHeight = Height - e.VerticalChange;
                newTop = Top + e.VerticalChange;
            }
            if (thumb.Name.Contains("Bottom"))
            {
                newHeight = Height + e.VerticalChange;
            }

            // Đảm bảo kích thước tối thiểu
            newWidth = System.Math.Max(MinWidth, newWidth);
            newHeight = System.Math.Max(MinHeight, newHeight);

            // Cập nhật kích thước và vị trí cửa sổ
            Width = newWidth;
            Height = newHeight;
            Left = newLeft;
            Top = newTop;
        }
    }
}
