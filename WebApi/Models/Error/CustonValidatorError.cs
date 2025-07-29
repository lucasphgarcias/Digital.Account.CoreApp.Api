namespace WebApi.Models.Error
{
    public class CustonValidatorError
    {

        public CustonValidatorError(string propertyName, string errorMessage) 
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        
        }

        private string PropertyName { get; set; }
        private string ErrorMessage { get; set; }

    }
}
