using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2017Test.DB
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class DividedPathTest : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIDocument doc = commandData.Application.ActiveUIDocument;

            using(Transaction trans = new Transaction(doc.Document))
            {
                trans.Start("Select model curves in revit document");

                IList<Reference> refList = doc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, 
                        "Please pick some model curves in revit document"
                    );

                DividedPath dpath =  DividedPath.Create(doc.Document, refList);

                trans.Commit();
            }
            

            return Result.Succeeded;
        }
    }
}
