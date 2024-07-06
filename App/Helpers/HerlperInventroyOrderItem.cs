namespace App.Helpers
{
    public class HerlperInventroyOrderItem
    {

        public static decimal GetPercentageTaxces(int prodcutId)
        {
            decimal totalPercentageTaxces = 0;
            var taxs = App.appServices.taxs.product_taxes.Where(x => x.product == prodcutId);
            foreach (var tax in taxs)
            {
                var t = App.appServices.taxs.taxes.Where(x=> x.id == tax.tax).FirstOrDefault();
                if (t is null) continue;
                totalPercentageTaxces += t.percentage_value;
            }
            return totalPercentageTaxces;
        }


        public static Dictionary<string , decimal> GetTaxces(int productId)
        {
            Dictionary<string, decimal> _t = new Dictionary<string, decimal>();
            var taxs = App.appServices.taxs.product_taxes.Where(x => x.product == productId);
            foreach (var tax in taxs)
            {
                var t = App.appServices.taxs.taxes.Where(x => x.id == tax.tax).FirstOrDefault();
                if (t is null) continue;
                _t.Add(t.name , t.percentage_value);
            }
            return _t;
        }
    }
}
