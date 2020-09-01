using System.Collections.Generic;

namespace PROJECT.UI.viewModels
{
    public class ComboboxViewModel
    {
        public List<string> OrderOptions { get; set; }

        private ComboboxViewModel() { }

        public static ComboboxViewModel Build(List<string> orderOptions)
        {
            var cb = new ComboboxViewModel();
            cb.OrderOptions = orderOptions;

            return cb;
        }
    }
}
