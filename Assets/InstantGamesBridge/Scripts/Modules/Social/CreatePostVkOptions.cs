using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Social
{
    [Serializable]
    public class CreatePostVkOptions : CreatePostPlatformDependedOptions
    {
        public string message;

        public string attachments;

        public CreatePostVkOptions(string message, string attachments)
        {
            _targetPlatformId = PlatformId.VK;
            this.message = message;
            this.attachments = attachments;
        }

        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}