// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace StealthTech.RayTracer.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class MatricesFeature : Xunit.IClassFixture<MatricesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Matrices.feature"
#line hidden
        
        public MatricesFeature(MatricesFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Matrices", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="A 2x2 matrix ought to be representable")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "A 2x2 matrix ought to be representable")]
        public virtual void A2X2MatrixOughtToBeRepresentable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A 2x2 matrix ought to be representable", null, ((string[])(null)));
#line 3
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2"});
            table1.AddRow(new string[] {
                        "-3",
                        "5"});
            table1.AddRow(new string[] {
                        "1",
                        "-2"});
#line 4
 testRunner.Given("the following 2x2 matrix M:", ((string)(null)), table1, "Given ");
#line 8
 testRunner.Then("M[0,0] = -3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.And("M[0,1] = 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("M[1,0] = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("M[1,1] = -2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A 3x3 matrix ought to be representable")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "A 3x3 matrix ought to be representable")]
        public virtual void A3X3MatrixOughtToBeRepresentable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A 3x3 matrix ought to be representable", null, ((string[])(null)));
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3"});
            table2.AddRow(new string[] {
                        "-3",
                        "5",
                        "0"});
            table2.AddRow(new string[] {
                        "1",
                        "-2",
                        "-7"});
            table2.AddRow(new string[] {
                        "0",
                        "1",
                        "1"});
#line 14
 testRunner.Given("the following 3x3 matrix M:", ((string)(null)), table2, "Given ");
#line 19
 testRunner.Then("M[1,1] = -2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("M[2,2] = 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Matrix equality with identical matrices")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "Matrix equality with identical matrices")]
        public virtual void MatrixEqualityWithIdenticalMatrices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Matrix equality with identical matrices", null, ((string[])(null)));
#line 22
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table3.AddRow(new string[] {
                        "1",
                        "2",
                        "3",
                        "4"});
            table3.AddRow(new string[] {
                        "5",
                        "6",
                        "7",
                        "8"});
            table3.AddRow(new string[] {
                        "9",
                        "8",
                        "7",
                        "6"});
            table3.AddRow(new string[] {
                        "5",
                        "4",
                        "3",
                        "2"});
#line 23
 testRunner.Given("the following matrix A:", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table4.AddRow(new string[] {
                        "1",
                        "2",
                        "3",
                        "4"});
            table4.AddRow(new string[] {
                        "5",
                        "6",
                        "7",
                        "8"});
            table4.AddRow(new string[] {
                        "9",
                        "8",
                        "7",
                        "6"});
            table4.AddRow(new string[] {
                        "5",
                        "4",
                        "3",
                        "2"});
#line 29
 testRunner.And("the following matrix B:", ((string)(null)), table4, "And ");
#line 35
 testRunner.Then("A = B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Matrix equality with different matrices")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "Matrix equality with different matrices")]
        public virtual void MatrixEqualityWithDifferentMatrices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Matrix equality with different matrices", null, ((string[])(null)));
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table5.AddRow(new string[] {
                        "1",
                        "2",
                        "3",
                        "4"});
            table5.AddRow(new string[] {
                        "5",
                        "6",
                        "7",
                        "8"});
            table5.AddRow(new string[] {
                        "9",
                        "8",
                        "7",
                        "6"});
            table5.AddRow(new string[] {
                        "5",
                        "4",
                        "3",
                        "2"});
#line 38
 testRunner.Given("the following matrix A:", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table6.AddRow(new string[] {
                        "1",
                        "2",
                        "3",
                        "4"});
            table6.AddRow(new string[] {
                        "5",
                        "6",
                        "7",
                        "8"});
            table6.AddRow(new string[] {
                        "9",
                        "8",
                        "7",
                        "6"});
            table6.AddRow(new string[] {
                        "5",
                        "4",
                        "4",
                        "2"});
#line 44
 testRunner.And("the following matrix B:", ((string)(null)), table6, "And ");
#line 50
 testRunner.Then("A != B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Multiplying two matrices")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "Multiplying two matrices")]
        public virtual void MultiplyingTwoMatrices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying two matrices", null, ((string[])(null)));
#line 52
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table7.AddRow(new string[] {
                        "1",
                        "2",
                        "3",
                        "4"});
            table7.AddRow(new string[] {
                        "5",
                        "6",
                        "7",
                        "8"});
            table7.AddRow(new string[] {
                        "9",
                        "8",
                        "7",
                        "6"});
            table7.AddRow(new string[] {
                        "5",
                        "4",
                        "3",
                        "2"});
#line 53
 testRunner.Given("the following matrix A:", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table8.AddRow(new string[] {
                        "-2",
                        "1",
                        "2",
                        "3"});
            table8.AddRow(new string[] {
                        "3",
                        "2",
                        "1",
                        "-1"});
            table8.AddRow(new string[] {
                        "4",
                        "3",
                        "6",
                        "5"});
            table8.AddRow(new string[] {
                        "1",
                        "2",
                        "7",
                        "8"});
#line 59
 testRunner.And("the following matrix B:", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table9.AddRow(new string[] {
                        "20",
                        "22",
                        "50",
                        "48"});
            table9.AddRow(new string[] {
                        "44",
                        "54",
                        "114",
                        "108"});
            table9.AddRow(new string[] {
                        "40",
                        "58",
                        "110",
                        "102"});
            table9.AddRow(new string[] {
                        "16",
                        "26",
                        "46",
                        "42"});
#line 65
 testRunner.Then("A * B is the following matrix:", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A matrix multiplied by a tuple")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "A matrix multiplied by a tuple")]
        public virtual void AMatrixMultipliedByATuple()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A matrix multiplied by a tuple", null, ((string[])(null)));
#line 72
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3",
                        "col4"});
            table10.AddRow(new string[] {
                        "1",
                        "2",
                        "3",
                        "4"});
            table10.AddRow(new string[] {
                        "2",
                        "4",
                        "4",
                        "2"});
            table10.AddRow(new string[] {
                        "8",
                        "6",
                        "4",
                        "1"});
            table10.AddRow(new string[] {
                        "0",
                        "0",
                        "0",
                        "1"});
#line 73
 testRunner.Given("the following matrix A:", ((string)(null)), table10, "Given ");
#line 79
 testRunner.And("b <- tuple(1, 2, 3, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.Then("A * b = tuple(18, 24, 33, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.And("b * A = tuple(18, 24, 33, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Multiplying two matrices find E23")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "Multiplying two matrices find E23")]
        public virtual void MultiplyingTwoMatricesFindE23()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying two matrices find E23", null, ((string[])(null)));
#line 83
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3"});
            table11.AddRow(new string[] {
                        "1",
                        "0",
                        "0"});
            table11.AddRow(new string[] {
                        "-3",
                        "1",
                        "0"});
            table11.AddRow(new string[] {
                        "0",
                        "0",
                        "1"});
#line 84
 testRunner.Given("the following matrix A:", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3"});
            table12.AddRow(new string[] {
                        "1",
                        "2",
                        "1"});
            table12.AddRow(new string[] {
                        "3",
                        "8",
                        "1"});
            table12.AddRow(new string[] {
                        "0",
                        "4",
                        "1"});
#line 89
 testRunner.And("the following matrix B:", ((string)(null)), table12, "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "col1",
                        "col2",
                        "col3"});
            table13.AddRow(new string[] {
                        "1",
                        "2",
                        "1"});
            table13.AddRow(new string[] {
                        "0",
                        "2",
                        "-2"});
            table13.AddRow(new string[] {
                        "0",
                        "4",
                        "1"});
#line 94
 testRunner.Then("A * B is the following matrix:", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Multiplying two matrices find E32")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "Multiplying two matrices find E32")]
        public virtual void MultiplyingTwoMatricesFindE32()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying two matrices find E32", null, ((string[])(null)));
#line 100
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "c1",
                        "c2",
                        "c3"});
            table14.AddRow(new string[] {
                        "1",
                        "0",
                        "0"});
            table14.AddRow(new string[] {
                        "0",
                        "1",
                        "0"});
            table14.AddRow(new string[] {
                        "0",
                        "-2",
                        "1"});
#line 101
 testRunner.Given("the following matrix A:", ((string)(null)), table14, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "c1",
                        "c2",
                        "c3"});
            table15.AddRow(new string[] {
                        "1",
                        "2",
                        "1"});
            table15.AddRow(new string[] {
                        "0",
                        "2",
                        "-2"});
            table15.AddRow(new string[] {
                        "0",
                        "4",
                        "1"});
#line 106
 testRunner.And("the following matrix B:", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "c1",
                        "c2",
                        "c3"});
            table16.AddRow(new string[] {
                        "1",
                        "2",
                        "1"});
            table16.AddRow(new string[] {
                        "0",
                        "2",
                        "-2"});
            table16.AddRow(new string[] {
                        "0",
                        "0",
                        "5"});
#line 111
 testRunner.Then("A * B is the following matrix:", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Multiplying column by row")]
        [Xunit.TraitAttribute("FeatureTitle", "Matrices")]
        [Xunit.TraitAttribute("Description", "Multiplying column by row")]
        public virtual void MultiplyingColumnByRow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying column by row", null, ((string[])(null)));
#line 117
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "c1"});
            table17.AddRow(new string[] {
                        "2"});
            table17.AddRow(new string[] {
                        "3"});
            table17.AddRow(new string[] {
                        "4"});
#line 118
 testRunner.Given("the following matrix A:", ((string)(null)), table17, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "c1",
                        "c2"});
            table18.AddRow(new string[] {
                        "1",
                        "6"});
#line 123
 testRunner.And("the following matrix B:", ((string)(null)), table18, "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "c1",
                        "c2"});
            table19.AddRow(new string[] {
                        "2",
                        "12"});
            table19.AddRow(new string[] {
                        "3",
                        "18"});
            table19.AddRow(new string[] {
                        "4",
                        "24"});
#line 126
 testRunner.Then("A * B is the following matrix:", ((string)(null)), table19, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                MatricesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                MatricesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
