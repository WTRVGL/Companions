using Companions.MAUI.Models.App;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MauiMap = Microsoft.Maui.Controls.Maps.Map;

namespace Companions.MAUI.Behaviors
{
    public class MapBehavior : BindableBehavior<MauiMap>
    {
        private MauiMap map;

        public static readonly BindableProperty IsReadyProperty =
            BindableProperty.CreateAttached(nameof(IsReady),
                typeof(bool),
                typeof(MapBehavior),
                default(bool),
                BindingMode.Default,
                null,
                OnIsReadyChanged);

        public bool IsReady
        {
            get => (bool)GetValue(IsReadyProperty);
            set => SetValue(IsReadyProperty, value);
        }

        private static void OnIsReadyChanged(BindableObject view, object oldValue, object newValue)
        {
            var mapBehavior = view as MapBehavior;

            if (mapBehavior != null)
            {
                if (newValue is bool)
                    mapBehavior.ChangePosition();
            }
        }

        public static readonly BindableProperty PlacesProperty =
            BindableProperty.CreateAttached(nameof(Places),
                typeof(IEnumerable<Place>),
                typeof(MapBehavior),
                default(IEnumerable<Place>),
                BindingMode.Default,
                null,
                OnPlacesChanged);


        public IEnumerable<Place> Places
        {
            get => (IEnumerable<Place>)GetValue(PlacesProperty);
            set => SetValue(PlacesProperty, value);
        }

        private static void OnPlacesChanged(BindableObject view, object oldValue, object newValue)
        {
            var mapBehavior = view as MapBehavior;

            if (mapBehavior != null)
            {
                mapBehavior.ChangePosition();

                if (mapBehavior.Places.Count() == 1)
                    mapBehavior.DrawLocation();
            }
        }

        private void DrawLocation()
        {
            map.MapElements.Clear();

            if (Places == null || !Places.Any())
                return;

            var place = Places.First();
            var distance = Distance.FromMeters(50);

            Circle circle = new Circle()
            {
                Center = place.Location,
                Radius = distance,
                StrokeColor = Color.FromArgb("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromArgb("#88FFC0CB")
            };

            map.MapElements.Add(circle);
        }

        private void ChangePosition()
        {
            if (!IsReady || Places == null || !Places.Any())
                return;

            var place = Places.First();
            var distance = Distance.FromKilometers(1);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(place.Location, distance));
        }

        protected override void OnAttachedTo(MauiMap bindable)
        {
            base.OnAttachedTo(bindable);
            map = bindable;
        }

        protected override void OnDetachingFrom(MauiMap bindable)
        {
            base.OnDetachingFrom(bindable);
            map = null;
        }
    }
}