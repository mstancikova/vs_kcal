﻿using kcal.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class F_edit : ContentPage
    {
        public F_edit()
        {
            InitializeComponent();
            BindingContext = Model.Instance.CurentFood;
        }
    }
}
