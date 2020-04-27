using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sol_Rating.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("jQuery-Rating")]
    public class RatingTagHelpers : TagHelper
    {
        #region Declaration
        private const string MaxAttributeName = "max-size";
        private const String RatingAttributeName = "rating";
        private const string OnChangeEventAttributeName = "onchange-event";

        private readonly IHtmlHelper htmlHelper = null;
        #endregion

        #region Constructor
        public RatingTagHelpers(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        #endregion

        #region Property
        [HtmlAttributeName(MaxAttributeName)]
        public int MaxSize { get; set; }

        [HtmlAttributeName(RatingAttributeName)]
        public ModelExpression Rating { get; set; }

        [HtmlAttributeName(OnChangeEventAttributeName)]
        public String OnChangeEvent { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion 



        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

           
            var content = await htmlHelper?.PartialAsync("~/TagHelpers/_JqueryRatingPartialView.cshtml", this);

            output.Content.SetHtmlContent(content);

            //return base.ProcessAsync(context, output);
        }
    }
}
