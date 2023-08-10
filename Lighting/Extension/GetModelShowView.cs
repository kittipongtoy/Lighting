using Lighting.Areas.Identity.Data;
using Lighting.Models;

namespace Lighting.Extension
{
    public class GetModelShowView : BannerIndex
    {
        private readonly LightingContext _context;

        public GetModelShowView(LightingContext context)
        {
            _context = context;
        }

        public void Get()
        { 
            //return 
        }
    }
}
