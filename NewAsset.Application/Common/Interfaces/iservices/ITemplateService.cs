using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface ITemplateService
    {
        string RenderScribanTemplate(string templatePath, object data);
    }
}
