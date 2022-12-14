#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

#endregion

namespace NWLToolbar
{
    [Transaction(TransactionMode.Manual)]
    public class ElementHistory : IExternalCommand
    {
        
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Filtered Eelement Collector (Collect Active Selection)            
            ElementId eid = uidoc.Selection.PickObject(ObjectType.Element).ElementId;            
            
            //Variables
            string creator = WorksharingUtils.GetWorksharingTooltipInfo(doc, eid).Creator.ToString();
            string lastChanged = WorksharingUtils.GetWorksharingTooltipInfo(doc, eid).LastChangedBy.ToString();
            
            //Info Report
            TaskDialog.Show("Element History", "Creator:" + "\n" + creator + "\n \n" + "Last Changed By:" + "\n" + lastChanged);

            return Result.Succeeded;
        }
        
    }

}
