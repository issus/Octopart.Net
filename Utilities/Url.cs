using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace Octopart.Net.Utilities
{
    public static class Url
    {
        // based on code from Marcelo Calbucci, stackoverflow.
        // note: trying to resolve url's from octopart too fast gets you shitcanned pretty quick heh.
        public static string GetFinalRedirect(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return url;

            int maxRedirCount = 8;  // prevent infinite loops
            string newUrl = url;

            CookieContainer cookies = new CookieContainer();

            do
            {
                HttpWebRequest req = null;
                HttpWebResponse resp = null;
                try
                {
                    req = (HttpWebRequest)HttpWebRequest.Create(url);
                    req.Headers.Remove("user-agent");
                    req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8;v=b3";
                    req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.87 Safari/537.36";
                    req.Headers.Add("accept-encoding", "");
                    req.Headers.Add("accept-language", "n-GB,en-US;q=0.9,en;q=0.8");
                    req.CookieContainer = cookies;
                    req.Method = "GET";
                    req.AllowAutoRedirect = false;

                    resp = (HttpWebResponse)req.GetResponse();
                    switch (resp.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            if (resp.Headers.AllKeys.Contains("refresh") || resp.Headers["server"] == "cloudflare")
                            {
                                newUrl = resp.Headers["refresh"];
                                if (String.IsNullOrWhiteSpace(newUrl))
                                    return url;

                                newUrl = newUrl.Substring(newUrl.IndexOf('=') + 1);

                                if (newUrl.IndexOf("://", System.StringComparison.Ordinal) == -1)
                                {
                                    // Doesn't have a URL Schema, meaning it's a relative or absolute URL
                                    Uri u = new Uri(new Uri(url), newUrl);
                                    newUrl = u.ToString();
                                }
                                break;
                            }
                            else
                            {
                                return newUrl;
                            }
                        case HttpStatusCode.Redirect:
                        case HttpStatusCode.MovedPermanently:
                        case HttpStatusCode.RedirectKeepVerb:
                        case HttpStatusCode.RedirectMethod:
                            newUrl = resp.Headers["Location"];
                            if (newUrl == null)
                                return url;

                            if (newUrl.IndexOf("://", System.StringComparison.Ordinal) == -1)
                            {
                                // Doesn't have a URL Schema, meaning it's a relative or absolute URL
                                Uri u = new Uri(new Uri(url), newUrl);
                                newUrl = u.ToString();
                            }
                            break;
                        default:
                            return newUrl;
                    }
                    url = newUrl;
                }
                catch (WebException err)
                {
                    newUrl = err.Response.Headers["Location"];
                    if (newUrl == null)
                        return url;

                    if (newUrl == url)
                        return newUrl; // don't keep doing the same thing

                    if (newUrl.IndexOf("://", System.StringComparison.Ordinal) == -1)
                    {
                        // Doesn't have a URL Schema, meaning it's a relative or absolute URL
                        Uri u = new Uri(new Uri(url), newUrl);
                        newUrl = u.ToString();
                    }
                }
                catch (Exception err)
                {
                    return null;
                }
                finally
                {
                    if (resp != null)
                        resp.Close();
                }
            } while (maxRedirCount-- > 0);

            return newUrl;
        }
    }
}
