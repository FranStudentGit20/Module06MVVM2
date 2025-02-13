﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module06MVVM.Model;
using Module06MVVM.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Module06MVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployeePage : ContentPage
    {
        EmployeeViewModel viewModel;
        public ShowEmployeePage()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
        }

        private void EmployeePage()
        {
            var res = viewModel.GetAllEmployees().Result;
            lstData.ItemsSource = res;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            EmployeePage();
        }

        private void btnAddRecord(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EmployeeView());
        }

        private async void lsdata_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                EmployeeModel obj = (EmployeeModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "update", "Delete");


                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new EmployeeView(obj));
                        break;

                    case "Delete":
                        viewModel.DeleteEmployee(obj);
                        EmployeePage();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}