using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NodeApp
{
    /// <summary>
    /// Helpers to animate pages
    /// </summary>
    public static class PageAnimations
    {
        public static async System.Threading.Tasks.Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, page.WindowWidth);

            sb.AddFadeIn(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay((int)(seconds * 1000));
        }

        public static async System.Threading.Tasks.Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, page.WindowWidth);

            sb.AddFadeOut(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay((int)(seconds * 1000));
        }
    }
}

