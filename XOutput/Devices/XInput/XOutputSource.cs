﻿using XOutput.Devices.Mapper;

namespace XOutput.Devices.XInput
{
    /// <summary>
    /// Direct input source.
    /// </summary>
    public class XOutputSource : InputSource
    {
        public XInputTypes XInputType => inputType;

        private readonly XInputTypes inputType;


        public XOutputSource(string name, XInputTypes type) : base(null, name, type.GetInputSourceType(), 0)
        {
            inputType = type;
        }

        internal bool Refresh(InputMapper mapper)
        {
            var mapping = mapper.GetMapping(inputType);
            if (mapping != null)
            {
                double value = 0;
                if (mapping.Source != null)
                {
                    value = mapping.Source.Get(inputType);
                }
                double newValue = mapping.GetValue(value);
                return RefreshValue(newValue);
            }
            return false;
        }
    }
}
