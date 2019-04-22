using Model.GoogleChartApi;
using Model.GoogleChartApi.Abstraction;
using System;

namespace External.GoogleChartApi
{
    public sealed class GoogleChartQrCodeBuilder : IGoogleChartQrCodeBuilder
    {
        private readonly string sizeParamName = "chs";
        private readonly string typeParamName = "cht";
        private readonly string dataParamName = "chl";
        private readonly string encodingParamName = "choe";

        private readonly string defaultUrl = "https://chart.googleapis.com/chart";
        private readonly string defaultEncoding = "UTF-8";
        private readonly string defaultType = "qr";
        private readonly int defaultHeight = 150;
        private readonly int defaultWidth = 150;

        private Model.GoogleChartApi.GoogleChartApi configuration { get; set; }

        private void SetConfiguration()
        {
            this.configuration.Url = this.configuration.Url ?? this.defaultUrl;
            this.configuration.Encoding = this.configuration.Encoding ?? this.defaultEncoding;
            this.configuration.Type = this.configuration.Type ?? this.defaultType;
            this.configuration.SizePixels = this.configuration.SizePixels ?? new SizePixels { Height = this.defaultHeight, Width = this.defaultWidth };
        }

        public string Build(Model.GoogleChartApi.GoogleChartApi configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.SetConfiguration();

            var queryBuilder = new WebQueryParamsBuilder(this.configuration.Url);

            queryBuilder.Add(this.typeParamName, this.configuration.Type)
                        .Add(this.sizeParamName, $"{this.configuration.SizePixels.Width}x{this.configuration.SizePixels.Height}")
                        .Add(this.dataParamName, this.configuration.Data)
                        .Add(this.encodingParamName, this.configuration.Encoding);

            return queryBuilder.Content;
        }
    }
}
