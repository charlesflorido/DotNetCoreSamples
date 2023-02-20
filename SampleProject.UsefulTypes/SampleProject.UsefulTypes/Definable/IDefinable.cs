using System;
namespace SampleProject.UsefulTypes
{
	public interface IDefinable
	{
		bool IsDefined { get; set; }
		object GetValue();
		void SetValue(object value);
		Type GetValueType();
	}
}

