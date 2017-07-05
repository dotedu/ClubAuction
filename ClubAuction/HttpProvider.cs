using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ClubAuction
{
    public  class HttpProvider
    {
        string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";
        string MobileUserAgent { get; set; } = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.23 Mobile Safari/537.36";
        public IDictionary<string, string> DicLocalinfo = new Dictionary<string, string>();
        CookieContainer mCookieContainer = new CookieContainer();

        string Service = "http://club.huawei.com/plugin.php?id=hwlogin:validate&ru=" + HttpUtility.UrlEncode("http://club.huawei.com/auction.html");
        string Referer = "https://hwid1.vmall.com/CAS/portal/loginAuth.html?lang=zh-cn&validated=true&service=http%3A%2F%2Fclub.huawei.com%2Fplugin.php%3Fid%3Dhwlogin%3Avalidate%26ru%3Dhttp%253A%252F%252Fclub.huawei.com%252Fauction.html&loginChannel=22000000&reqClientType=22&adUrl=https%3A%2F%2Fclub.huawei.com%2Fsource%2Fplugin%2Fhwlogin%2Flogin.php";
        string callbcakURL { get; set; }


        string replayurl { get; set; }
        private static Random rd = new Random();
        double Random_DT = rd.NextDouble();

        public Action<Image> OnGetQRCodeImage;
        public Action<Image> OnchgQRCodeImage;
        public Action OnSetLocalInfo;
        public Action<bool> OnValidUser;
        public Action<int> OngetAuthCode;
        public Action<IDictionary<string, string>> OngetAccLoginInfo;
        public Action OngetAuctionInfo;
        public Action OngetAccountInfo;
        public Action OnAuthCodeTure;
        public Action OnAuthCodeFalse;
        public Action Onlogin;
        public Action OngetFormHash;
        public Action<string[]> OnEexchange;
        public Action<string[]> OnAddListItem;
        public Action OnEexchangeSuccess;
        public Action OnEexchangeOver;
        public Action OnReplaySuccess;
        public Action OnRateSuccess;
        public Action OnRateFail;

        long times;
        public long PostTime=0;



        public void Run()
        {
            //Debug.Write("获取pageToken");
            //getpageToken();
            //OnSetLocalInfo?.Invoke();


            Debug.Write("生成验证码");
            var AuthImg = getauthcode();
            OnGetQRCodeImage?.Invoke(AuthImg);
        }

        public void chgRandomCodeForLogin()
        {
            Debug.Write("刷新验证码");
            var AuthImg = getauthcode();
            OnchgQRCodeImage?.Invoke(AuthImg);


        }
        /// <summary>
        /// 
        /// </summary>
        private void getpageToken()
        {
            var client = new RestClient("https://hwid1.vmall.com/CAS/portal/loginAuth.html");
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("lang", "zh-cn");
            request.AddQueryParameter("validated", "true");
            request.AddQueryParameter("service", Service);
            request.AddQueryParameter("loginChannel", "22000000");
            request.AddQueryParameter("reqClientType", "22");
            request.AddQueryParameter("adUrl", "https://club.huawei.com/source/plugin/hwlogin/login.php");


            IRestResponse response = client.Execute(request);
            var result = response.Content;
            var strlocalInfo = GetValue(result, "localInfo={\r\n", "};");

            strlocalInfo = strlocalInfo.Replace(" ", "").Replace("	", "").Replace(",", "");
            string[] localInfoline = strlocalInfo.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in localInfoline)
            {
                //Debug.Write(item);
                string[] strArray = item.Split(new char[] { ':' }, 2);
                DicLocalinfo.Add(strArray[0], strArray[1].Replace("\"", ""));
            }
            //Debug.Write(DicLocalinfo["pageToken"]);
            foreach (var item in response.Cookies)
            {
                Debug.Write(item.Name + ":" + item.Value);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Image getauthcode()
        {
            var client = new RestClient("https://hwid1.vmall.com/CAS/authCodeImage");
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("session_code_key", "login_session_ramdom_code_key");
            request.AddQueryParameter("_t", GetTimeStamp(DateTime.Now).ToString());

            client.UserAgent = UserAgent;
            IRestResponse response = client.Execute(request);
            Debug.Write(GetTimeStamp(DateTime.Now)- GetTimeStamp(Convert.ToDateTime(response.Headers[1].Value)));
            MemoryStream ms = new MemoryStream(response.RawBytes);
            Image image = Image.FromStream(ms);
            return image;
        }


        /// <summary>
        /// 是否存在此账户
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        private bool isExsitUser(string userAccount)
        {
            var client = new RestClient("https://hwid1.vmall.com/CAS/ajaxHandler/isExsitUser?reflushCode=" + Random_DT);
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.POST);
            client.UserAgent = UserAgent;

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("referer", Referer);
            request.AddHeader("origin", "https://hwid1.vmall.com");

            request.AddParameter("reqClientType", 22);
            //request.AddParameter("pageToken", DicLocalinfo["pageToken"]);
            request.AddParameter("userAccount", userAccount);
            try
            {

                IRestResponse response = client.Execute(request);
                Debug.Write(GetTimeStamp(DateTime.Now) - GetTimeStamp(Convert.ToDateTime(response.Headers[1].Value)));
                var resultJS = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                Debug.Write(response.Content);
                if (resultJS.ContainsKey("existAccountFlag"))
                {
                    if (resultJS["existAccountFlag"].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
        /// <summary>
        /// 是否允许此账户
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        private bool isEnableUser(string userAccount)
        {
            var client = new RestClient("http://www.emui.me/isenableuser.php");
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.POST);
            client.UserAgent = UserAgent;

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("userAccount", userAccount);
            try
            {

                IRestResponse response = client.Execute(request);
                var resultJS = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                Debug.Write(response.Content);
                if (resultJS.ContainsKey("existAccountFlag"))
                {
                    if (resultJS["existAccountFlag"].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
        public bool isValidUser(string userAccount)
        {
            var isValiduser = (isExsitUser(userAccount) && isEnableUser(userAccount));

            OnValidUser?.Invoke(isValiduser);
            return isValiduser;

        }
        public UserAccount getUserAccount(string userAccount)
        {
            var client = new RestClient("https://hwid1.vmall.com/CAS/ajaxHandler/getUserAccInfo?reflushCode=" + Random_DT);
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.POST);
            client.UserAgent = UserAgent;

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("referer", Referer);
            request.AddHeader("origin", "https://hwid1.vmall.com");
            request.AddParameter("userAccount", userAccount);
            request.AddParameter("reqClientType", 22);
            request.AddParameter("operType", 3);
            //request.AddParameter("pageToken", DicLocalinfo["pageToken"]);

            try
            {

                IRestResponse response = client.Execute(request);
                Debug.Write(response.Content);
                return JsonConvert.DeserializeObject<UserAccount>(response.Content);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;

        }

        /// <summary>
        /// 判断验证码是否正确
        /// </summary>
        /// <param name="authcode"></param>
        /// <returns></returns>
        public bool isAuthCodeValidate(string authcode)
        {
            var client = new RestClient("https://hwid1.vmall.com/CAS/ajaxHandler/authCodeValidate?reflushCode=0.27883266924365446");
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.POST);
            client.UserAgent = UserAgent;

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("referer", Referer);
            request.AddHeader("origin", "https://hwid1.vmall.com");
            request.AddParameter("session_code_key", "login_session_ramdom_code_key");
            //request.AddParameter("pageToken", DicLocalinfo["pageToken"]);
            request.AddParameter("randomCode", authcode);
            try
            {
                IRestResponse response = client.Execute(request);
                var resultJS = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                Debug.Write(response.Content);
                if (Convert.ToInt32(resultJS["isSuccess"]) == 1)

                {
                    OnAuthCodeTure?.Invoke();
                    return true;

                }
                else
                {
                    OnAuthCodeFalse?.Invoke();
                    return false;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            OnAuthCodeFalse?.Invoke();

            return false;

        }


        public void login(string userAccount, string password, string authcode, string twoStepVerifyCode, string verifyAccountType, string verifyUserAccount)
        {
            //Debug.Write(DicLocalinfo["pageToken"]);
            var client = new RestClient("https://hwid1.vmall.com/CAS/ajaxHandler/remoteLogin?reflushCode=0.6837099514074068");
            client.UserAgent = UserAgent;
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("referer", Referer);
            request.AddHeader("origin", "https://hwid1.vmall.com");

            request.AddParameter("submit", "true");
            request.AddParameter("loginUrl", "https://hwid1.vmall.com/CAS/portal/loginAuth.html");
            request.AddParameter("service", "http://club.huawei.com/plugin.php?id=hwlogin:validate&ru=http%3A%2F%2Fclub.huawei.com%2Fauction.html");
            request.AddParameter("loginChannel", 22000000);
            request.AddParameter("reqClientType", 22);
            request.AddParameter("adUrl", "");
            request.AddParameter("lang", "zh-cn");
            request.AddParameter("inviterUserID", "");
            request.AddParameter("inviter", "");
            request.AddParameter("userAccount", userAccount);
            request.AddParameter("password", password);
            request.AddParameter("authcode", authcode);
            //request.AddParameter("pageToken", DicLocalinfo["pageToken"]);
            request.AddParameter("quickAuth", "false");
            request.AddParameter("newsign", "");
            request.AddParameter("isThirdBind", 0);
            request.AddParameter("remember_name", "off");
            request.AddParameter("siteID", 1);

            if (twoStepVerifyCode != null)
            {
                request.AddParameter("remember_client_flag", "off");
                request.AddParameter("opType", 1);
                request.AddParameter("twoStepVerifyCode", twoStepVerifyCode);
                request.AddParameter("verifyAccountType", verifyAccountType);
                request.AddParameter("verifyUserAccount", verifyUserAccount);

            }

            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            try
            {
                IRestResponse response = client.Execute(request);
                Debug.Write(response.Content);
                var resultJS = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                if (resultJS.ContainsKey("callbackURL"))
                {
                    callbcakURL = resultJS["callbackURL"].ToString();
                    LoginResult.isSuccess = 1;
                    Debug.Write(callbcakURL);
                }
                else
                {
                    if (resultJS.ContainsKey("errorCode"))
                    {
                        LoginResult.errorCode = resultJS["errorCode"].ToString();
                        LoginResult.errorDesc = resultJS["errorDesc"].ToString();

                    }
                }

                foreach (var item in response.Cookies)
                {
                    Debug.Write(item.Name + ":" + item.Value);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }


        public void getAuthCode(int verifyAccountType, string verifyUserAccount, string userAccount)
        {

            Uri url = (verifyAccountType == 1 || verifyAccountType == 5) ? new Uri("https://hwid1.vmall.com/CAS/ajaxHandler/getEMailAuthCode?reflushCode=" + Random_DT) : new Uri("https://hwid1.vmall.com/CAS/ajaxHandler/getSMSAuthCode?reflushCode=" + Random_DT);
            var client = new RestClient(url);
            client.CookieContainer = mCookieContainer;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("referer", Referer);
            request.AddHeader("origin", "https://hwid1.vmall.com");

            request.AddParameter("reqClientType", 22);
            request.AddParameter("operType", 8);
            request.AddParameter("siteID", 1);
            request.AddParameter("languageCode", "zh-cn");
            request.AddParameter("userAccount", userAccount);
            //request.AddParameter("pageToken", DicLocalinfo["pageToken"]);

            if (verifyAccountType == 1 || verifyAccountType == 5)
            {
                request.AddParameter("accountType", 1);
                request.AddParameter("emailReqType", 6);
                request.AddParameter("email", verifyUserAccount);
            }
            else
            {
                request.AddParameter("accountType", 2);
                request.AddParameter("smsReqType", 6);
                request.AddParameter("mobilePhone", verifyUserAccount);

            }
            try
            {

                IRestResponse response = client.Execute(request);
                var resultJS = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                Debug.Write(response.Content);
                if (resultJS.ContainsKey("isSuccess"))
                {
                    if (resultJS["isSuccess"].ToString() == "1")
                    {
                        VerifyResult.isSuccess = 1;

                    }
                    else
                    {
                        if (resultJS.ContainsKey("errorCode"))
                        {
                            VerifyResult.errorCode = resultJS["errorCode"].ToString();
                            VerifyResult.errorDesc = resultJS["errorDesc"].ToString();

                        }
                    }

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void getAccountInfo()
        {
            var client = new RestClient("http://club.huawei.com/plugin.php?id=auction&action=mydetail&inajax=1&ajaxtarget=userinfo");
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                AccountInfo.UserName = GetValue(result, "您好，", "</p>");
                AccountInfo.MoneyNum = GetValue(result, "可用余额</a>：<em>", "</em>");
                AccountInfo.Avatar = GetValue(result, "src=\"", "\"");

                OngetAccountInfo?.Invoke();

                foreach (var item in response.Cookies)
                {
                    Debug.Write(item.Name + ":" + item.Value);
                }

                //return username + moneynum + avatar;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public Image getAvatar()
        {
            var client = new RestClient(AccountInfo.Avatar);
            client.CookieContainer = mCookieContainer;
            var request = new RestRequest(Method.GET);

            client.UserAgent = UserAgent;
            IRestResponse response = client.Execute(request);
            MemoryStream ms = new MemoryStream(response.RawBytes);
            Image image = Image.FromStream(ms);
            return image;
        }
        public void getAuctionInfo()
        {
            var client = new RestClient(callbcakURL);
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.ClearHandlers();
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                LoginResult.formhash = GetValue(result, "formhash=", "\"");
                AccountInfo.UserUid = GetValue(result, "uid=", "\"");

                OngetFormHash?.Invoke();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);

                HtmlNode userinfo=doc.DocumentNode.SelectSingleNode("//div[@class='logbar']");
                
                AccountInfo.UserName = userinfo.SelectSingleNode("//p[@class='ln1']").InnerText;
                AccountInfo.MoneyNum = userinfo.SelectSingleNode("//p[@class='ln2']").InnerText.Replace("花瓣","");
                AccountInfo.Avatar = userinfo.SelectSingleNode("img").Attributes["src"].Value;

                Onlogin?.Invoke();

                

                HtmlNode auctionnode = doc.GetElementbyId("auction_content");
                HtmlNode[] Auctionlist = auctionnode.Descendants("a").ToArray();


                foreach (var subitem in Auctionlist)
                {
                    string ss=subitem.OuterHtml;
                    HtmlDocument Auction1 = new HtmlDocument();
                    Auction1.LoadHtml(ss);
                    var list = new string[6];

                    list[0] = Auction1.DocumentNode.SelectSingleNode("//h2").InnerText;
                    list[1] = Auction1.DocumentNode.SelectSingleNode("//p[@class='hb-count']").InnerText.Replace(" ","");
                    var s1 = subitem.Attributes["href"].Value;
                    list[2] = subitem.Attributes["href"].Value.Substring(39);
                    var Detail = getDetail(list[2]);

                    list[3] = Detail[0];

                    list[4] = Detail[1];
                    list[5] = Detail[2];


                    OnAddListItem?.Invoke(list);

                }


                foreach (var item in response.Cookies)
                {
                    Debug.Write(item.Name + ":" + item.Value);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public void RefreshGiftList()
        {
            var client = new RestClient("http://club.huawei.com/plugin.php?id=auction");
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.ClearHandlers();
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
    
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);

                HtmlNode auctionnode = doc.GetElementbyId("auction_content");
                HtmlNode[] Auctionlist = auctionnode.Descendants("a").ToArray();


                foreach (var subitem in Auctionlist)
                {
                    string ss = subitem.OuterHtml;
                    HtmlDocument Auction1 = new HtmlDocument();
                    Auction1.LoadHtml(ss);
                    var list = new string[6];

                    list[0] = Auction1.DocumentNode.SelectSingleNode("//h2").InnerText;
                    list[1] = Auction1.DocumentNode.SelectSingleNode("//p[@class='hb-count']").InnerText.Replace(" ", "");
                    list[2] = subitem.Attributes["href"].Value.Substring(39);
                    var Detail = getDetail(list[2]);

                    list[3] = Detail[0];

                    list[4] = Detail[1];
                    list[5] = Detail[2];


                    OnAddListItem?.Invoke(list);

                }


      

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }


        public string[] getDetail(string giftid)
        {
            Uri url = new Uri("http://club.huawei.com/plugin.php?id=auction:detail&tid="+ giftid);
            var client = new RestClient(url);
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.ClearHandlers();
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);

                HtmlNode dettable = doc.DocumentNode.SelectSingleNode("//table[@class='det-table']");
                var detTable = new HtmlDocument();
                detTable.LoadHtml(dettable.OuterHtml);
                HtmlNode starttime= detTable.DocumentNode.SelectSingleNode("//table//tr[3]//td[1]");
                HtmlNode endtime = detTable.DocumentNode.SelectSingleNode("//table//tr[4]//td[1]");

                HtmlNode detdetail = doc.DocumentNode.SelectSingleNode("//div[@class='det-detail']");
                var detDetail = new HtmlDocument();
                detDetail.LoadHtml(detdetail.OuterHtml);
                HtmlNode giftstaus = detDetail.DocumentNode.SelectSingleNode("//div//a[1]");
                var arr = new string[3];
                arr[0] = giftstaus.InnerText;
                arr[1]= starttime.InnerText.Replace("开始时间 : ", "");
                arr[2] = endtime.InnerText.Replace("结束时间 : ", "");
                return arr;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }
        public void getMoreAuctionlist(int pageid)
        {
            Uri url = new Uri("http://club.huawei.com/auction-action-index-page-" + pageid + ".html");
            var client = new RestClient(url);
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.ClearHandlers();
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(response.Content);

                HtmlNode auctionnode = doc.DocumentNode.SelectSingleNode("//div[@class='gifts-container']");

                HtmlNode[] Auctionlist = auctionnode.Descendants("a").ToArray();

                foreach (var subitem in Auctionlist)
                {
                    string ss = subitem.OuterHtml;
                    HtmlDocument Auction = new HtmlDocument();
                    Auction.LoadHtml(ss);

                    var list = new string[6];

                    list[0] = subitem.Attributes["title"].Value;
                    list[1] = Auction.DocumentNode.SelectSingleNode("//p[@class='now-price']").InnerText;
                    var s1 = subitem.Attributes["href"].Value;
                    list[2] = GetValue(subitem.Attributes["href"].Value,"thread-","-");
                    var Detail = getDetail(list[2]);

                    list[3] = Detail[0];

                    list[4] = Detail[1];
                    list[5] = Detail[2];


                    OnAddListItem?.Invoke(list);

                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public void Eexchange(string index,string aucid, string starttime, string realname, string mobile, string address, string remark)
        {
            Uri url = new Uri("https://club.huawei.com/plugin.php?id=auction:involve&operation=join&tid=" + aucid);
            var client = new RestClient(url);
            client.CookieContainer = mCookieContainer;
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("realname", realname);
            request.AddParameter("mobile", mobile);
            request.AddParameter("address", address);
            request.AddParameter("auc_reply_message", remark);
            request.AddParameter("formhash", LoginResult.formhash);
            request.AddParameter("confirmsubmit", "确认兑换");
            var t1 = GetRemoteTime();
            Debug.Write(t1);
            Debug.Write(GetTime(t1.ToString()));
            
            var t2 = GetTimeStamp(Convert.ToDateTime(starttime)) > PostTime ? GetTimeStamp(Convert.ToDateTime(starttime)) : PostTime;
            var d0 = GetTimeStamp(Convert.ToDateTime(starttime))-PostTime >= 5000 ?2200:5100;
            if (t1 >= t2)
            {
                //Debug.Write(GetTimeStamp(DateTime.Now));
                //Debug.Write(GetTimeStamp(Convert.ToDateTime(starttime)));

                //Delay(3200);
                Delay(d0 - Convert.ToInt32(t1 + times - t2));
                //Debug.Write(GetTimeStamp(DateTime.Now));
                try
                {
                    IRestResponse response = client.Execute(request);
                    var t0 = GetTimeStamp(DateTime.Now);
                    //Debug.Write(GetTimeStamp(DateTime.Now) - GetTimeStamp(Convert.ToDateTime(response.Headers[1].Value)));
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(response.Content);


                    var MessageText = doc.DocumentNode.SelectSingleNode("//p[@class='mp-t']").InnerText;
                    if (MessageText.Contains("交易已经结束"))
                    {
                        MessageText = "已结束";
                    }
                    if (MessageText.Contains("成功"))
                    {
                        PostTime = t0;
                        OnEexchangeSuccess?.Invoke();

                    }

                    string[] arr = new string[2];
                    arr[0] = index;
                    arr[1] = MessageText;
                    OnEexchange?.Invoke(arr);

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public void EexchangebyId(string aucid,string starttime, string realname, string mobile, string address, string remark)
        {
            Uri url = new Uri("https://club.huawei.com/plugin.php?id=auction:involve&operation=join&tid=" + aucid);
            var client = new RestClient(url);
            client.CookieContainer = mCookieContainer;
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("realname", realname);
            request.AddParameter("mobile", mobile);
            request.AddParameter("address", address);
            request.AddParameter("auc_reply_message", remark);
            request.AddParameter("formhash", LoginResult.formhash);
            request.AddParameter("confirmsubmit", "确认兑换");
            var t1 = GetRemoteTime();
            var t2 = GetTimeStamp(Convert.ToDateTime(starttime)) > PostTime ? GetTimeStamp(Convert.ToDateTime(starttime)) : PostTime;
            var d0 = GetTimeStamp(Convert.ToDateTime(starttime)) - PostTime >= 5000 ? 2200 : 5100;
            if (t1 >= t2)
            {
                //Debug.Write(GetTimeStamp(DateTime.Now));

                Delay(d0 - Convert.ToInt32(t1 + times - t2));
                //Debug.Write(GetTimeStamp(DateTime.Now));

                try
                {

                    IRestResponse response = client.Execute(request);
                    var t0= GetTimeStamp(DateTime.Now);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(response.Content);


                    var MessageText = doc.DocumentNode.SelectSingleNode("//p[@class='mp-t']").InnerText;
                    if (MessageText.Contains("交易已经结束"))
                    {
                        OnEexchangeOver?.Invoke();
                    }
                    if (MessageText.Contains("成功"))
                    {
                        PostTime = t0;
                        OnEexchangeSuccess?.Invoke();

                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public void qiandao()
        {
            var client = new RestClient("http://club.huawei.com/plugin.php?id=dsu_paulsign:sign");
            client.CookieContainer = mCookieContainer;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("operation", "qiandao");
            request.AddParameter("formhash", LoginResult.formhash);
            try
            {
                IRestResponse response = client.Execute(request);
           }
            catch (Exception)
            {

                throw;
            }

        }

        public void Reply(string uid, string ReplyStr)
        {
            GetReplyUrl(uid);

            var client = new RestClient(replayurl);
            client.CookieContainer = mCookieContainer;
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("message", ReplyStr);
            request.AddParameter("formhash", LoginResult.formhash);
            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                Debug.Write(result);
                if (result.Contains("发布成功"))
                {
                    OnReplaySuccess?.Invoke(); 
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void GetReplyUrl(string uid)
        {
            var client = new RestClient("http://club.huawei.com/forum.php?mod=viewthread&tid=" + uid);
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.ClearHandlers();
            client.UserAgent = MobileUserAgent;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);

                HtmlNode postform = doc.DocumentNode.SelectSingleNode("//form[@id='fastpostform']");
                HtmlAttributeCollection attrs = postform.Attributes;
                foreach (var item in attrs)
                {
                    if (item.Name.Contains("action"))
                    {
                        replayurl = "http://club.huawei.com/" + item.Value.Replace("&amp;", "&") + "&handlekey=fastpost&loc=1&inajax=1";
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }


        }


        public void Rate(string tid, string score1, string score3, string score5, string reason)
        {
            var pid = GetPid(tid);

            var client = new RestClient("http://club.huawei.com/forum.php?mod=misc&action=rate&ratesubmit=yes&infloat=yes&inajax=1");
            client.CookieContainer = mCookieContainer;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("formhash", LoginResult.formhash);
            request.AddParameter("tid", tid);
            request.AddParameter("pid", pid);
            request.AddParameter("referer", "http://club.huawei.com/forum.php?mod=viewthread&tid=" + tid + "&page=0#pid" + pid);
            request.AddParameter("handlekey", "rate");
            request.AddParameter("score1", score1);
            request.AddParameter("score3", score3);
            request.AddParameter("score5", score5);
            request.AddParameter("reason", reason);

            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                Debug.Write(result);
                if (result.Contains("感谢"))
                {
                    OnRateSuccess?.Invoke();
                }
                else if (result.Contains("限制"))
                {
                    OnRateFail?.Invoke();

                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        private string GetPid(string uid)
        {
            var client = new RestClient("http://club.huawei.com/thread-" + uid + "-1-1.html");
            client.CookieContainer = mCookieContainer;
            //client.FollowRedirects = false;
            client.ClearHandlers();
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);

                HtmlNode postform = doc.DocumentNode.SelectSingleNode("//a[@id='ak_rate']");

                var str = postform.OuterHtml;
                var pattern = @"pid=\d+";
                Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                Match m = r.Match(str);
                return m.ToString().Replace("pid=", "");

            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
                return "";
            }


        }

        public void heartbeat()
        {
            var client = new RestClient("http://club.huawei.com/plugin.php?id=auction&action=mydetail&inajax=1&ajaxtarget=userinfo");
            client.CookieContainer = mCookieContainer;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                Debug.Write(response.Headers);

                Debug.Write("发送心跳");
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public long checktime(long t1)
        {
            var client = new RestClient("http://club.huawei.com/plugin.php?id=auction");
            client.CookieContainer = mCookieContainer;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.GET);
            //Debug.Write(GetTimeStamp(DateTime.Now));

            
            try
            {
                IRestResponse response = client.Execute(request);
                var t3 = GetTimeStamp(DateTime.Now);
                //Debug.Write(GetTimeStamp(DateTime.Now));

                foreach (var item in response.Headers)
                {
                    if (item.Name=="Date")
                    {
                        var t2 = GetTimeStamp(Convert.ToDateTime(item.Value));
                        //Debug.Write(t2);
                        return t1 + (t3 - t1) / 2 - t2;
                    }
                }


            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return 0;
        }

        public long GetRemoteTime()
        {
            var client = new RestClient("http://club.huawei.com/plugin.php?id=auction");
            client.CookieContainer = mCookieContainer;
            client.UserAgent = UserAgent;
            var request = new RestRequest(Method.GET);

            try
            {

                var t1 = GetTimeStamp(DateTime.Now);
                IRestResponse response = client.Execute(request);

                times = (GetTimeStamp(DateTime.Now)- t1)/2;
                foreach (var item in response.Headers)
                {
                    if (item.Name == "Date")
                    {
                        var t2 = GetTimeStamp(Convert.ToDateTime(item.Value));
                        //Debug.Write(t2);
                        return t2;
                    }
                }


            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return 0;
        }


        private static string GetValue(string str, string s, string e)
        {
            
            var rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }

        private long GetTimeStamp(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (dateTime.Ticks - dt1970.Ticks) / 10000;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        private int DateTimeToStamp(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        public void Delay(int mm)
        {
            DateTime current = DateTime.Now;

            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            return;
        }
    }
}
