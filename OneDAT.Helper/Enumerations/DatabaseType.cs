namespace OneDAT.Helper.Enumerations
{
    /// <summary>
    /// 
    /// </summary>
    public enum DatabaseType
    {
        None = 0,
        AmazonDynamoDB = 1,
        MongoDB = 2
    }

    public class ConversionUniType
    {
        public static string PhysicalPropertyVariables = "Physical Property Variables";
        //AnalysisVariables=4,
        //SimulatedDistillationVariables=5,
        //CatalystVariables=6,
        //RunCatalystLoad=8,
        //LogsheetVariables=21,
        //GCVariables=23,
        //ManageModuleVariables=24,
        //DOEVariables=25,
        //ModeVariables=26,
        //ManageFeedVariables=27,
        //WeightcheckCalculation=28,
        //ManageMode=31,
        //ManageModeRecipe=32,
        //ManageModeSPP=33,
        //ManageModeNIRProcessConditions=34,
        //ManageFeed=35,
        //CatalystLoadingTemplate=36,
        //Catayst=37,
        //CataystFamily=38,
        public static string Diluent = "Diluent";
        //CommercialCatalystSDS=40,
        //DOE=41,
        //ManageNIRModelTemplate=42,
        //RunNIRSpecs=43,
        //RunAdditionalInfo=44,
        //RunTMFMassFlowMeterCalibration=45,
        //RunBoilingPoints=46,
        //RunTCCalibration=47,
        //RunRecipe=48,
        //RunProcessSpecs=49

    }
}
