using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThinkGeo.Core;
using ThinkGeo.UI.Wpf;
using Microsoft.Win32;
using System.Windows.Forms;

namespace SalaryApp.Windows.MapWindow
{
    public partial class MapWindow : Window
    {
        public MapWindow()
        {
            InitializeComponent();
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            mapView.MapUnit = GeographyUnit.Meter;
            var cloudVectorBaseMapOverlay = new ThinkGeoCloudVectorMapsOverlay("USlbIyO5uIMja2y0qoM21RRM6NBXUad4hjK3NBD6pD0~", "f6OJsvCDDzmccnevX55nL7nXpPDXXKANe5cN6czVjCH0s8jhpCH-2A~~", ThinkGeoCloudVectorMapsMapType.Light);
            mapView.Overlays.Add(cloudVectorBaseMapOverlay);

            addRegions();
            addCompanies();

        }

        private void addCompanies()
        {
            var companiesLayer = new ShapeFileFeatureLayer(@"../../GeoData/companies.shp");
            companiesLayer.RequireIndex = false;

            var customDataOverlay = new LayerOverlay();
            customDataOverlay.Layers.Add(companiesLayer);
            mapView.Overlays.Add(customDataOverlay);

            var pointStyle = new PointStyle()
            {
                SymbolType = PointSymbolType.Circle,
                SymbolSize = 8,
                FillBrush = new GeoSolidBrush(GeoColors.White),
                OutlinePen = new GeoPen(GeoColors.Black, 2),
            };

            companiesLayer.ZoomLevelSet.ZoomLevel01.DefaultPointStyle = pointStyle;
            companiesLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;
            companiesLayer.FeatureSource.ProjectionConverter = new ProjectionConverter(4326, 3857);
            companiesLayer.Open();
            mapView.CurrentExtent = companiesLayer.GetBoundingBox();
            mapView.Refresh();
        }


        private void addRegions()
        {
            
            var regionLayer = new ShapeFileFeatureLayer(@"../../GeoData/regions.shp");
            regionLayer.RequireIndex = false;
            regionLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyle.CreateSimpleAreaStyle(GeoColor.FromArgb(255, 233, 232, 214), GeoColor.FromArgb(255, 118, 138, 69));
            regionLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            LayerOverlay worldOverlay = new LayerOverlay();
            
            worldOverlay.Layers.Add(regionLayer);
            mapView.Overlays.Add(worldOverlay);

            regionLayer.FeatureSource.ProjectionConverter = new ProjectionConverter(4326, 3857);
            regionLayer.Open();

            mapView.CurrentExtent = regionLayer.GetBoundingBox();
            mapView.Refresh();

        }
    }


    
}
