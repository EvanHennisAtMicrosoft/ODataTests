# ODataTests
A test solution for any OData Issues



## Custom NextLink for expanded navigation property
**Testing Url**: http://localhost:5197/odata/IdentityGovernance/PermissionsAnalytics/Findings/key/WebApplication3.Models.EscalationFinding  

I need to be able to create the nextLink for the `resource` collection below:

```
{
	"@odata.context": "http://localhost:5000/odata/$metadata#Customers/$entity",
	"id": "someId",
	"action": [
		{
			"@odata.type": "#microsoft.graph.AwsAuthorizationSystemTypeAction",
			"id": "somethingHere"
		}
	],
	"resources": [
		{
			"@odata.type": "#microsoft.graph.AwsAuthorizationSystemTypeResource",
			"id": "somethingHere-1"
		},
		{
			"@odata.type": "#microsoft.graph.AwsAuthorizationSystemTypeResource",
			"id": "somethingHere-2"
		},
		{
			"@odata.type": "#microsoft.graph.AwsAuthorizationSystemTypeResource",
			"id": "somethingHere-3"
		},
	]
	"resources@odata.nextLink": "http://localhost:5000/odata/ObjectName?$skipToken=engdjk"
}
```
