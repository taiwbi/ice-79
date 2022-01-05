using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ice_79
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pop_Up : ContentPage
    {
        public Pop_Up()
        {
            InitializeComponent();
            Pop_Up_Load();
        }
        /// <summary>
        /// Loads the Pop-up data from the android <c>PopUPData</c> class, save yout content in this class and then call the pop-up page to show your custom pop-up.
        /// </summary>
        private void Pop_Up_Load()
        {
            PopTitleLabel.Text = PopUPData.Title;
            PopShortexLabel.Text = PopUPData.Shortexplan;
            PopLongexLabel.Text = PopUPData.Longexplan;
        }

        /// <summary>
        /// Turns back after tapping on close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete]
        private async void CloseButt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}