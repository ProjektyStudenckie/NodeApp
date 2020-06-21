using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace NodeApp
{
    public static class FrameworkElementAnimations
    {
        public static async System.Threading.Tasks.Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay((int)(seconds * 1000));
        }

        public static async System.Threading.Tasks.Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay((int)(seconds * 1000));
        }

        public static async System.Threading.Tasks.Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay((int)(seconds * 1000));
        }

        public static async System.Threading.Tasks.Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay((int)(seconds * 1000));
        }
    }
}
