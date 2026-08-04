namespace Cmod_Coffee.Domain
{
    public class SizeRule
    {
        public bool CheckValidation(string SizeCap)
        {
            if (SizeCap == "Small" || SizeCap == "Medium" || SizeCap == "Large")
                return true;
            else
                return false;
        }
    }
}
