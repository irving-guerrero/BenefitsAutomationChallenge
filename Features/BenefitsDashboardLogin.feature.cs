﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BenefitsAutomationChallenge.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Benefits Dashboard Login")]
    public partial class BenefitsDashboardLoginFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "BenefitsDashboardLogin.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Benefits Dashboard Login", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate required login input fields")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.CategoryAttribute("UI")]
        [NUnit.Framework.TestCaseAttribute("", "", null)]
        [NUnit.Framework.TestCaseAttribute("RandomUser", "", null)]
        [NUnit.Framework.TestCaseAttribute("", "RandPass", null)]
        [NUnit.Framework.TestCaseAttribute("U", "", null)]
        [NUnit.Framework.TestCaseAttribute("", "P", null)]
        public void ValidateRequiredLoginInputFields(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression",
                    "UI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Username", username);
            argumentsOfScenario.Add("Password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate required login input fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
    testRunner.Given("I am on the Benefits Dashboard login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
    testRunner.When(string.Format("I enter username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
    testRunner.And("I click on log in button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
    testRunner.Then(string.Format("username \"{0}\" and password \"{1}\" are required", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate max length for login input fields")]
        [NUnit.Framework.TestCaseAttribute("RandomUser", "", null)]
        [NUnit.Framework.TestCaseAttribute("", "RandPass", null)]
        [NUnit.Framework.TestCaseAttribute("U", "", null)]
        [NUnit.Framework.TestCaseAttribute("", "P", null)]
        [NUnit.Framework.TestCaseAttribute("Big text big text Big text big text Big text big text Big text big text", "", null)]
        [NUnit.Framework.TestCaseAttribute("", "Big text big text Big text big text Big text big text Big text big text", null)]
        public void ValidateMaxLengthForLoginInputFields(string username, string password, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Username", username);
            argumentsOfScenario.Add("Password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate max length for login input fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 18
    testRunner.Given("I am on the Benefits Dashboard login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 19
    testRunner.When(string.Format("I enter username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 20
    testRunner.And("I click on log in button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
    testRunner.Then(string.Format("username \"{0}\" and password \"{1}\" have min and max Length", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate login with invalid credentials")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.CategoryAttribute("UI")]
        [NUnit.Framework.TestCaseAttribute("WrongUser", "WrongPass", null)]
        [NUnit.Framework.TestCaseAttribute("TestUser438", "WrongPass", null)]
        [NUnit.Framework.TestCaseAttribute("valid user with more than 50 characters plus some plus", "WrongPass", null)]
        public void ValidateLoginWithInvalidCredentials(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression",
                    "UI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Username", username);
            argumentsOfScenario.Add("Password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate login with invalid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 33
    testRunner.Given("I am on the Benefits Dashboard login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
    testRunner.When(string.Format("I enter username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 35
    testRunner.And("I click on log in button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
    testRunner.Then("bad credentials error message should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate login with valid credentials")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.CategoryAttribute("UI")]
        [NUnit.Framework.TestCaseAttribute("TestUser438", "!4xAFYaDO.u$", null)]
        public void ValidateLoginWithValidCredentials(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression",
                    "UI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Username", username);
            argumentsOfScenario.Add("Password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate login with valid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 44
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 45
    testRunner.Given("I am on the Benefits Dashboard login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 46
    testRunner.When(string.Format("I enter username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 47
    testRunner.And("I click on log in button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
    testRunner.Then("benefits dashboard page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
