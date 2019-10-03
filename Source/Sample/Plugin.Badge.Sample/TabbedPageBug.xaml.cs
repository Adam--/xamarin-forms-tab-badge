using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.Badge.Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageBug : TabbedPage
    {
        private int leftAdds;
        private int rightAdds;

        public TabbedPageBug()
        {
            InitializeComponent();
        }

        private void RemoveTabLeftMenuItem_OnClicked(object sender, EventArgs e)
        {
            this.Children.RemoveAt(0);
        }

        private void AddTabLeftMenuItem_OnClicked(object sender, EventArgs e)
        {
            leftAdds++;
            this.Children.Insert(0, CreateContentPage($"L{leftAdds}"));
        }

        private void AddTabRightMenuItem_OnClicked(object sender, EventArgs e)
        {
            rightAdds++;
            this.Children.Add(CreateContentPage($"R{rightAdds}"));
        }

        private void RemoveTabRightMenuItem_OnClicked(object sender, EventArgs e)
        {
            this.Children.RemoveAt(this.Children.Count - 1);
        }

        private static ContentPage CreateContentPage(string title) =>
            new ContentPage
            {
                Title = title,
                Content = new Label
                {
                    HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = title,
                    TextColor = Color.Black
                }
            };
    }
}