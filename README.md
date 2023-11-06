# ODataTests
A test solution for any OData Issues



## Custom NextLink for expanded navigation property
**Testing Url**: http://localhost:5197/odata/IdentityGovernance/PermissionsAnalytics/Findings/key/WebApplication3.Models.EscalationFinding  

I need to be able to create the nextLink for the `resource` collection below:
Sample Collection
```
{
    "@odata.context": "http://localhost:5197/odata/$metadata#identityGovernance/PermissionsAnalytics/Findings/WebApplication3.Models.EscalationFinding(Actions(),Resources())/$entity",
    "Id": "SomeId",
    "Actions": [
        {
            "Id": "123",
            "AuthorizationSystemTypeDb": 0
        }
    ],
    "Resources": [
        {
            "AuthorizationSystemId": "Id-1",
            "AuthorizationSystemName": "Name-1",
            "AuthorizationSystemType": "Aws"
        },
        {
            "AuthorizationSystemId": "Id-2",
            "AuthorizationSystemName": "Name-2",
            "AuthorizationSystemType": "Aws"
        },
        {
            "AuthorizationSystemId": "Id-3",
            "AuthorizationSystemName": "Name-3",
            "AuthorizationSystemType": "Aws"
        },
        {
            "AuthorizationSystemId": "Id-4",
            "AuthorizationSystemName": "Name-4",
            "AuthorizationSystemType": "Aws"
        },
        {
            "AuthorizationSystemId": "Id-5",
            "AuthorizationSystemName": "Name-5",
            "AuthorizationSystemType": "Aws"
        }
    ]
}
```

Desired Results:
```
{
    "@odata.context": "http://localhost:5197/odata/$metadata#identityGovernance/PermissionsAnalytics/Findings/WebApplication3.Models.EscalationFinding(Actions(),Resources())/$entity",
    "Id": "SomeId",
    "Actions": [
        {
            "Id": "123",
            "AuthorizationSystemTypeDb": 0
        }
    ],
    "Resources": [
        {
            "AuthorizationSystemId": "Id-1",
            "AuthorizationSystemName": "Name-1",
            "AuthorizationSystemType": "Aws"
        },
        {
            "AuthorizationSystemId": "Id-2",
            "AuthorizationSystemName": "Name-2",
            "AuthorizationSystemType": "Aws"
        }
    ],
    "Resources@odata.nextLink": "http://localhost:5197/odata/identityGovernance/PermissionsAnalytics/Findings/SomeId/WebApplication3.Models.EscalationFinding/Resources?$skiptoken=AuthorizationSystemId-%27Id-2%27"
}
```

I can get these results using `[EnableQuery(PageSize = 2)]` but I need to be able to handle a custom skiptoken
