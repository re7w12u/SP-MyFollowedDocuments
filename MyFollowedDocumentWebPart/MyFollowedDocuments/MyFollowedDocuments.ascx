<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFollowedDocuments.ascx.cs" Inherits="MyFollowedDocumentWebPart.MyFollowedDocuments.MyFollowedDocuments" %>



<script type="text/javascript">

    $(function () {

        var myFollow = new MyFollowed();
        myFollow.displayLoading();

        SP.SOD.executeOrDelayUntilScriptLoaded(function () {
            SP.SOD.registerSod('SP.UserProfiles.js', SP.Utilities.Utility.getLayoutsPageUrl("SP.UserProfiles.js"));
            SP.SOD.executeFunc('SP.UserProfiles.js', 'SP.UserProfiles.PeopleManager', function () { myFollow.init(); });
        }, "SP.js");

    });

    function MyFollowed() {

        this.wrapper = $("#myFollowedDocWrapper");

        this.init = function () {
            this.CheckMySite();
        };

        this.displayLoading = function () {
            this.wrapper.append($('<img src="' + _spPageContextInfo.webServerRelativeUrl + '/_layouts/15/images/gears_anv4.gif" style="width: 15px;"/><span style="margin-left: 10px;vertical-align: 3px;">loading</span>'));
        }

        this.CheckMySite = function () {
            this.getPersonalUrl().done(function (result, url) {
                this.wrapper.empty();
                if (result) this.getMyFollowedDocuments(this.wrapper);
                else this.wrapper.append($('<div><a href="' + url + '">Click here to enable this feature</a></div>'));
            }.bind(this));
        }

        this.getPersonalUrl = function () {
            var d = $.Deferred();
            var context = SP.ClientContext.get_current();
            var peopleManager = new SP.UserProfiles.PeopleManager(context);
            userProfileProperties = peopleManager.getMyProperties();
            context.load(userProfileProperties, 'PersonalUrl');
            context.executeQueryAsync(
                function () {
                    var url = userProfileProperties.get_personalUrl();
                    if (url.indexOf('Person.aspx') == -1) {
                        // user has a MySite already created - fetch documents
                        d.resolve(true);
                    } else {
                        // user does not have MySite created - display link
                        d.resolve(false, url);
                    }
                }.bind(this),
                this.onQueryFailed
            );

            return d.promise();
        };

        this.getMyFollowedDocuments = function (wrapper) {
            var uri = _spPageContextInfo.webServerRelativeUrl + "/_api/social.following/my/followed(types=2)";

            $.ajax({
                url: uri,
                headers: { "Accept": "application/json; odata=verbose" },
                success: function (data) {
                    var items = [];
                    $.each(data.d.Followed.results, function (k, v) {

                        var id = "fDoc_" + k;
                        items.push('<div id="' + id + '"><span class="ms-contentFollowing-itemTitle"> \
                                    <span style="height: 16px; width: 16px; position: relative; display: inline-block; overflow: hidden;" class="s4-clust ms-promotedActionButton-icon">\
                                        <a href="#" onclick="StopFollowDocument(\'' + id + '\',\'' + v.ContentUri + '\');">\
                                            <img src="/_layouts/15/images/NowFollowing.11x11x32.png?rev=23" alt="Follow" style="vertical-align:3px;"/></a>\
                                    </span>\
                                    <a href="' + v.ContentUri + '" class="js-contentFollowing-itemLink ms-textLarge ms-recs-titleLink" >' + v.Name + '</a></span></div>');

                        //            <div class="js-contentFollowing-itemUrlDiv"><a href="'+ v.ContentUri + '>' + v.ContentUri + '</a>');
                        //                    items.push("<li id='" + v.ContentUri + "'>" + v.Name + "</li>");
                    });

                    $("<div/>", { "class": "", html: items.join("") }).appendTo(wrapper);
                }
            });
        }

        this.onQueryFailed = function () {
            console.error("Error");
        };

    }

    /// required to ensure latest FormDigestValue to prevent 403 error
    function getFormDigest(webUrl) {
        return $.ajax({
            url: webUrl + "/_api/contextinfo",
            method: "POST",
            headers: { "Accept": "application/json; odata=verbose" }
        });
    }

    function StopFollowDocument(id, docUri) {

        if (confirm("You are about to remove that document from your list of followed documents. Click OK to proceed.")) {


            getFormDigest(_spPageContextInfo.webServerRelativeUrl).then(function (data) {

                //http://<siteCollection>/<site>/_api/social.following/stopfollowing(ActorType=1,ContentUri=@v,Id=null)?@v='http://server/Shared%20Documents/fileName.docx'
                //var uri = "http://" + window.location.hostname + "/_api/social.following/stopfollowing(ActorType=1,ContentUri=@v,Id=null)?@v='" + docUri + "'";
                var uri = _spPageContextInfo.webServerRelativeUrl + "/_api/social.following/stopfollowing";

                var body = JSON.stringify({
                    "actor": {
                        "__metadata": { "type": "SP.Social.SocialActorInfo" },
                        "ActorType": 1,
                        "ContentUri": docUri,
                        "Id": null
                    }
                });

                var headers = {
                    "accept": "application/json; odata=verbose",
                    "content-type": "application/json;odata=verbose",
                    "X-RequestDigest": data.d.GetContextWebInformation.FormDigestValue
                };

                $.ajax({
                    url: uri,
                    method: "POST",
                    headers: headers,
                    data: body,
                    success: function (data) {
                        $("#" + id).remove();
                    },
                    error: function (xhr, status, error) {
                        console.error(status);
                        console.error(error);
                    }
                });



            });
        }

    }
</script>

<div id="myFollowedDocWrapper">
</div>
