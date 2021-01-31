﻿using System.Collections.Specialized;
using BattleMiniMap.Config;
using BattleMiniMap.View.MapTerrain;
using TaleWorlds.GauntletUI;
using TaleWorlds.MountAndBlade;

namespace BattleMiniMap.View.Boundary
{
    public class BattleMiniMap_BoundaryWidget : TextureWidget
    {
        public BattleMiniMap_BoundaryWidget(UIContext context) : base(context)
        {
            TextureProviderName = nameof(BattleMiniMap_BoundaryTextureProvider);
            WidthSizePolicy = HeightSizePolicy = SizePolicy.Fixed;
        }

        protected override void OnConnectedToRoot()
        {
            base.OnConnectedToRoot();

            Mission.Current.Boundaries.CollectionChanged += BoundariesOnCollectionChanged;
        }

        protected override void OnDisconnectedFromRoot()
        {
            base.OnDisconnectedFromRoot();

            Mission.Current.Boundaries.CollectionChanged -= BoundariesOnCollectionChanged;
        }

        private void BoundariesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TextureProvider.Clear();
        }

        protected override void OnUpdate(float dt)
        {
            base.OnUpdate(dt);
            if (MiniMap.Instance != null)
            {
                var width = MiniMap.Instance.BitmapWidth;
                var height = MiniMap.Instance.BitmapHeight;

                SuggestedWidth = BattleMiniMapConfig.Get().WidgetWidth;
                SuggestedHeight = height / (float)width * SuggestedWidth;
                IsEnabled = MiniMap.Instance.IsValid;
            }
            else
            {
                IsEnabled = false;
            }
        }
    }
}
