//(C)May2016 github_user83
//Licensed under MIT license
using System.Web.Optimization;

//todo for LessTransform: install dotless nuget package
//todo for LessTransform: set namespace here
namespace YourNamespaceHere.App_Start
{
    public class LessTransform : IBundleTransform
    {
        //todo for LessTransform: cutpaste to BundleConfig:  StackflowQuizzio.App_Start.LessTransform.AdddotLessTransformToBundleCollection(bundles, true);
        //todo for LessTransform: copypaste where necessary, such as _layout.cshtml:  @Styles.Render("~/Content/lesscss")

        public static void AdddotLessTransformToBundleCollection(BundleCollection argBC, bool argMinify)
        {
            //todo for LessTransform: make sure your literal paths here are correct
            var lessbundle = new Bundle("~/Content/lesscss").IncludeDirectory("~/Content/less", "*.less");
            //todo for LessTransform: set namespace here
            lessbundle.Transforms.Add(new YourNamespaceHere.App_Start.LessTransform());
            if (argMinify) { lessbundle.Transforms.Add(new CssMinify()); }
            argBC.Add(lessbundle);
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}