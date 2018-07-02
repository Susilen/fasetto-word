﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using fasetto_word.Infrastructure.Animation;

namespace fasetto_word.Infrastructure
{
    public class BasePage:Page
    {

        #region Properties
        /// <summary>
        /// The animation the play when the page is first load.
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; }= PageAnimation.SlideAndFadeInFromRight;
        /// <summary>
        /// The animation the play when page unload.
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; }= PageAnimation.SlideAndFadeOutToLeft;
        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSecond { get; set; } = 0.9f;

        #endregion

        #region Constructor

        public BasePage()
        {
            //if we are animation,hide to begin with.
            if (PageLoadAnimation == PageAnimation.None) Visibility = Visibility.Collapsed;

            Loaded += BasePage_Load;
        }

        #endregion

        #region Animation load and unload 

        /// <summary>
        /// First this page is load. preform any required animation.
        /// </summary>
        /// <returns></returns>
        private async void BasePage_Load(object sender, RoutedEventArgs e)
        {
            await AnimationIn();
        }
        #endregion
        /// <summary>
        /// animation this page in.
        /// </summary>
        /// <returns></returns>
        public async Task AnimationIn()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSecond);
                    break;
            }
            return;
        }
        /// <summary>
        /// Animation this page out.
        /// </summary>
        /// <returns></returns>
        public async Task AnimationOut()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSecond);
                    break;
            }
            return;
        }

    }
}