# Octopart.Net - C# Octopart API Client

This library was begun before I found out Octopart's pricing. I had expected a free tier, or the ability to get a free open source access as it's to support an Altium (who own Octopart) library that has thousands of users. 

Octopart API Pricing:
$50/month up to 5,000 HTTP Requests per month
$100/month up to 12,000 HTTP Requests per month
$200/month up to 25,000 HTTP Requests per month
$500/month up to 100,000 HTTP Requests per month
Above this, we have custom tiers available
If you have a .edu or university email address you may be eligible for free access to the basic tier.

This library is fully compatible with the current Octopart API as of 05 April 2019 - however - only GetPart and PartMatch are functional. The data structures exist for all data types, as well as tested converters for all enum types.

I publish this in the hopes that it might offer a good starting point for someone who can afford the API access (I was look at 100-250k+ calls/month for the Altium DB Library - over US$200/mo) as it should be fairly quick and easy to implement all the other API calls, since the schema objects are there.

If in the future we have enough Patreon supporters for the Altium Library, and my own scraping and api call functions are not less effort to use at that point, I'll look to work on this again. However, for now, this library will not be contributed to by myself. If you make improvements please submit pull requests :)
