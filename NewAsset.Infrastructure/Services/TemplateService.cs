using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Infrastructure.Services
{
    public class TemplateService:ITemplateService
    {

        public string RenderScribanTemplate(string templatePath, object data)
        {
            // Read the template file
            string templateContent = File.ReadAllText(templatePath);
            // Parse and render the template
            var template = Template.Parse(templateContent);
            return template.Render(data);
        }

    }
}
