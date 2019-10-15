using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Day8To10OfXamarin.ViewModels.Helpers
{
    public class LocationHelper
    {
        public IGeolocator locator = CrossGeolocator.Current;
        public Position position;

        public LocationHelper()
        {
            locator.PositionChanged += Locator_PositionChanged;
        }

        void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            position = e.Position;
        }

        public async Task<Position> GetLocation(TimeSpan minimumTime, int minimumMeters)
        {
            position = await locator.GetPositionAsync();
            await locator.StartListeningAsync(minimumTime, minimumMeters);
            return position;
        }

        public async void StopListening()
        {
            await locator.StopListeningAsync();
        }
    }
}
