﻿#region Imports

using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using Yagasoft.XrmMockGenerator.Control;

#endregion

namespace Yagasoft.XrmMockGenerator
{
	[Export(typeof(IXrmToolBoxPlugin))]
	[ExportMetadata("BackgroundColor", "#58C1E4")]
	[ExportMetadata("PrimaryFontColor", "Black")]
	[ExportMetadata("SecondaryFontColor", "Gray")]
	[ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABmJLR0QAAAAAAAD5Q7t/AAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4ggQFhw7uOZnzAAABWJJREFUWMPFll1IHFcUx8+9d+7szq67q+O62iiBpEk2YPMgBNKipl+ENjRE2rSNLzYUrJWCtZRACm4QKUm1xAZJoaFfvtmHItR+PBRaUoINSStCsVJCW+waY83q7rjuzGx2Pu7pQ1U2H8ZVIzkwDzNzD/d3/+d/z70E1hgnT54Ex3H8hBDr9OnTNmwwyFoGHz9+vJRSWkcpfZZS+gch5CIA/H7q1ClnvQC00IFtbW2AiI8jYgsi/o2I2xCxEwAqNqJAwQCEENV13eccxxlwXfcDAOhGxBwiPtbR0UHuK8DU1BTMz8+Dpmn5ADYiGgAQUFXVwxjzIyJFRNNxVq+ApmkwNzcH8Xj83h4YGxsDxhhUVFSAqqpw7tw5ZhiGCgBRTdP2uq7bIEnSVUppOSGEKYrSGovFplcDsCwLEokEaJoGsixDNBoFAADpboMdxwFVVaGnp6dkcnLymGVZNUKIWs75ZY/Hc1UIYVFKv1EU5XI4HL5RiNSyLAMAwPj4ODDGlr/fAVBZWQmqqi7JtjudTrcyxkYYY72IWG8YxtOKorxeXl5+oa2tDdda8+rq6pVLkEqlAABAVVVoaWlRhBDvCiGqQ6FQy9mzZ691dXVt1zStn3N+paysrPP69euSJEm7LMvyIWK+X0CSJNvj8fzT3d09czvE8PAw1NXV3XsXmKbJstnsQ47j3JQkKb0o4zwhJGfb9lbLsny2bR9eWFjYaxhGZOnJZrPluq5HDMOIZjKZV0+cOBHKX+DIyMgyxB0AS9IDADQ2NuqBQOBLIUQ0nU6/1NTUtCsej7+QzWbLvF7vx7Is65TSCKX0KmPsq/7+/sH9+/df2Ldvn11fX/8DY+xX13UVRPTke6uqqgoIISsrsARx6NAh0DRt1DTNi5qmPZ/L5b7IZDIvZrPZ0WQyySYmJvZ4vd6fAeBAOBzeMjg46EFEIoRQFhYW/JZlHZYkaTgSiSRv2feUQm1tbeGtuKGhwccY20YpfYJSKjHGgpzzBs55yO/3f5bL5XZHo9HvI5HIRCQSuRKPx/fYti2NjIwckGV54Pz589dSqdQt6uaHtBrA0NCQCQDjR44cASHEAGPMyzn/RZZlmsvljgkhymZmZi5EIpFrc3NzJYg4a9u2FxFhyZgrTV5wK25qauJer3cX5xyLioq6iouLWysrK1/zeDzvEEKShmEUz87Omq7rqpzzYDwev3Ffz4KSkpIqy7I6ENEMBoM/9vb2GrFYzJQk6SfXdScsy2o3TfMpRNwmhHhSVVV+XwASicT/dZIkCxH/dRyHOY7jW/rvuq5XCOHlnN8MBAKPMMbGPR7PgN/v9xNCCjqgpEIG7dixY3pmZuZTwzA+nJ+ff6O1tfUTzrmr63qj4zjbi4qK3g+FQl8LISxEVBRFKeecezC/O60VYHR0FNLpNCSTSSgtLcXm5uZJ0zSnMpnMYV3Xn6GUAmMsIMtyRXFx8VuZTOboYioKIVgwGDTT6fTn6wYghICu67Bz504AAAiHw7/Ztv2KJEmVyWTybSGEEgwG3wsEAm9yzh+1bfvhpdzFhY9tSIGamppb3ru7uwUA/NnX1/fXpUuXxgkhZOvWrTdN0zx6e24B864OsNSrAWC5bQIAtLe3IwDMAgB0dnb6N3oppRtJLtDo61Mgf9WbGRQecKwZIJVKLV9cHrgCa3H7pgAsXi5XpKCUknWbcKXIP1oppY7rujeEEHdTRg+FQtamKnDw4MGc67rf6ro+7TgOICIIIcA0TcN13e98Pt+qZtnwRo7FYr5sNvsypbSZc77FcZx527aHhBAf9fX1JTYdAADgzJkzbHp6ugwASmzb1n0+X6KnpydXSO5/rvyZhhZzc6EAAAAASUVORK5CYII=")]
	[ExportMetadata("BigImageBase64", "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")]
	[ExportMetadata("Name", "xrm-mock Generator")]
	[ExportMetadata("Description", "Generate the XRM form model for use with xrm-mock testing framework.")]
	public class XrmMockGeneratorPlugin : PluginBase
	{
		public override IXrmToolBoxPluginControl GetControl()
		{
			return new PluginControl();
		}
	}
}
