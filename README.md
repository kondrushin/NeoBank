# NeoBank

# How to build and run.

Open CostCalculator.sln in VisualStudio. Press F5 for building and running.

# How approached
- Domain model based on Cart, Watch, Discount and a watch-in-the-cart-model (WatchForPurchase)
- CartFactory builds a cart based on the list of watch IDs.
- Based on TDD developed functionality together with unit tests.
- Simulated a watch storage (e.g. db) in WatchRepository.
- Developed basic API tests


# What I would improve

1. I would make price decimal since it is possible that for other potential watches int is not applicable.
2. I would throw NonFound message in case if a client sends watch ID which is not in repository. Not it is ignored.
3. I would add exception handling in case of any potential exception, and as a result, logging and 500 response.
4. I would add validation to IDs in request.

# Endppoints
http://localhost:8080/api/checkout

Request headers:
Accept: application/json
Content-Type: application/json

Request body:
[
    "001",
    "002",
    "001",
    "003",
    "004"
]

Response body:
{
    "price": 360
}