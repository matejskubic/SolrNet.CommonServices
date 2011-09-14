using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;

namespace SSIS.Solr.Destination
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/ms135993(SQL.110).aspx
    /// </summary>
    [DtsPipelineComponent(DisplayName = "SolrDestination", ComponentType = ComponentType.DestinationAdapter,
        CurrentVersion = 1, Description = "Apache Solr Destination" )]
    public class SolrDestination : PipelineComponent
    {

        public string SolrUrl { get; set; }

        public override void ProvideComponentProperties()
        {
            base.ProvideComponentProperties();
            RemoveAllInputsOutputsAndCustomProperties();

            var input = ComponentMetaData.InputCollection.New();
            input.Name = "Input";
            input.HasSideEffects = true;


            var col1 = input.InputColumnCollection.New();
            col1.Name = "SolrId";
            //col1.DataType = DataType.DT_I4;

            col1.Description = "Ključ Solr";
            col1.UsageType = DTSUsageType.UT_READONLY;




            IDTSCustomProperty100 property = ComponentMetaData.CustomPropertyCollection.New();
            property.Name = "test1";
            property.Description = "Identifies a Variable in the package.";
            property.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;



        }

        public override void ProcessInput(int inputID, PipelineBuffer buffer)
        {
            //base.ProcessInput(inputID, buffer);

        }

        public override void Initialize()
        {
            base.Initialize();
            InsertOutput(DTSInsertPlacement.IP_AFTER, 0);

        }
    }
}