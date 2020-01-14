//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(OPMS.Data.Context.ContextDb),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets757edc15f117b693dfbc33e6cee6d2233952b916d11fe25453b65172fa62f5f3))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework 6 Power Tools", "0.9.2.0")]
    internal sealed class ViewsForBaseEntitySets757edc15f117b693dfbc33e6cee6d2233952b916d11fe25453b65172fa62f5f3 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "757edc15f117b693dfbc33e6cee6d2233952b916d11fe25453b65172fa62f5f3"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "CodeFirstDatabase.BlogPost")
            {
                return GetView0();
            }

            if (extentName == "CodeFirstDatabase.Tag")
            {
                return GetView1();
            }

            if (extentName == "CodeFirstDatabase.BlogPostTag")
            {
                return GetView2();
            }

            if (extentName == "ContextDb.BlogPosts")
            {
                return GetView3();
            }

            if (extentName == "ContextDb.Tags")
            {
                return GetView4();
            }

            if (extentName == "ContextDb.BlogPost_Tags")
            {
                return GetView5();
            }

            if (extentName == "CodeFirstDatabase.Contact")
            {
                return GetView6();
            }

            if (extentName == "ContextDb.Contacts")
            {
                return GetView7();
            }

            if (extentName == "CodeFirstDatabase.Menu")
            {
                return GetView8();
            }

            if (extentName == "ContextDb.Menus")
            {
                return GetView9();
            }

            if (extentName == "CodeFirstDatabase.Page")
            {
                return GetView10();
            }

            if (extentName == "CodeFirstDatabase.Sidebar")
            {
                return GetView11();
            }

            if (extentName == "ContextDb.Pages")
            {
                return GetView12();
            }

            if (extentName == "ContextDb.Sidebars")
            {
                return GetView13();
            }

            if (extentName == "CodeFirstDatabase.RoleModel")
            {
                return GetView14();
            }

            if (extentName == "CodeFirstDatabase.UserModel")
            {
                return GetView15();
            }

            if (extentName == "CodeFirstDatabase.UserModelRoleModel")
            {
                return GetView16();
            }

            if (extentName == "ContextDb.Roles")
            {
                return GetView17();
            }

            if (extentName == "ContextDb.Users")
            {
                return GetView18();
            }

            if (extentName == "ContextDb.UserModel_Roles")
            {
                return GetView19();
            }

            if (extentName == "CodeFirstDatabase.SiteSettings")
            {
                return GetView20();
            }

            if (extentName == "ContextDb.SiteSettings")
            {
                return GetView21();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.BlogPost.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing BlogPost
        [CodeFirstDatabaseSchema.BlogPost](T1.BlogPost_Id, T1.BlogPost_Title, T1.BlogPost_Slug, T1.BlogPost_Content, T1.BlogPost_BlogPostMetaDataOn, T1.BlogPost_MetaKeywords, T1.BlogPost_MetaDescription, T1.BlogPost_MetaOgImage, T1.BlogPost_IsVisibleToSearchEngine)
    FROM (
        SELECT 
            T.Id AS BlogPost_Id, 
            T.Title AS BlogPost_Title, 
            T.Slug AS BlogPost_Slug, 
            T.Content AS BlogPost_Content, 
            T.BlogPostMetaDataOn AS BlogPost_BlogPostMetaDataOn, 
            T.MetaKeywords AS BlogPost_MetaKeywords, 
            T.MetaDescription AS BlogPost_MetaDescription, 
            T.MetaOgImage AS BlogPost_MetaOgImage, 
            T.IsVisibleToSearchEngine AS BlogPost_IsVisibleToSearchEngine, 
            True AS _from0
        FROM ContextDb.BlogPosts AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Tag.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Tag
        [CodeFirstDatabaseSchema.Tag](T1.Tag_Id, T1.[Tag_Tag Name])
    FROM (
        SELECT 
            T.Id AS Tag_Id, 
            T.Name AS [Tag_Tag Name], 
            True AS _from0
        FROM ContextDb.Tags AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.BlogPostTag.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing BlogPostTag
        [CodeFirstDatabaseSchema.BlogPostTag](T1.BlogPostTag_BlogPostId, T1.BlogPostTag_TagId)
    FROM (
        SELECT 
            Key(T.BlogPost_Tags_Source).Id AS BlogPostTag_BlogPostId, 
            Key(T.BlogPost_Tags_Target).Id AS BlogPostTag_TagId, 
            True AS _from0
        FROM ContextDb.BlogPost_Tags AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.BlogPosts.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing BlogPosts
        [OPMS.Data.Context.BlogPost](T1.BlogPost_Id, T1.BlogPost_Title, T1.BlogPost_Slug, T1.BlogPost_Content, T1.BlogPost_BlogPostMetaDataOn, T1.BlogPost_MetaKeywords, T1.BlogPost_MetaDescription, T1.BlogPost_MetaOgImage, T1.BlogPost_IsVisibleToSearchEngine)
    FROM (
        SELECT 
            T.Id AS BlogPost_Id, 
            T.Title AS BlogPost_Title, 
            T.Slug AS BlogPost_Slug, 
            T.Content AS BlogPost_Content, 
            T.BlogPostMetaDataOn AS BlogPost_BlogPostMetaDataOn, 
            T.MetaKeywords AS BlogPost_MetaKeywords, 
            T.MetaDescription AS BlogPost_MetaDescription, 
            T.MetaOgImage AS BlogPost_MetaOgImage, 
            T.IsVisibleToSearchEngine AS BlogPost_IsVisibleToSearchEngine, 
            True AS _from0
        FROM CodeFirstDatabase.BlogPost AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Tags.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView4()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Tags
        [OPMS.Data.Context.Tag](T1.Tag_Id, T1.Tag_Name)
    FROM (
        SELECT 
            T.Id AS Tag_Id, 
            T.[Tag Name] AS Tag_Name, 
            True AS _from0
        FROM CodeFirstDatabase.Tag AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.BlogPost_Tags.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView5()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing BlogPost_Tags
        [OPMS.Data.Context.BlogPost_Tags](T3.[BlogPost_Tags.BlogPost_Tags_Source], T3.[BlogPost_Tags.BlogPost_Tags_Target])
    FROM (
        SELECT -- Constructing BlogPost_Tags_Source
            CreateRef(ContextDb.BlogPosts, row(T2.[BlogPost_Tags.BlogPost_Tags_Source.Id]), [OPMS.Data.Context.BlogPost]) AS [BlogPost_Tags.BlogPost_Tags_Source], 
            T2.[BlogPost_Tags.BlogPost_Tags_Target]
        FROM (
            SELECT -- Constructing BlogPost_Tags_Target
                T1.[BlogPost_Tags.BlogPost_Tags_Source.Id], 
                CreateRef(ContextDb.Tags, row(T1.[BlogPost_Tags.BlogPost_Tags_Target.Id]), [OPMS.Data.Context.Tag]) AS [BlogPost_Tags.BlogPost_Tags_Target]
            FROM (
                SELECT 
                    T.BlogPostId AS [BlogPost_Tags.BlogPost_Tags_Source.Id], 
                    T.TagId AS [BlogPost_Tags.BlogPost_Tags_Target.Id], 
                    True AS _from0
                FROM CodeFirstDatabase.BlogPostTag AS T
            ) AS T1
        ) AS T2
    ) AS T3");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Contact.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView6()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Contact
        [CodeFirstDatabaseSchema.Contact](T1.Contact_Id, T1.[Contact_Full Namme], T1.Contact_Email, T1.Contact_Address, T1.[Contact_Mobile Number], T1.Contact_IpAddres, T1.Contact_ContactedDate, T1.Contact_Message, T1.Contact_ContactedLocation)
    FROM (
        SELECT 
            T.Id AS Contact_Id, 
            T.FullName AS [Contact_Full Namme], 
            T.Email AS Contact_Email, 
            T.Address AS Contact_Address, 
            T.MobileNumber AS [Contact_Mobile Number], 
            T.IpAddres AS Contact_IpAddres, 
            T.ContactedDate AS Contact_ContactedDate, 
            T.MessageText AS Contact_Message, 
            T.ContactedLocation AS Contact_ContactedLocation, 
            True AS _from0
        FROM ContextDb.Contacts AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Contacts.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView7()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Contacts
        [OPMS.Data.Context.Contact](T1.Contact_Id, T1.Contact_FullName, T1.Contact_Email, T1.Contact_Address, T1.Contact_MobileNumber, T1.Contact_IpAddres, T1.Contact_ContactedDate, T1.Contact_MessageText, T1.Contact_ContactedLocation)
    FROM (
        SELECT 
            T.Id AS Contact_Id, 
            T.[Full Namme] AS Contact_FullName, 
            T.Email AS Contact_Email, 
            T.Address AS Contact_Address, 
            T.[Mobile Number] AS Contact_MobileNumber, 
            T.IpAddres AS Contact_IpAddres, 
            T.ContactedDate AS Contact_ContactedDate, 
            T.Message AS Contact_MessageText, 
            T.ContactedLocation AS Contact_ContactedLocation, 
            True AS _from0
        FROM CodeFirstDatabase.Contact AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Menu.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView8()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Menu
        [CodeFirstDatabaseSchema.Menu](T1.Menu_Id, T1.[Menu_Menu Title], T1.Menu_Description, T1.Menu_Url, T1.Menu_ParentId)
    FROM (
        SELECT 
            T.Id AS Menu_Id, 
            T.Title AS [Menu_Menu Title], 
            T.Description AS Menu_Description, 
            T.Url AS Menu_Url, 
            T.ParentId AS Menu_ParentId, 
            True AS _from0
        FROM ContextDb.Menus AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Menus.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView9()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Menus
        [OPMS.Data.Context.Menu](T1.Menu_Id, T1.Menu_Title, T1.Menu_Description, T1.Menu_Url, T1.Menu_ParentId)
    FROM (
        SELECT 
            T.Id AS Menu_Id, 
            T.[Menu Title] AS Menu_Title, 
            T.Description AS Menu_Description, 
            T.Url AS Menu_Url, 
            T.ParentId AS Menu_ParentId, 
            True AS _from0
        FROM CodeFirstDatabase.Menu AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Page.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView10()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Page
        [CodeFirstDatabaseSchema.Page](T1.Page_Id, T1.[Page_Page Title], T1.Page_Slug, T1.Page_Content, T1.Page_MetaKeywords, T1.Page_MetaDescription, T1.Page_IsPageMetaDataOn, T1.[Page_Sidebar Id])
    FROM (
        SELECT 
            T.Id AS Page_Id, 
            T.Title AS [Page_Page Title], 
            T.Slug AS Page_Slug, 
            T.Content AS Page_Content, 
            T.MetaKeywords AS Page_MetaKeywords, 
            T.MetaDescription AS Page_MetaDescription, 
            T.IsPageMetaDataOn AS Page_IsPageMetaDataOn, 
            T.SidebarId AS [Page_Sidebar Id], 
            True AS _from0
        FROM ContextDb.Pages AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Sidebar.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView11()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Sidebar
        [CodeFirstDatabaseSchema.Sidebar](T1.Sidebar_Id, T1.[Sidebar_Sidebar Name], T1.[Sidebar_Content Name], T1.Sidebar_PublishDate)
    FROM (
        SELECT 
            T.Id AS Sidebar_Id, 
            T.Name AS [Sidebar_Sidebar Name], 
            T.Content AS [Sidebar_Content Name], 
            T.PublishDate AS Sidebar_PublishDate, 
            True AS _from0
        FROM ContextDb.Sidebars AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Pages.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView12()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Pages
        [OPMS.Data.Context.Page](T1.Page_Id, T1.Page_Title, T1.Page_Slug, T1.Page_Content, T1.Page_MetaKeywords, T1.Page_MetaDescription, T1.Page_IsPageMetaDataOn, T1.Page_SidebarId)
    FROM (
        SELECT 
            T.Id AS Page_Id, 
            T.[Page Title] AS Page_Title, 
            T.Slug AS Page_Slug, 
            T.Content AS Page_Content, 
            T.MetaKeywords AS Page_MetaKeywords, 
            T.MetaDescription AS Page_MetaDescription, 
            T.IsPageMetaDataOn AS Page_IsPageMetaDataOn, 
            T.[Sidebar Id] AS Page_SidebarId, 
            True AS _from0
        FROM CodeFirstDatabase.Page AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Sidebars.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView13()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Sidebars
        [OPMS.Data.Context.Sidebar](T1.Sidebar_Id, T1.Sidebar_Name, T1.Sidebar_Content, T1.Sidebar_PublishDate)
    FROM (
        SELECT 
            T.Id AS Sidebar_Id, 
            T.[Sidebar Name] AS Sidebar_Name, 
            T.[Content Name] AS Sidebar_Content, 
            T.PublishDate AS Sidebar_PublishDate, 
            True AS _from0
        FROM CodeFirstDatabase.Sidebar AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.RoleModel.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView14()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing RoleModel
        [CodeFirstDatabaseSchema.RoleModel](T1.RoleModel_Id, T1.[RoleModel_Role Name])
    FROM (
        SELECT 
            T.Id AS RoleModel_Id, 
            T.Name AS [RoleModel_Role Name], 
            True AS _from0
        FROM ContextDb.Roles AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.UserModel.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView15()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing UserModel
        [CodeFirstDatabaseSchema.UserModel](T1.UserModel_Id, T1.UserModel_UserName, T1.UserModel_PhoneNumber, T1.UserModel_Email, T1.UserModel_HashPassword)
    FROM (
        SELECT 
            T.Id AS UserModel_Id, 
            T.UserName AS UserModel_UserName, 
            T.PhoneNumber AS UserModel_PhoneNumber, 
            T.Email AS UserModel_Email, 
            T.HashPassword AS UserModel_HashPassword, 
            True AS _from0
        FROM ContextDb.Users AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.UserModelRoleModel.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView16()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing UserModelRoleModel
        [CodeFirstDatabaseSchema.UserModelRoleModel](T1.UserModelRoleModel_UserId, T1.UserModelRoleModel_RoleId)
    FROM (
        SELECT 
            Key(T.UserModel_Roles_Source).Id AS UserModelRoleModel_UserId, 
            Key(T.UserModel_Roles_Target).Id AS UserModelRoleModel_RoleId, 
            True AS _from0
        FROM ContextDb.UserModel_Roles AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Roles.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView17()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Roles
        [OPMS.Data.Context.RoleModel](T1.RoleModel_Id, T1.RoleModel_Name)
    FROM (
        SELECT 
            T.Id AS RoleModel_Id, 
            T.[Role Name] AS RoleModel_Name, 
            True AS _from0
        FROM CodeFirstDatabase.RoleModel AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.Users.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView18()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Users
        [OPMS.Data.Context.UserModel](T1.UserModel_Id, T1.UserModel_UserName, T1.UserModel_PhoneNumber, T1.UserModel_Email, T1.UserModel_HashPassword)
    FROM (
        SELECT 
            T.Id AS UserModel_Id, 
            T.UserName AS UserModel_UserName, 
            T.PhoneNumber AS UserModel_PhoneNumber, 
            T.Email AS UserModel_Email, 
            T.HashPassword AS UserModel_HashPassword, 
            True AS _from0
        FROM CodeFirstDatabase.UserModel AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.UserModel_Roles.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView19()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing UserModel_Roles
        [OPMS.Data.Context.UserModel_Roles](T3.[UserModel_Roles.UserModel_Roles_Source], T3.[UserModel_Roles.UserModel_Roles_Target])
    FROM (
        SELECT -- Constructing UserModel_Roles_Source
            CreateRef(ContextDb.Users, row(T2.[UserModel_Roles.UserModel_Roles_Source.Id]), [OPMS.Data.Context.UserModel]) AS [UserModel_Roles.UserModel_Roles_Source], 
            T2.[UserModel_Roles.UserModel_Roles_Target]
        FROM (
            SELECT -- Constructing UserModel_Roles_Target
                T1.[UserModel_Roles.UserModel_Roles_Source.Id], 
                CreateRef(ContextDb.Roles, row(T1.[UserModel_Roles.UserModel_Roles_Target.Id]), [OPMS.Data.Context.RoleModel]) AS [UserModel_Roles.UserModel_Roles_Target]
            FROM (
                SELECT 
                    T.UserId AS [UserModel_Roles.UserModel_Roles_Source.Id], 
                    T.RoleId AS [UserModel_Roles.UserModel_Roles_Target.Id], 
                    True AS _from0
                FROM CodeFirstDatabase.UserModelRoleModel AS T
            ) AS T1
        ) AS T2
    ) AS T3");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.SiteSettings.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView20()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing SiteSettings
        [CodeFirstDatabaseSchema.SiteSettings](T1.SiteSettings_Id, T1.[SiteSettings_Site Name], T1.[SiteSettings_Is Site Register], T1.[SiteSettings_Site Footer], T1.SiteSettings_FavIconURL, T1.[SiteSettings_Site Owner], T1.[SiteSettings_Google Site Verification], T1.[SiteSettings_Google Ads], T1.[SiteSettings_Google Analytics], T1.SiteSettings_CustomCSS, T1.SiteSettings_IsCustomCSSOn, T1.SiteSettings_CustomJS, T1.SiteSettings_IsCustomJsOn, T1.[SiteSettings_site Last Updated], T1.[SiteSettings_Updated By])
    FROM (
        SELECT 
            T.Id AS SiteSettings_Id, 
            T.SiteName AS [SiteSettings_Site Name], 
            T.IsRegister AS [SiteSettings_Is Site Register], 
            T.SiteFooter AS [SiteSettings_Site Footer], 
            T.FavIconURL AS SiteSettings_FavIconURL, 
            T.SiteOwner AS [SiteSettings_Site Owner], 
            T.GoogleSiteVerification AS [SiteSettings_Google Site Verification], 
            T.GoogleAds AS [SiteSettings_Google Ads], 
            T.GoogleAnalytics AS [SiteSettings_Google Analytics], 
            T.CustomCSS AS SiteSettings_CustomCSS, 
            T.IsCustomCSSOn AS SiteSettings_IsCustomCSSOn, 
            T.CustomJS AS SiteSettings_CustomJS, 
            T.IsCustomJsOn AS SiteSettings_IsCustomJsOn, 
            T.SiteLastUpdated AS [SiteSettings_site Last Updated], 
            T.UpdateBy AS [SiteSettings_Updated By], 
            True AS _from0
        FROM ContextDb.SiteSettings AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ContextDb.SiteSettings.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView21()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing SiteSettings
        [OPMS.Data.Context.SiteSettings](T1.SiteSettings_Id, T1.SiteSettings_SiteName, T1.SiteSettings_IsRegister, T1.SiteSettings_SiteFooter, T1.SiteSettings_FavIconURL, T1.SiteSettings_SiteOwner, T1.SiteSettings_GoogleSiteVerification, T1.SiteSettings_GoogleAds, T1.SiteSettings_GoogleAnalytics, T1.SiteSettings_CustomCSS, T1.SiteSettings_IsCustomCSSOn, T1.SiteSettings_CustomJS, T1.SiteSettings_IsCustomJsOn, T1.SiteSettings_SiteLastUpdated, T1.SiteSettings_UpdateBy)
    FROM (
        SELECT 
            T.Id AS SiteSettings_Id, 
            T.[Site Name] AS SiteSettings_SiteName, 
            T.[Is Site Register] AS SiteSettings_IsRegister, 
            T.[Site Footer] AS SiteSettings_SiteFooter, 
            T.FavIconURL AS SiteSettings_FavIconURL, 
            T.[Site Owner] AS SiteSettings_SiteOwner, 
            T.[Google Site Verification] AS SiteSettings_GoogleSiteVerification, 
            T.[Google Ads] AS SiteSettings_GoogleAds, 
            T.[Google Analytics] AS SiteSettings_GoogleAnalytics, 
            T.CustomCSS AS SiteSettings_CustomCSS, 
            T.IsCustomCSSOn AS SiteSettings_IsCustomCSSOn, 
            T.CustomJS AS SiteSettings_CustomJS, 
            T.IsCustomJsOn AS SiteSettings_IsCustomJsOn, 
            T.[site Last Updated] AS SiteSettings_SiteLastUpdated, 
            T.[Updated By] AS SiteSettings_UpdateBy, 
            True AS _from0
        FROM CodeFirstDatabase.SiteSettings AS T
    ) AS T1");
        }
    }
}
