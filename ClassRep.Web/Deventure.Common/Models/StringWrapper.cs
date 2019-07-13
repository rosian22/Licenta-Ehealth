//using System.ComponentModel.DataAnnotations;

namespace Deventure.Common.Models
{
	public class StringWrapper
	{
	    public StringWrapper()
        {
	    }

	    public StringWrapper(string value)
	    {
	        Value = value;
	    }

        //[Required]
        public string Value { get; set; }
	}
}