using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace KnabAssignment.Steps
{
    [Binding]
    class TrelloAPIAutomation
    {
        String existingboardID;
        String newboardID;
        String accessKey;
        String oauthToken;
        String resourceURL;
        String apiResourceURL;
        String newBoardName;
        String deleteEndPointURL;
        IRestResponse response;
        
        [Given(@"User has BoardID of existing Trello board and valid Acess key, OAuth token & endpoint url")]
        public void GivenUserHasBoardIDOfExistingTrelloBoardAndValidAcessKeyOAuthTokenEndpointUrl()
        {
            existingboardID = ConfigurationManager.AppSettings.Get("BoardID");
            accessKey = ConfigurationManager.AppSettings.Get("Access_Key");
            oauthToken = ConfigurationManager.AppSettings.Get("OAuthToken");
            resourceURL = ConfigurationManager.AppSettings.Get("APIBaseURL");
        }

        [When(@"User submit the API GET request using the above parameters")]
        public void WhenUserSubmitTheAPIGETRequestUsingTheAboveParameters()
        {
            apiResourceURL = ConfigurationManager.AppSettings.Get("APIResourceURL");
            String endPointURL = apiResourceURL + existingboardID + "?key=" + accessKey + "&token=" + oauthToken;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(resourceURL);
            var request = new RestRequest(endPointURL, Method.GET);
            response = client.Execute(request);
        }
        
        [Then(@"API should return success HTTP response code along with the board name")]
        public void ThenAPIShouldReturnSuccessHTTPResponseCodeAlongWithTheBoardName()
        {
            StringAssert.AreEqualIgnoringCase("true", response.IsSuccessful.ToString());
        }


        [Given(@"User having valid Access_Key, OAuth token & Resource url")]
        public void GivenUserHavingValidAccess_KeyOAuthTokenResourceUrl()
        {
            accessKey = ConfigurationManager.AppSettings.Get("Access_Key");
            oauthToken = ConfigurationManager.AppSettings.Get("OAuthToken");
            resourceURL = ConfigurationManager.AppSettings.Get("APIBaseURL");

        }

        [Given(@"By using them user creates a board on Trello")]
        public void GivenByUsingThemUserCreatesABoardOnTrello()
        {
            apiResourceURL = ConfigurationManager.AppSettings.Get("APIResourceURL");
            newBoardName = ConfigurationManager.AppSettings.Get("NewBoardName");
            String endPointURL = apiResourceURL + "?name=" + newBoardName+ "&key=" + accessKey + "&token=" + oauthToken;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(resourceURL);
            var request = new RestRequest(endPointURL, Method.POST);
            var resResult = client.Execute<Utilities>(request);
            Console.WriteLine("Newly created board ID is:"+resResult.Data.id);
            StringAssert.AreEqualIgnoringCase("true", resResult.IsSuccessful.ToString());
            newboardID = resResult.Data.id;
            List s = new List();
            s.add(newboardID);
        }


        [When(@"User submits the API request to verify newly created board")]
        public void WhenUserSubmitsTheAPIRequestToVerifyNewlyCreatedBoard()
        {
            apiResourceURL = ConfigurationManager.AppSettings.Get("APIResourceURL");
            String endPointURL = apiResourceURL + newboardID + "?key=" + accessKey + "&token=" + oauthToken;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(resourceURL);
            var request = new RestRequest(endPointURL, Method.GET);
            response = client.Execute(request);
        }

        [Then(@"API should return success response message along with the board name")]
        public void ThenAPIShouldReturnSuccessResponseMessageAlongWithTheBoardName()
        {
            StringAssert.AreEqualIgnoringCase("true", response.IsSuccessful.ToString());
            StringAssert.AreEqualIgnoringCase("OK", response.StatusCode.ToString());
        }


        
        [Given(@"User having valid BoardID, Access_Key, OAuth token & Resource url")]
        public void GivenUserHavingValidBoardIDAccess_KeyOAuthTokenResourceUrl()
        {
            apiResourceURL = ConfigurationManager.AppSettings.Get("APIResourceURL");
            accessKey = ConfigurationManager.AppSettings.Get("Access_Key");
            oauthToken = ConfigurationManager.AppSettings.Get("OAuthToken");
            deleteEndPointURL = apiResourceURL + newboardID + "?key=" + accessKey + "&token=" + oauthToken;
            Console.WriteLine("Delete End point url 1----------->" + deleteEndPointURL);
        }

        [When(@"User submit the API DELETE request using the above parameters")]
        public void WhenUserSubmitTheAPIDELETERequestUsingTheAboveParameters()
        {
            Console.WriteLine("Delete End point url 2----------->" + deleteEndPointURL);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(resourceURL);
            var request = new RestRequest(deleteEndPointURL, Method.DELETE);
            response = client.Execute(request);
        }

        [Then(@"API should return success HTTP response code")]
        public void ThenAPIShouldReturnSuccessHTTPResponseCode()
        {
            ScenarioContext.Current.Pending();
        }





    }
}
