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
using static System.Net.Mime.MediaTypeNames;

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

            AreaCoeff.IsChecked = true;
        }

        private void addCompanies()
        {
            var companiesLayer = new ShapeFileFeatureLayer(@"../../GeoData/companies.shp");
            companiesLayer.RequireIndex = false;

            LayerOverlay customDataOverlay = new LayerOverlay();
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

            /* Добавляет попап с текстом над точкой */
            var popupOverlay = new PopupOverlay();
            var companiesFeatures = companiesLayer.QueryTools.GetAllFeatures(ReturningColumnsType.AllColumns);
            foreach (var feature in companiesFeatures)
            {
                var popup = new Popup(feature.GetShape().GetCenterPoint())
                {
                    Content = FormatingText(feature.ColumnValues["name"])
                };
                popupOverlay.Popups.Add(popup);
            }
            mapView.Overlays.Add(popupOverlay);

            mapView.CurrentExtent = companiesLayer.GetBoundingBox();
            mapView.Refresh();
        }

        private void addRegions()
        {
            var regionLayer = new ShapeFileFeatureLayer(@"../../GeoData/regions.shp");
            regionLayer.RequireIndex = false;

            LayerOverlay worldOverlay = new LayerOverlay();
            worldOverlay.Layers.Add(regionLayer);
            mapView.Overlays.Add(worldOverlay);

            /* Добавление коэффициентов */
            var textStyle = new TextStyle("coeff", new GeoFont("Segoe UI", 16, DrawingFontStyles.Bold), GeoBrushes.Blue);
            textStyle.TextContent = "Район. коэф. {coeff}";
            regionLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = textStyle;

            regionLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyle.CreateSimpleAreaStyle(
                GeoColor.FromArgb(255, 233, 232, 214), GeoColor.FromArgb(255, 118, 138, 69));
            regionLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            regionLayer.FeatureSource.ProjectionConverter = new ProjectionConverter(4326, 3857);
            regionLayer.Open();

            mapView.CurrentExtent = regionLayer.GetBoundingBox();
            mapView.Refresh();
        }

        private void RadioButton_AreaCoefficient(object sender, RoutedEventArgs e)
        {
            Dispose();

            addRegions();
            addCompanies();
        }

        private void RadioButton_Pipeline(object sender, RoutedEventArgs e)
        {
            Dispose();

            var regionLayer = new ShapeFileFeatureLayer(@"../../GeoData/pipelines.shp");
            regionLayer.RequireIndex = false;

            LayerOverlay worldOverlay = new LayerOverlay();
            worldOverlay.Layers.Add(regionLayer);
            mapView.Overlays.Add(worldOverlay);


            var lineStyle = new LineStyle(
                outerPen: new GeoPen(GeoColors.Black, 6),
                innerPen: new GeoPen(GeoColors.White, 3)
            );
            regionLayer.ZoomLevelSet.ZoomLevel01.DefaultLineStyle = lineStyle;
            regionLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            regionLayer.FeatureSource.ProjectionConverter = new ProjectionConverter(4326, 3857);
            regionLayer.Open();

            mapView.CurrentExtent = regionLayer.GetBoundingBox();
            mapView.Refresh();

            addCompanies();
        }

        private void RadioButton_AvgSalary(object sender, RoutedEventArgs e)
        {
            Dispose();

            var regionLayer = new ShapeFileFeatureLayer(@"../../GeoData/regions.shp");
            regionLayer.RequireIndex = false;

            LayerOverlay worldOverlay = new LayerOverlay();
            worldOverlay.Layers.Add(regionLayer);
            mapView.Overlays.Add(worldOverlay);

            /* Добавление коэффициентов */
            var textStyle = new TextStyle("coeff", new GeoFont("Segoe UI", 16, DrawingFontStyles.Bold), GeoBrushes.Blue);
            textStyle.TextContent = "Зарплата {salary}";
            regionLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = textStyle;

            regionLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyle.CreateSimpleAreaStyle(
                GeoColor.FromArgb(255, 233, 232, 214), GeoColor.FromArgb(255, 118, 138, 69));
            regionLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            regionLayer.FeatureSource.ProjectionConverter = new ProjectionConverter(4326, 3857);
            regionLayer.Open();

            mapView.CurrentExtent = regionLayer.GetBoundingBox();
            mapView.Refresh();

            addCompanies();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            mapView.Dispose();
            // Suppress finalization.
            GC.SuppressFinalize(this);

            mapView.MapUnit = GeographyUnit.Meter;
            var cloudVectorBaseMapOverlay = new ThinkGeoCloudVectorMapsOverlay("USlbIyO5uIMja2y0qoM21RRM6NBXUad4hjK3NBD6pD0~", "f6OJsvCDDzmccnevX55nL7nXpPDXXKANe5cN6czVjCH0s8jhpCH-2A~~", ThinkGeoCloudVectorMapsMapType.Light);
            mapView.Overlays.Add(cloudVectorBaseMapOverlay);
        }

        private string FormatingText(string value)
        {
            string utf8_String = value;
            byte[] bytes = Encoding.Default.GetBytes(utf8_String);
            utf8_String = Encoding.UTF8.GetString(bytes);

            return utf8_String;
        }
    }
}
