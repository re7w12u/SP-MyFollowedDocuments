﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFollowedDocumentWebPart.MyFollowedDocuments {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class MyFollowedDocuments {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "12.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(MyFollowedDocuments target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControlTree(global::MyFollowedDocumentWebPart.MyFollowedDocuments.MyFollowedDocuments @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    $(function () {\r\n\r\n        var myF" +
                        "ollow = new MyFollowed();\r\n        myFollow.displayLoading();\r\n\r\n        SP.SOD." +
                        "executeOrDelayUntilScriptLoaded(function () {\r\n            SP.SOD.registerSod(\'S" +
                        "P.UserProfiles.js\', SP.Utilities.Utility.getLayoutsPageUrl(\"SP.UserProfiles.js\")" +
                        ");\r\n            SP.SOD.executeFunc(\'SP.UserProfiles.js\', \'SP.UserProfiles.People" +
                        "Manager\', function () { myFollow.init(); });\r\n        }, \"SP.js\");\r\n\r\n    });\r\n\r" +
                        "\n    function MyFollowed() {\r\n\r\n        this.wrapper = $(\"#myFollowedDocWrapper\"" +
                        ");\r\n\r\n        this.init = function () {\r\n            this.CheckMySite();\r\n      " +
                        "  };\r\n\r\n        this.displayLoading = function () {\r\n            this.wrapper.ap" +
                        "pend($(\'<img src=\"\' + SP.Utilities.Utility.getLayoutsPageUrl(\"images/gears_anv4." +
                        "gif\") + \'style=\"width: 15px;\"/><span style=\"margin-left: 10px;vertical-align: 3p" +
                        "x;\">loading</span>\'));\r\n        }\r\n\r\n        this.CheckMySite = function () {\r\n " +
                        "           this.getPersonalUrl().done(function (result, url) {\r\n                " +
                        "this.wrapper.empty();\r\n                if (result) this.getMyFollowedDocuments(t" +
                        "his.wrapper);\r\n                else this.wrapper.append($(\'<div><a href=\"\' + url" +
                        " + \'\">Click here to enable this feature</a></div>\'));\r\n            }.bind(this))" +
                        ";\r\n        }\r\n\r\n        this.getPersonalUrl = function () {\r\n            var d =" +
                        " $.Deferred();\r\n            var context = SP.ClientContext.get_current();\r\n     " +
                        "       var peopleManager = new SP.UserProfiles.PeopleManager(context);\r\n        " +
                        "    userProfileProperties = peopleManager.getMyProperties();\r\n            contex" +
                        "t.load(userProfileProperties, \'PersonalUrl\');\r\n            context.executeQueryA" +
                        "sync(\r\n                function () {\r\n                    var url = userProfileP" +
                        "roperties.get_personalUrl();\r\n                    if (url.indexOf(\'Person.aspx\')" +
                        " == -1) {\r\n                        // user has a MySite already created - fetch " +
                        "documents\r\n                        d.resolve(true);\r\n                    } else " +
                        "{\r\n                        // user does not have MySite created - display link\r\n" +
                        "                        d.resolve(false, url);\r\n                    }\r\n         " +
                        "       }.bind(this),\r\n                this.onQueryFailed\r\n            );\r\n\r\n    " +
                        "        return d.promise();\r\n        };\r\n\r\n        this.getMyFollowedDocuments =" +
                        " function (wrapper) {\r\n            var uri = _spPageContextInfo.webAbsoluteUrl +" +
                        " \"/_api/social.following/my/followed(types=2)\";\r\n\r\n            $.ajax({\r\n       " +
                        "         url: uri,\r\n                headers: { \"Accept\": \"application/json; odat" +
                        "a=verbose\" },\r\n                success: function (data) {\r\n                    v" +
                        "ar items = [];\r\n                    $.each(data.d.Followed.results, function (k," +
                        " v) {\r\n\r\n                        var id = \"fDoc_\" + k;\r\n                        " +
                        "items.push(\'<div id=\"\' + id + \'\"><span class=\"ms-contentFollowing-itemTitle\"> \\\r" +
                        "\n                                    <span style=\"height: 16px; width: 16px; pos" +
                        "ition: relative; display: inline-block; overflow: hidden;\" class=\"s4-clust ms-pr" +
                        "omotedActionButton-icon\">\\\r\n                                        <a href=\"#\" " +
                        "onclick=\"StopFollowDocument(\\\'\' + id + \'\\\',\\\'\' + v.ContentUri + \'\\\');\">\\\r\n      " +
                        "                                      <img src=\"/_layouts/15/images/NowFollowing" +
                        ".11x11x32.png?rev=23\" alt=\"Follow\" style=\"vertical-align:3px;\"/></a>\\\r\n         " +
                        "                           </span>\\\r\n                                    <a href" +
                        "=\"\' + v.ContentUri + \'\" class=\"js-contentFollowing-itemLink ms-textLarge ms-recs" +
                        "-titleLink\" >\' + v.Name + \'</a></span></div>\');\r\n\r\n                        //   " +
                        "         <div class=\"js-contentFollowing-itemUrlDiv\"><a href=\"\'+ v.ContentUri + " +
                        "\'>\' + v.ContentUri + \'</a>\');\r\n                        //                    ite" +
                        "ms.push(\"<li id=\'\" + v.ContentUri + \"\'>\" + v.Name + \"</li>\");\r\n                 " +
                        "   });\r\n\r\n                    $(\"<div/>\", { \"class\": \"\", html: items.join(\"\") })" +
                        ".appendTo(wrapper);\r\n                }\r\n            });\r\n        }\r\n\r\n        th" +
                        "is.onQueryFailed = function () {\r\n            console.error(\"Error\");\r\n        }" +
                        ";\r\n\r\n    }\r\n\r\n    /// required to ensure latest FormDigestValue to prevent 403 e" +
                        "rror\r\n    function getFormDigest(webUrl) {\r\n        return $.ajax({\r\n           " +
                        " url: webUrl + \"/_api/contextinfo\",\r\n            method: \"POST\",\r\n            he" +
                        "aders: { \"Accept\": \"application/json; odata=verbose\" }\r\n        });\r\n    }\r\n\r\n  " +
                        "  function StopFollowDocument(id, docUri) {\r\n\r\n        if (confirm(\"You are abou" +
                        "t to remove that document from your list of followed documents. Click OK to proc" +
                        "eed.\")) {\r\n\r\n\r\n            getFormDigest(_spPageContextInfo.webAbsoluteUrl).then" +
                        "(function (data) {\r\n\r\n                //http://<siteCollection>/<site>/_api/soci" +
                        "al.following/stopfollowing(ActorType=1,ContentUri=@v,Id=null)?@v=\'http://server/" +
                        "Shared%20Documents/fileName.docx\'\r\n                //var uri = \"http://\" + windo" +
                        "w.location.hostname + \"/_api/social.following/stopfollowing(ActorType=1,ContentU" +
                        "ri=@v,Id=null)?@v=\'\" + docUri + \"\'\";\r\n                var uri = _spPageContextIn" +
                        "fo.webAbsoluteUrl + \"/_api/social.following/stopfollowing\";\r\n\r\n                v" +
                        "ar body = JSON.stringify({\r\n                    \"actor\": {\r\n                    " +
                        "    \"__metadata\": { \"type\": \"SP.Social.SocialActorInfo\" },\r\n                    " +
                        "    \"ActorType\": 1,\r\n                        \"ContentUri\": docUri,\r\n            " +
                        "            \"Id\": null\r\n                    }\r\n                });\r\n\r\n          " +
                        "      var headers = {\r\n                    \"accept\": \"application/json; odata=ve" +
                        "rbose\",\r\n                    \"content-type\": \"application/json;odata=verbose\",\r\n" +
                        "                    \"X-RequestDigest\": data.d.GetContextWebInformation.FormDiges" +
                        "tValue\r\n                };\r\n\r\n                $.ajax({\r\n                    url:" +
                        " uri,\r\n                    method: \"POST\",\r\n                    headers: headers" +
                        ",\r\n                    data: body,\r\n                    success: function (data)" +
                        " {\r\n                        $(\"#\" + id).remove();\r\n                    },\r\n     " +
                        "               error: function (xhr, status, error) {\r\n                        c" +
                        "onsole.error(status);\r\n                        console.error(error);\r\n          " +
                        "          }\r\n                });\r\n\r\n\r\n\r\n            });\r\n        }\r\n\r\n    }\r\n</s" +
                        "cript>\r\n\r\n<div id=\"myFollowedDocWrapper\">\r\n</div>\r\n"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
