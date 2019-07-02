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
    public partial class TransformationsFeature : Xunit.IClassFixture<TransformationsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Transformations.feature"
#line hidden
        
        public TransformationsFeature(TransformationsFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Transformations", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.FactAttribute(DisplayName="Multiplying by a translation matrix")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Multiplying by a translation matrix")]
        public virtual void MultiplyingByATranslationMatrix()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying by a translation matrix", null, ((string[])(null)));
#line 3
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
 testRunner.Given("transform ← translation(5, -3, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.And("point ← Point(-3, 4, 5)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.Then("transform * point = Point(2, 1, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Multiplying by the inverse of a translation matrix")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Multiplying by the inverse of a translation matrix")]
        public virtual void MultiplyingByTheInverseOfATranslationMatrix()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying by the inverse of a translation matrix", null, ((string[])(null)));
#line 8
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 testRunner.Given("transform ← translation(5, -3, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("inverseTransform ← inverse(transform)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("point ← Point(-3, 4, 5)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("inverseTransform * p = Point(-8, 7, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Translation does not affect vectors")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Translation does not affect vectors")]
        public virtual void TranslationDoesNotAffectVectors()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Translation does not affect vectors", null, ((string[])(null)));
#line 14
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 15
 testRunner.Given("transform ← translation(5, -3, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.And("vector ← Vector(-3, 4, 5)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("transform * v = v", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A scaling matrix applied to a point")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A scaling matrix applied to a point")]
        public virtual void AScalingMatrixAppliedToAPoint()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A scaling matrix applied to a point", null, ((string[])(null)));
#line 19
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 20
 testRunner.Given("transform ← scaling(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("point ← Point(-4, 6, 8)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("transform * point = Point(-8, 18, 32)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A scaling matrix applied to a vector")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A scaling matrix applied to a vector")]
        public virtual void AScalingMatrixAppliedToAVector()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A scaling matrix applied to a vector", null, ((string[])(null)));
#line 24
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 25
 testRunner.Given("transform ← scaling(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("vector ← Vector(-4, 6, 8)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Then("transform * vector = Vector(-8, 18, 32)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Multiplying by the inverse of a scaling matrix")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Multiplying by the inverse of a scaling matrix")]
        public virtual void MultiplyingByTheInverseOfAScalingMatrix()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiplying by the inverse of a scaling matrix", null, ((string[])(null)));
#line 29
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 30
 testRunner.Given("transform ← scaling(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("inverseTransform ← inverse(transform)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("vector ← Vector(-4, 6, 8)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Then("inverseTransform * vector = Vector(-2, 2, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Rotating a point around the x axis")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Rotating a point around the x axis")]
        public virtual void RotatingAPointAroundTheXAxis()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Rotating a point around the x axis", null, ((string[])(null)));
#line 35
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 36
 testRunner.Given("point ← Point(0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("halfQuarter ← rotation_x(π / 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("fullQuarter ← rotation_x(π / 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("halfQuarter * point = Point(0, √2/2, √2/2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("fullQuarter * point = Point(0, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="The inverse of an x-rotation rotates in the opposite direction")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "The inverse of an x-rotation rotates in the opposite direction")]
        public virtual void TheInverseOfAnX_RotationRotatesInTheOppositeDirection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The inverse of an x-rotation rotates in the opposite direction", null, ((string[])(null)));
#line 42
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 43
 testRunner.Given("point ← Point(0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("halfQuarter ← rotation_x(π / 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("inverseTransform ← inverse(half_quarter)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.Then("inverseTransform * p = Point(0, √2/2, -√2/2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Rotating a point around the y axis")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Rotating a point around the y axis")]
        public virtual void RotatingAPointAroundTheYAxis()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Rotating a point around the y axis", null, ((string[])(null)));
#line 48
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 49
 testRunner.Given("point ← Point(0, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("half_quarter ← rotation_y(π / 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("fullQuarter ← rotation_y(π / 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then("halfQuarter * point = Point(√2/2, 0, √2/2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.And("fullQuarter * point = Point(1, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Rotating a point around the z axis")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Rotating a point around the z axis")]
        public virtual void RotatingAPointAroundTheZAxis()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Rotating a point around the z axis", null, ((string[])(null)));
#line 55
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 56
 testRunner.Given("point ← Point(0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.And("halfQuarter ← rotation_z(π / 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("full_quarter ← rotation_z(π / 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.Then("halfQuarter * point = Point(-√2/2, √2/2, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.And("fullQuarter * point = Point(-1, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A shearing transformation moves x in proportion to y")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A shearing transformation moves x in proportion to y")]
        public virtual void AShearingTransformationMovesXInProportionToY()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A shearing transformation moves x in proportion to y", null, ((string[])(null)));
#line 62
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 63
 testRunner.Given("transform ← shearing(1, 0, 0, 0, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
 testRunner.And("point ← Point(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("transform * point = Point(5, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A shearing transformation moves y in proportion to x")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A shearing transformation moves y in proportion to x")]
        public virtual void AShearingTransformationMovesYInProportionToX()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A shearing transformation moves y in proportion to x", null, ((string[])(null)));
#line 67
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 68
 testRunner.Given("transform ← shearing(0, 0, 1, 0, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.And("point ← Point(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("transform * point = Point(2, 5, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A shearing transformation moves y in proportion to z")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A shearing transformation moves y in proportion to z")]
        public virtual void AShearingTransformationMovesYInProportionToZ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A shearing transformation moves y in proportion to z", null, ((string[])(null)));
#line 72
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 73
 testRunner.Given("transform ← shearing(0, 0, 0, 1, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("point ← Point(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.Then("transform * point = Point(2, 7, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A shearing transformation moves z in proportion to x")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A shearing transformation moves z in proportion to x")]
        public virtual void AShearingTransformationMovesZInProportionToX()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A shearing transformation moves z in proportion to x", null, ((string[])(null)));
#line 77
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 78
 testRunner.Given("transform ← shearing(0, 0, 0, 0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.And("point ← Point(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.Then("transform * point = Point(2, 3, 6)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A shearing transformation moves z in proportion to y")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A shearing transformation moves z in proportion to y")]
        public virtual void AShearingTransformationMovesZInProportionToY()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A shearing transformation moves z in proportion to y", null, ((string[])(null)));
#line 82
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 83
 testRunner.Given("transform ← shearing(0, 0, 0, 0, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
 testRunner.And("point ← Point(2, 3, 4)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.Then("transform * point = Point(2, 3, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Individual transformations are applied in sequence")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Individual transformations are applied in sequence")]
        public virtual void IndividualTransformationsAreAppliedInSequence()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Individual transformations are applied in sequence", null, ((string[])(null)));
#line 87
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 88
 testRunner.Given("point ← Point(1, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.And("transformA ← rotation_x(π / 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("transformB ← scaling(5, 5, 5)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("transformC ← translation(10, 5, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.When("point2 ← transformA * point", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.Then("point2 = Point(1, -1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
 testRunner.When("point3 ← transformB * point2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.Then("point3 = Point(5, -5, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.When("point4 ← transformC * point3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("point4 = Point(15, 0, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Chained transformations must be applied in reverse order")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Chained transformations must be applied in reverse order")]
        public virtual void ChainedTransformationsMustBeAppliedInReverseOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Chained transformations must be applied in reverse order", null, ((string[])(null)));
#line 102
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 103
 testRunner.Given("point ← Point(1, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 104
 testRunner.And("transformA ← rotation_x(π / 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("transformB ← scaling(5, 5, 5)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("transformC ← translation(10, 5, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("transformT ← transformC * transformB * transformA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("transformT * point = Point(15, 0, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Fluent chained transformations")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "Fluent chained transformations")]
        public virtual void FluentChainedTransformations()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fluent chained transformations", null, ((string[])(null)));
#line 110
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 111
 testRunner.Given("point ← Point(1, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 112
 testRunner.When("transformT ← rotation_x(π / 2).scaling(5, 5, 5).translation(10, 5, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
 testRunner.Then("transformT * point = Point(15, 0, 7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="The transformation matrix for the default orientation")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "The transformation matrix for the default orientation")]
        public virtual void TheTransformationMatrixForTheDefaultOrientation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The transformation matrix for the default orientation", null, ((string[])(null)));
#line 115
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 116
 testRunner.Given("from ← Point(0, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 117
 testRunner.And("to ← Point(0, 0, -1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("up ← Vector(0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.When("transform ← ViewTransform(from, to, up)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
 testRunner.Then("transform = identity_matrix", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A view transformation matrix looking in positive z direction")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "A view transformation matrix looking in positive z direction")]
        public virtual void AViewTransformationMatrixLookingInPositiveZDirection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A view transformation matrix looking in positive z direction", null, ((string[])(null)));
#line 122
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 123
 testRunner.Given("from ← Point(0, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 124
 testRunner.And("to ← Point(0, 0, 1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("up ← Vector(0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.When("transform ← ViewTransform(from, to, up)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
 testRunner.Then("transform = scaling(-1, 1, -1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="The view transformation moves the world")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "The view transformation moves the world")]
        public virtual void TheViewTransformationMovesTheWorld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The view transformation moves the world", null, ((string[])(null)));
#line 129
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 130
 testRunner.Given("from ← Point(0, 0, 8)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 131
 testRunner.And("to ← Point(0, 0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And("up ← Vector(0, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.When("transform ← ViewTransform(from, to, up)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
 testRunner.Then("transform = translation(0, 0, -8)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="An arbitrary view transformation")]
        [Xunit.TraitAttribute("FeatureTitle", "Transformations")]
        [Xunit.TraitAttribute("Description", "An arbitrary view transformation")]
        public virtual void AnArbitraryViewTransformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An arbitrary view transformation", null, ((string[])(null)));
#line 136
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 137
 testRunner.Given("from ← Point(1, 3, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 138
 testRunner.And("to ← Point(4, -2, 8)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.And("up ← Vector(1, 1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
 testRunner.When("transform ← ViewTransform(from, to, up)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table58 = new TechTalk.SpecFlow.Table(new string[] {
                        "-0.50709",
                        "0.50709",
                        "0.67612",
                        "-2.36643"});
            table58.AddRow(new string[] {
                        "0.76772",
                        "0.60609",
                        "0.12122",
                        "-2.82843"});
            table58.AddRow(new string[] {
                        "-0.35857",
                        "0.59761",
                        "-0.71714",
                        "0.00000"});
            table58.AddRow(new string[] {
                        "0.00000",
                        "0.00000",
                        "0.00000",
                        "1.00000"});
#line 141
 testRunner.Then("t is the following matrix:", ((string)(null)), table58, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                TransformationsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                TransformationsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
