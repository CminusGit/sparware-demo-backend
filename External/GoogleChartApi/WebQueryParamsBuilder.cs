using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External.GoogleChartApi
{
    public sealed class WebQueryParamsBuilder
    {
        private string url { get; set; }
        private StringBuilder content { get; set; }

        public string Content
        {
            get
            {
                return this.content.ToString();
            }

            private set { }
        }
        public List<KeyValuePair<string, string>> ParametersList { get; private set; }
        private WebQueryParamsBuilder()
        {

        }

        public WebQueryParamsBuilder(string url)
        {
            this.ParametersList = new List<KeyValuePair<string, string>>();
            this.content = new StringBuilder();
            this.url = url;

            this.content.Append($"{this.url}?");
        }

        public WebQueryParamsBuilder Add(string name, string value)
        {
            this.AddImplementation(new KeyValuePair<string, string>(name, value));

            return this;
        }
        public WebQueryParamsBuilder Add(KeyValuePair<string, string> param)
        {
            this.AddImplementation(param);

            return this;
        }

        private void AddImplementation(KeyValuePair<string, string> param)
        {
            this.ParametersList.Add(param);

            if (this.ParametersList.Count == 0)
            {
                this.content.Append(param.Key)
                            .Append("=")
                            .Append(param.Value);
            }
            else
            {
                this.content.Append("&")
                            .Append(param.Key)
                            .Append("=")
                            .Append(param.Value);
            }
        }
    }
}
