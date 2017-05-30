using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{
    public interface ICategoryVisitor
    {
        void Visit(IGroupCategory cat);
        void Visit(ILeafCategory cat);
    }
}
