
dotnet源码： https://referencesource.microsoft.com/

//此内容为 ready to record
------------------------------------------任意连续整数----------------------------------------------------------------------
2.      var a = Enumerable.Range(10, 20);

            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

-------------------------------Pantry---------------------------
             static void Main(string[] args)
        {
            PostPantry("anotherBasket");
            //GetPantry();
            //GetBasket("testBasket
            
        }

        private static readonly string BaseUrl =
            "https://getpantry.cloud/apiv1/pantry/1e8cda95-3a43-44b0-9cf4-a41b01d63405";

        private static void PostPantry(string basket) //create or replace basket
        {
            var client = new RestClient(basket.GetBasketUrl(BaseUrl)) { Timeout = -1 };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n\t\"derp\": \"flerp123\",\n\t\"testPayload\": true,\n\t\"keysLength\": 3\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);
        }


        private static void GetPantry() //get all info of your pantry
        {
            var client = new RestClient(BaseUrl) { Timeout = -1 };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static void GetBasket(string basket)
        {

            var client = new RestClient(basket.GetBasketUrl(BaseUrl)) { Timeout = -1 };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            #region 格式化json内容
            //dynamic re = JsonConvert.DeserializeObject(response.Content);

            //Console.WriteLine(re.keysLength); 
            #endregion

            Console.WriteLine(response.Content);
        }

        private static void PutBasket(string basket) //update or append
        {
            var client = new RestClient(basket.GetBasketUrl(BaseUrl)) { Timeout = -1 };

            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n\t\"newKey\": \"oldValue\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static void DeleteBasket(string basket)
        {
            var client = new RestClient(basket.GetBasketUrl(BaseUrl)) { Timeout = -1 };
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
