﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace KnabAssignment.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("TrelloAPIAutomation", Description="\tInorder to reduce the manual effort of executing\r\n\ttest scenarios for executing " +
        "CURD operations on Trello boards\r\n\tAs a automation engineer\r\n\tI want to automate" +
        " this complete process", SourceFile="Features\\TrelloAPIAutomation.feature", SourceLine=0)]
    public partial class TrelloAPIAutomationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TrelloAPIAutomation.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TrelloAPIAutomation", "\tInorder to reduce the manual effort of executing\r\n\ttest scenarios for executing " +
                    "CURD operations on Trello boards\r\n\tAs a automation engineer\r\n\tI want to automate" +
                    " this complete process", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Verify the completeness of existing Trello board using API call", new string[] {
                "api"}, SourceLine=7)]
        public virtual void VerifyTheCompletenessOfExistingTrelloBoardUsingAPICall()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the completeness of existing Trello board using API call", new string[] {
                        "api"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("User has BoardID of existing Trello board and valid Acess key, OAuth token & endp" +
                    "oint url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("User submit the API GET request using the above parameters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("API should return success HTTP response code along with the board name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Create and verify the trello board using API call", new string[] {
                "api"}, SourceLine=13)]
        public virtual void CreateAndVerifyTheTrelloBoardUsingAPICall()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create and verify the trello board using API call", new string[] {
                        "api"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("User having valid Access_Key, OAuth token & Resource url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.And("By using them user creates a board on Trello", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("User submits the API request to verify newly created board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("API should return success response message along with the board name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Delete the trello board using API call", new string[] {
                "api"}, SourceLine=20)]
        public virtual void DeleteTheTrelloBoardUsingAPICall()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the trello board using API call", new string[] {
                        "api"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("User having valid BoardID, Access_Key, OAuth token & Resource url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("User submit the API DELETE request using the above parameters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("API should return success HTTP response code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
