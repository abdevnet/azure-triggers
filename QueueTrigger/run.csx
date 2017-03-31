#load "..\sharedcode\CreateGreetingRequest.csx"
#load "..\sharedcode\GreetingRequest.csx"

#r "Newtonsoft.Json"

using System;
using Newtonsoft.Json; 

public static void Run(CreateGreetingRequest myQueueItem, 
        TraceWriter log,
        out string outputBlob)
{
    log.Info($"C# Queue trigger {myQueueItem}");

    var greetingRequest = new GreetingRequest();
    greetingRequest.Number = myQueueItem.Number;
    greetingRequest.Message = GenerateGreeting(myQueueItem.FirstName);

    outputBlob = JsonConvert.SerializeObject(greetingRequest);
} 
  
public static string GenerateGreeting(string firstName)
{
	string greeting;
	
	int hourOfDay = DateTime.Now.Hour;
	
	if (hourOfDay > 18)
		greeting = "Good evening";
	else if (hourOfDay > 12)
		greeting = "Good afternoon";
	else
		greeting = "Good morning";
		
	return $"{greeting} {firstName}";
}
