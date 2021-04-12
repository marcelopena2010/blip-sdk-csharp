﻿using System;
using System.Collections.Generic;
using Lime.Protocol;
using Newtonsoft.Json;
using Take.Blip.Builder.Models;

namespace Take.Blip.Builder.Actions.SendRawMessage
{
    public class SendRawMessageSettings : IValidable
    {
        public string Type { get; set; }

        [JsonIgnore]
        public MediaType MediaType;

        public string RawContent { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public void Validate()
        {
            if (RawContent == null)
            {
                throw new ArgumentException(
                    $"The '{nameof(RawContent)}' settings value is required for '{nameof(SendRawMessageSettings)}' action");
            }

            if (Type == null)
            {
                throw new ArgumentException(
                    $"The '{nameof(Type)}' settings value is required for '{nameof(SendRawMessageSettings)}' action");
            }

            if (!MediaType.TryParse(Type, out MediaType))
            {
                throw new ArgumentException(
                    $"The '{nameof(Type)}' settings value must be a valid MIME type for '{nameof(SendRawMessageSettings)}' action");
            }
        }
    }
}
