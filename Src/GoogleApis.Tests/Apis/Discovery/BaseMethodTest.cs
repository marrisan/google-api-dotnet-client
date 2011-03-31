/*
Copyright 2010 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Google.Apis.Discovery;
using Google.Apis.Json;

namespace Google.Apis.Tests.Apis.Discovery
{


    [TestFixture()]
    public class BaseMethodTest
    {
        private const string SimpleCountMethod =  @"{
                 'restPath': 'activities/count',
                 'rpcMethod': 'chili.activities.count',
                 'httpMethod': 'GET',
                 'description': 'Get a count of link shares',
                 'parameters': {
                  'hl': {
                   'restParameterType': 'query',
                   'description': 'Language code to limit language results.',
                   'type': 'string'
                  },
                  'url': {
                   'restParameterType': 'query',
                   'repeated': true,
                   'description': 'URLs for which to get share counts.',
                   'type': 'string'
                  }
                 },
                 'response': {
                  '$ref': 'ResponseTypeTestString'
                 },
                 'request': {
                  '$ref': 'RequestTypeTestString'
                 }}";

        [Test()]
        public void TestSimpleProperties ()
        {
            var method = new BaseMethodTestImpl("count",SimpleCountMethod);
            Assert.AreEqual("ResponseTypeTestString", method.ResponseType);
            Assert.AreEqual("RequestTypeTestString", method.RequestType);
            Assert.AreEqual("count", method.Name);
            Assert.AreEqual("GET", method.HttpMethod);
            Assert.AreEqual(2, method.Parameters.Count);
        }
        
        
        private class BaseMethodTestImpl : BaseMethod
        {
            public BaseMethodTestImpl(string name, string json) : 
                    base(new KeyValuePair<string, object>(name, JsonReader.Parse(json)))
            {
            }
            
            public override string RestPath {
                get {
                    throw new System.NotImplementedException ();
                }
            }

        }
    }
}