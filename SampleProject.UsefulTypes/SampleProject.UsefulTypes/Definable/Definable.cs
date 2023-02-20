using System;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace SampleProject.UsefulTypes
{
	[JsonConverter(typeof(DefinableJsonConverter))]
	[SwaggerSchemaFilter(typeof(DefinableSchemaFilter))]
	public struct Definable<T> : IDefinable
	{
		public T Value
		{
			get
			{
				return IsDefined ? _value : default(T); 
			}
			set
			{
				_value = value;
				IsDefined = true;
			}
		}

		public bool IsDefined { get; set; }

		public object GetValue()
		{
			return IsDefined ? _value : default(T);
		}

		public void SetValue(object value)
		{
			if(IsDefined)
			{
				_value = (T)value;
			}
		}

		public Type GetType()
		{
			return typeof(Definable<T>);
		}

        public Type GetValueType()
        {
			return typeof(T);
        }

        private T _value { get; set; }
		/*
		public static implicit operator Definable<T>(T value)
		{
			return new Definable<T> { Value = value, IsDefined = true };
		}

		public static implicit operator T(Definable<T> value)
		{
			return value.Value;
		}*/
	}
}

