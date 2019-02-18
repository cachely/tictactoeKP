using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TicTacToeKable
{
    public partial class BoardPage : ContentPage
    {
        public BoardPage()
        {
            InitializeComponent();
            ClearValues();
        }

        public async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;

            var response = await DisplayActionSheet("Choose X or O", "Cancel", null, new string[2] { "X", "O" });

            if (response != null && !response.Equals("Cancel"))
            {
                label.Text = response;
            }

            if (IsWinningMove())
            { 
                await DisplayAlert("We have a winner!", response + "wins!!!", "OK");
                var playAgain = await DisplayActionSheet("Would you like to play again?", "Cancel", null, new string[2] { "yes", "no" });

                if (playAgain.Equals("yes"))
                {
                    ClearValues();
                }
            }
        }

        private void ClearValues()
        {
            this.FindByName<Label>("LAA").Text = string.Empty;
            this.FindByName<Label>("LAB").Text = string.Empty;
            this.FindByName<Label>("LAC").Text = string.Empty;
            this.FindByName<Label>("LBA").Text = string.Empty;
            this.FindByName<Label>("LBB").Text = string.Empty;
            this.FindByName<Label>("LBC").Text = string.Empty;
            this.FindByName<Label>("LCA").Text = string.Empty;
            this.FindByName<Label>("LCB").Text = string.Empty;
            this.FindByName<Label>("LCC").Text = string.Empty;
        }

        private bool IsWinningMove()
        {
            return ColumnAIsWinning() || ColumnBIsWinning() || ColumnCIsWinning() ||
                RowAIsWinning() || RowBIsWinning() || RowCIsWinning() || DiagAWinning() ||
                DiagBWinning();
        }

        private bool ColumnAIsWinning()
        {
            var AA = this.FindByName<Label>("LAA");
            var AB = this.FindByName<Label>("LAB");
            var AC = this.FindByName<Label>("LAC");

            if (AA.Text.Equals(AB.Text) && !string.IsNullOrEmpty(AA.Text))
            {
                return AA.Text.Equals(AC.Text); 
            }

            return false;
        }

        private bool ColumnBIsWinning()
        {
            var BA = this.FindByName<Label>("LBA");
            var BB = this.FindByName<Label>("LBB");
            var BC = this.FindByName<Label>("LBC");

            if (BA.Text.Equals(BB.Text) && !string.IsNullOrEmpty(BA.Text))
            {
                return BA.Text.Equals(BC.Text);
            }

            return false;
        }

        private bool ColumnCIsWinning()
        {
            var CA = this.FindByName<Label>("LCA");
            var CB = this.FindByName<Label>("LCB");
            var CC = this.FindByName<Label>("LCC");

            if (CA.Text.Equals(CB.Text) && !string.IsNullOrEmpty(CA.Text))
            {
                return CA.Text.Equals(CC.Text);
            }

            return false;
        }

        private bool RowAIsWinning()
        {
            var AA = this.FindByName<Label>("LAA");
            var BA = this.FindByName<Label>("LBA");
            var CA = this.FindByName<Label>("LCA");

            if (AA.Text.Equals(BA.Text) && !string.IsNullOrEmpty(AA.Text))
            {
                return AA.Text.Equals(CA.Text);
            }

            return false;
        }

        private bool RowBIsWinning()
        {
            var AB = this.FindByName<Label>("LAB");
            var BB = this.FindByName<Label>("LBB");
            var CB = this.FindByName<Label>("LCB");

            if (AB.Text.Equals(BB.Text) && !string.IsNullOrEmpty(AB.Text))
            {
                return AB.Text.Equals(CB.Text);
            }

            return false;
        }

        private bool RowCIsWinning()
        {
            var AC = this.FindByName<Label>("LAC");
            var BC = this.FindByName<Label>("LBC");
            var CC = this.FindByName<Label>("LCC");

            if (AC.Text.Equals(BC.Text) && !string.IsNullOrEmpty(AC.Text))
            {
                return AC.Text.Equals(CC.Text);
            }

            return false;
        }

        private bool DiagAWinning()
        {
            var AA = this.FindByName<Label>("LAA");
            var BB = this.FindByName<Label>("LBB");
            var CC = this.FindByName<Label>("LCC");

            if (AA.Text.Equals(BB.Text) && !string.IsNullOrEmpty(AA.Text))
            {
                return AA.Text.Equals(CC.Text);
            }

            return false;
        }

        private bool DiagBWinning()
        {
            var CA = this.FindByName<Label>("LCA");
            var BB = this.FindByName<Label>("LBB");
            var AC = this.FindByName<Label>("LAC");

            if (CA.Text.Equals(BB.Text) && !string.IsNullOrEmpty(CA.Text))
            {
                return CA.Text.Equals(AC.Text);
            }

            return false;
        }

    }
}
