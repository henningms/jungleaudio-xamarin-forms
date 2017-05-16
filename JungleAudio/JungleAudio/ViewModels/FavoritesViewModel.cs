using JungleAudio.Models;
using JungleAudio.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JungleAudio.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        private ObservableCollection<AudioItem> favorites { get; set; }
        public ObservableCollection<AudioItem> Favorites
        {
            get
            {
                return favorites;
            }
            set
            {
                favorites = value;
                OnPropertyChanged();
            }
        }

        public async Task RetrieveFavoritesAsync()
        {
            var favorites = await AudiojungleWebService.GetFavoritesAsync();

            Favorites = new ObservableCollection<AudioItem>(favorites);

            RetrieveFavoritesAsync(2);
        }

        private async void RetrieveFavoritesAsync(int page)
        {
            var favorites = await AudiojungleWebService.GetFavoritesAsync(page);

            if (favorites.Count > 0)
            {
                foreach (var item in favorites)
                {
                    Favorites.Add(item);
                }

                RetrieveFavoritesAsync(page + 1);
            }
        }
    }
}
