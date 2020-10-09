using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlowApi
{
    public class Startup
    {
        public class XmlSerializerInputFormatterNamespace : XmlSerializerInputFormatter
        {
            public override InputFormatterExceptionPolicy ExceptionPolicy => base.ExceptionPolicy;
            public XmlSerializerInputFormatterNamespace(MvcOptions options) : base(options)
            {

            }

            public override bool CanRead(InputFormatterContext context)
            {
                return base.CanRead(context);
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
            {
                return base.GetSupportedContentTypes(contentType, objectType);
            }

            public override Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
            {
                return base.ReadAsync(context);
            }

            public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
            {
                return base.ReadRequestBodyAsync(context, encoding);
            }

            public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
            {
                return base.ReadRequestBodyAsync(context);
            }

            public override string ToString()
            {
                return base.ToString();
            }

            protected override bool CanReadType(Type type)
            {
                return base.CanReadType(type);
            }

            protected override XmlSerializer CreateSerializer(Type type)
            {
                return base.CreateSerializer(type);
            }

            protected override XmlReader CreateXmlReader(Stream readStream, Encoding encoding)
            {

                return base.CreateXmlReader(readStream, encoding);
            }

            protected override XmlSerializer GetCachedSerializer(Type type)
            {
                return base.GetCachedSerializer(type);
            }

            protected override object GetDefaultValueForType(Type modelType)
            {
                return base.GetDefaultValueForType(modelType);
            }

            protected override Type GetSerializableType(Type declaredType)
            {
                return base.GetSerializableType(declaredType);
            }
        }
        public class XmlSerializerOutputFormatterNamespace : XmlSerializerOutputFormatter
        {
            protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
            {
                //applying "empty" namespace will produce no namespaces
                var emptyNamespaces = new XmlSerializerNamespaces();
                emptyNamespaces.Add("atom", "http://www.w3.org/2005/Atom");
                emptyNamespaces.Add("cb", "http://www.cbwiki.net/wiki/index.php/Specification_1.2/");
                emptyNamespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
                emptyNamespaces.Add("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                xmlSerializer.Serialize(xmlWriter, value, emptyNamespaces);
            }
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlSerializerFormatters();

            //services.AddControllers((options) =>
            //{
            //    options.InputFormatters.Add(new XmlSerializerInputFormatterNamespace(options));
            //    options.OutputFormatters.Add(new XmlSerializerOutputFormatterNamespace());
            //}).AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
