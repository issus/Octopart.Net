using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas
{
    [Flags]
    public enum IncludeDirectives
    {
        None,
        ShortDescription,
        Datasheets,
        ComplianceDocuments,
        Descriptions,
        ImageSets,
        Specs,
        CategoryUIds,
        ExternalLinks,
        ReferenceDesigns,
        CadModels
        
    }
}
