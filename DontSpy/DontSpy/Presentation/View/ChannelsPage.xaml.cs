﻿using DontSpy.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DontSpy.Presentation.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChannelsPage : ContentPage
	{
	    public ChannelsPageViewModel ViewModel { get; }

        public ChannelsPage ()
		{
			InitializeComponent ();
		    ViewModel = new ChannelsPageViewModel();
		    ViewModel.SetView(this);
		    BindingContext = ViewModel;
        }
	}
}